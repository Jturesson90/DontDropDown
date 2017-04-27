using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Player))]
public abstract class BaseController : MonoBehaviour
{
    Vector3 _move;
    float _speed;
    bool _rotate = false;
    Player _player;
    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    protected abstract float GetInput();
    readonly Vector3 _forward = Vector3.forward;
    void FixedUpdate()
    {
        var input = GetInput();

        //Move
        var rotate = input > float.Epsilon ? true : false;
        _player.Move(transform.forward, rotate);

        //Move
        //_move = _rigidbody.transform.forward * input;
        //var deltaSpeed = _rigidbody.transform.forward * MoveSpeed * Time.deltaTime;
        //var newPosition = transform.position + deltaSpeed;

        //_rigidbody.MovePosition(newPosition);
        ////Rotate
        //var deltaRotation = Quaternion.Euler(Angle * MoveSpeed * input * Time.deltaTime);
        //_rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);

    }
}
