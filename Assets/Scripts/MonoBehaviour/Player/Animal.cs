using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animal : MonoBehaviour
{

    private readonly string ANIMATOR_SPEED_STRING = "Speed_f";
    private int _animatorSpeedHash;
    private Animator _animator;
    public float StartAnimationSpeed = 0.8f;

    private List<GameObject> _animalMeshes = null;
    private void OnEnable()
    {
        _animalMeshes = new List<GameObject>();
        _animator = GetComponent<Animator>();
        _animatorSpeedHash = Animator.StringToHash(ANIMATOR_SPEED_STRING);
        SetAnimatorSpeed(0f);

        foreach (Transform child in transform)
        {
            _animalMeshes.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        int randomIndex = Random.Range(0, _animalMeshes.Count);
        _animalMeshes[randomIndex].SetActive(true);
    }
    private void OnDisable()
    {
        _animator = null;
        _animalMeshes.Clear();
        _animalMeshes = null;
    }

    public void SetAnimatorSpeed(float speed)
    {
        _animator.SetFloat(_animatorSpeedHash, speed);
    }
}
