using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animal : MonoBehaviour
{

    private readonly string ANIMATOR_SPEED_STRING = "Speed_f";
    private int _animatorSpeedHash;
    private Animator _animator;
    [Range(0.5f, 2f)]
    public float StartAnimationSpeed = 0.8f;
    [HideInInspector]
    public Player Player;

    private List<GameObject> _animalMeshes = null;
    private void OnEnable()
    {

        _animalMeshes = new List<GameObject>();
        _animator = GetComponent<Animator>();
        _animator.applyRootMotion = false;
        _animatorSpeedHash = Animator.StringToHash(ANIMATOR_SPEED_STRING);

        foreach (Transform child in transform)
        {
            _animalMeshes.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        int randomIndex = Random.Range(0, _animalMeshes.Count);
        _animalMeshes[randomIndex].SetActive(true);
        _animator.SetFloat(_animatorSpeedHash, 0);
        _animator.speed = 1;
    }
    private void OnDisable()
    {
        _animator = null;
        _animalMeshes.Clear();
        _animalMeshes = null;
    }
    public void SetAnimatorSpeed(float speed)
    {
        _animator.SetFloat(_animatorSpeedHash, 1f, 0.1f, Time.deltaTime);
        _animator.speed = (speed * StartAnimationSpeed) / (transform.localScale.z*2);
    }
}
