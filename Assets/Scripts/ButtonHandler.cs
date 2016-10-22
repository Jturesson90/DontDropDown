using UnityEngine;
using System.Collections;

public abstract class ButtonHandler : MonoBehaviour
{
  public abstract void OnClick();
  public void AnimationDone()
  {
    gameObject.SetActive(false);
  }
}
