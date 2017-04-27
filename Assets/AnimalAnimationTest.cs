using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimationTest : MonoBehaviour
{
    Rigidbody _rigidbody;
    Animator _animator;
    public float speed = 1f;
    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.speed = speed;
        _rigidbody.velocity = new Vector3(0, 0, (transform.forward.z  * _animator.speed * transform.localScale.z));
        print(_animator.speed);
    }
}
