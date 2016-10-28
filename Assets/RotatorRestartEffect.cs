using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using UnityStandardAssets.ImageEffects;

public class RotatorRestartEffect : MonoBehaviour, IRestartableDurationCommand
{
  public int rotations = 5;
  public AnimationCurve animationCurve;
  public void ExecuteDuration(float duration)
  {
    print("RotatorRestartEffect: Execute()");
    StartCoroutine(Rotate(duration));
  }

  IEnumerator Rotate(float duration)
  {
    Vector3 originalRotation = transform.localEulerAngles;
    Vector3 toRotation = originalRotation;
    toRotation.y += rotations * 360f;

    Blur(true);
    float timer = 0;
    while (timer < duration)
    {
      transform.localEulerAngles = Vector3.Lerp(originalRotation, toRotation, animationCurve.Evaluate(timer / duration));
      timer += Time.deltaTime;
      yield return null;
    }
    Blur(false);
    transform.localEulerAngles = originalRotation;

  }
  void Blur(bool state)
  {
    var blur = Camera.main.GetComponent<MotionBlur>();
    if (blur != null)
    {
      blur.enabled = state;
    }
  }




}
