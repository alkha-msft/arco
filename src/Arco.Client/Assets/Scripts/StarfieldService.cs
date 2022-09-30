using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfieldService : MonoBehaviour
{
    [SerializeField]
    private GameObject _star1Prefab;
    [SerializeField]
    private GameObject _star2Prefab;
    [SerializeField]
    private int _starCount = 1000;
    [SerializeField]
    private float _scaleMin = 0.5f;
    [SerializeField]
    private float _scaleMax = 1.5f;
    [SerializeField]
    private GameObject _parentObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _starCount; i++) 
        {
            var instance = Instantiate(_star1Prefab);
            var direction = UnityEngine.Random.onUnitSphere;
            instance.transform.position = direction * 10;
            instance.transform.rotation = Quaternion.LookRotation(-direction);
            instance.transform.localScale = new Vector3(1, 1, 1) * UnityEngine.Random.Range(_scaleMin, _scaleMax);
            instance.transform.parent = _parentObject.transform;
        }
    }
}
