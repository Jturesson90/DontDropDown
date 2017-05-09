using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private Transform _playerTransform;
    public Transform PlayerTransform { get { return _playerTransform; } }
    // Use this for initialization
    void Start()
    {
        if (!_playerTransform)
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_playerTransform)
            transform.position = _playerTransform.position;
    }
}
