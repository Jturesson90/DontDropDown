using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseController : MonoBehaviour
{
    public float MinSpeed = 1.2f;
    public float MaxSpeed = 8f;
    public float IncreasingSpeedDuration = 60f;
    public float MoveSpeed = 1f;
    public Vector3 Angle = new Vector3(0, -47, 0);

    Vector3 _velocity;
    Vector3 _eulerAngleVelocity = Vector3.one;
    float _speed;
    bool _rotate = false;
    Rigidbody _rigidbody;
    protected abstract float GetInput();
    private float _input;

    int speedTweenId = -1;

    bool _running = false;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Begin()
    {
        speedTweenId = LeanTween.value(gameObject, MinSpeed, MaxSpeed, IncreasingSpeedDuration).setOnUpdate((float speed) =>
        {
            MoveSpeed = speed;
        }).id;
        _running = true;
    }

    public void Stop()
    {
        LeanTween.cancel(speedTweenId);
    }
    private void Update()
    {
        if (!_running) return;
        _input = GetInput();
    }
    void FixedUpdate()
    {
        if (!_running) return;
        //Move
        _rigidbody.MovePosition(transform.position + _rigidbody.transform.forward * MoveSpeed * Time.deltaTime);

        //Rotate
        var _deltaRotation = Quaternion.Euler(Angle * MoveSpeed * _input * Time.deltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * _deltaRotation);

    }
    public void ResetController()
    {
        _running = false;
        _eulerAngleVelocity = Vector3.zero;
        _velocity = Vector3.zero;
        _rigidbody.velocity = new Vector3(0f, 0f, 0f);
        _rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);

    }
}
