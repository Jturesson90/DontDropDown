using UnityEngine;
using System.Collections;
using System;

public class UIManager : MonoBehaviour
{
  private static UIManager _instance;
  public static UIManager Instance { get { return _instance; } }

  void Awake()
  {
    if (_instance != null)
    {
      Destroy(gameObject);
      return;
    }
    _instance = this;
  }
  public static event Action OnPlayButtonClicked;

  public void OnClick(ButtonHandler button)
  {
    print("UIManager: OnClick()");
    if (button is PlayButtonHandler)
    {
      if (OnPlayButtonClicked != null) OnPlayButtonClicked();
    }
  }
}
