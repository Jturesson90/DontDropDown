using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

public class Pillar : MonoBehaviour
{

    Vector3 _startPosition;
    Vector3 _endPosition;
    public float _animationTime = 1f;

    [SerializeField]
    LeanTweenType _tweenType = LeanTweenType.linear;

    float _height;

    public void SetStartPosition(Vector3 startposition)
    {
        _startPosition = transform.localPosition;
        _endPosition = new Vector3(_startPosition.x, _startPosition.y + _height, _startPosition.z);
    }
    private void Awake()
    {
        _height = GetComponent<Collider>().bounds.size.y;
        SetStartPosition(transform.position);
    }
    [Button]
    public void AnimateUp()
    {
        LeanTween.moveLocalY(gameObject, _startPosition.y + _height, _animationTime).setEase(_tweenType);
    }
    [Button]
    public void AnimateDown()
    {
        LeanTween.moveLocalY(gameObject, _startPosition.y, _animationTime).setEase(_tweenType);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(Player.PLAYER_TAG))
        {
            var player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                player.HitByObject(this);
            }
        }
    }
}
