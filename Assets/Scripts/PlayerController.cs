﻿using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
  private PlayerStartTransform _playerStartPos;
  Vector3 _velocity;
  Vector3 _eulerAngleVelocity;
  float _speed;
  bool _rotate = false;
  Rigidbody _rigidbody;
  void Awake()
  {
    _playerStartPos = new PlayerStartTransform(transform);
    _rigidbody = GetComponent<Rigidbody>();
  }
  public void Move(Vector3 moveVelocity)
  {
    _velocity = moveVelocity;
  }
  public void Move(float moveSpeed)
  {
    _speed = moveSpeed;
    _velocity = _rigidbody.transform.forward * moveSpeed;
  }
  void FixedUpdate()
  {
    //Move
    _rigidbody.MovePosition(transform.position + _velocity * Time.deltaTime);

    //Rotate
    if (_rotate)
    {
      float turn = _speed * _eulerAngleVelocity.y * Time.deltaTime;
      var _deltaRotation = Quaternion.Euler(_eulerAngleVelocity * _speed * Time.deltaTime);
      _rigidbody.MoveRotation(_rigidbody.rotation * _deltaRotation);
    }
  }
  public void Rotate(Vector3 eulerAngleVelocity)
  {
    _eulerAngleVelocity = eulerAngleVelocity;
    _rotate = true;
  }
  public void StopRotate()
  {
    _rotate = false;
  }
  public void Reset()
  {
    _eulerAngleVelocity = Vector3.zero;
    _velocity = Vector3.zero;
    _rigidbody.velocity = new Vector3(0f, 0f, 0f);
    _rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
    _playerStartPos.UpdateTransform(transform);
  }



  struct PlayerStartTransform
  {
    Vector3 _pos;
    Vector3 _localScale;
    Quaternion _rotation;

    public PlayerStartTransform(Transform t)
    {
      _pos = t.localPosition;
      _localScale = t.localScale;
      _rotation = t.localRotation;
    }

    public void UpdateTransform(Transform t)
    {
      t.localPosition = _pos;
      t.localScale = _localScale;
      t.localRotation = _rotation;
    }

  }
}
