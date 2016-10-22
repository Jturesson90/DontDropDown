using UnityEngine;
using System.Collections;
using System;

public abstract class UIHandler : MonoBehaviour
{
  protected virtual void Awake()
  {
    GameController.OnGameStateChanged += OnGameStateChanged;
    //OnGameStateChanged();
  }

  protected abstract void OnGameStateChanged();

  protected void SetChildrenActive(bool active)
  {
    foreach (Transform item in transform)
    {
      if (item.gameObject.activeSelf != active)
      {
        item.gameObject.SetActive(active);
      } 
    }
  }

  void OnDisable()
  {
    GameController.OnGameStateChanged -= OnGameStateChanged;
  }

}
