using UnityEngine;
using System.Collections;

public abstract class ButtonHandler : MonoBehaviour
{
  void Awake()
  {
    gameObject.SetActive(false);
  }
  public abstract void OnClick();
  public void AnimationDone()
  {
    gameObject.SetActive(false);
  }
}
