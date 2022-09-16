using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldService : MonoBehaviour
{
    [SerializeField]
    private Transform _headPose;

    [SerializeField]
    private bool _followUser = false;

    [SerializeField]
    private int _distanceFromUser = 1;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePosition();
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
        var worldContainerPosition = _headPose.position + _headPose.forward * _distanceFromUser;
        transform.position = worldContainerPosition;
    }
}
