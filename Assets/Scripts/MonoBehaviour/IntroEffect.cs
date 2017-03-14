using UnityEngine;
using System.Collections;
using System;

public class IntroEffect : MonoBehaviour
{

  public AnimationCurve animationCurve;
  public Vector3 fromPosition;
  public Vector3 toPosition;
  public float duration = 1.5f;
  public LeanTweenType tweenType;
  bool animating = false;
  void Awake()
  {
    gameObject.transform.position = fromPosition;
  }
  void OnEnable()
  {
    GameController.OnGameStateChanged += OnGameStateChanged;
  }

  private void OnGameStateChanged()
  {
    if (GameController.Instance.GameState == GameState.Intro)
    {
      if (!animating)
      {
        animating = true;
        LeanTween.move(gameObject, toPosition, duration).setEase(tweenType).setOnComplete(() =>
        {
          GameController.Instance.IntroDone();
        });
        // StartCoroutine(Move());
      }
    }
  }


  void OnDisable()
  {
    GameController.OnGameStateChanged -= OnGameStateChanged;

  }
  IEnumerator Move()
  {
    float timer = 0;
    while (timer < duration)
    {
      transform.localPosition = Vector3.Lerp(fromPosition, toPosition, animationCurve.Evaluate(timer / duration));
      timer += Time.deltaTime;
      yield return null;
    }
    transform.localPosition = toPosition;
    GameController.Instance.IntroDone();
  }
}
