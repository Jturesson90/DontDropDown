using UnityEngine;
using System.Collections;
using System;

public class GameUIHandler : UIHandler
{
  protected override void OnGameStateChanged()
  {
    var state = GameController.Instance.GameState;

    if (state == GameState.Playing || state == GameState.GameOver)
    {
      SetChildrenActive(true);
    }
    else
    {
      SetChildrenActive(false);
    }
  }
}
