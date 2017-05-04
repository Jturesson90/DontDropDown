using UnityEngine;
using System.Collections;
using System;

public class MenuUIhandler : UIHandler
{
    public PlayButtonHandler playButton;
    protected override void OnGameStateChanged(GameState gameState)
    {
        if (gameState == GameState.InMenu)
        {
            playButton.Reset();
            SetChildrenActive(true);
        }
    }
}
