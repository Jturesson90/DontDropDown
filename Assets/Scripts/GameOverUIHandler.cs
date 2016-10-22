using UnityEngine;
using System.Collections;
using System;

public class GameOverUIHandler : UIHandler
{
  bool _pressed = false;
  protected override void OnGameStateChanged()
  {
    var gameState = GameController.Instance.GameState;
    print("GameOverUIHandler OnGameStateChanged " + gameState);
    if (gameState == GameState.GameOver)
    {
      _pressed = false;
      foreach (Transform child in transform)
      {
        child.gameObject.SetActive(true);
      }
    }
    else
    {
      foreach (Transform child in transform)
      {
        child.gameObject.SetActive(false);
      }
    }
  }
  public void OnRestartPanelClicked()
  {
    print("GameOverUIHandler:OnRestartPanelClicked() ");
    if (_pressed) return;
    _pressed = true;
    GameController.Instance.Restart();
  }
}
