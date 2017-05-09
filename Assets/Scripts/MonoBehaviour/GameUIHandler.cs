using UnityEngine;
using System.Collections;
using System;

public class GameUIHandler : UIHandler
{
  protected override void OnGameStateChanged(GameState gameState)
  {
    if (gameState == GameState.Playing || gameState == GameState.GameOver)
    {
      SetChildrenActive(true);
    }
    else
    {
      SetChildrenActive(false);
    }
  }
}
