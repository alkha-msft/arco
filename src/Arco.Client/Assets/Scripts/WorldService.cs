using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class WorldService : MonoBehaviour
{
    [SerializeField]
    private Transform _headPose;

    [SerializeField]
    private bool _followUser = false;

    [SerializeField]
    private int _distanceFromUser = 1;

    private KeywordRecognizer _keywordRecognizer;

    private Dictionary<string, System.Action> _keywords;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePosition();
        _keywords = new Dictionary<string, System.Action>() {
            {"focus", UpdatePosition}
        };
        _keywordRecognizer = new KeywordRecognizer(_keywords.Keys.ToArray());
        _keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        _keywordRecognizer.Start();
    }

    void OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        if (_keywords.TryGetValue(args.text, out var action)) {
            action.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_followUser)
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        Debug.LogWarning("UpdatePosition");
        var worldContainerPosition = _headPose.position + _headPose.forward * _distanceFromUser;
        transform.position = worldContainerPosition;
    }
}
