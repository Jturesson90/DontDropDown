using UnityEngine;
using System.Collections;
using System;

public class MenuUIhandler : UIHandler
{
  public PlayButtonHandler playButton;
  protected override void OnGameStateChanged()
  {
    if (GameController.Instance.GameState == GameState.InMenu)
    {
      SetChildrenActive(true);
      playButton.Reset();
      
    }
  }
}
