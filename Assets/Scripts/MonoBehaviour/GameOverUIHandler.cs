using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameOverUIHandler : UIHandler
{
    bool _pressed = false;
    public float waitTime = 1f;
    public List<GameObject> gameObjectsToActivateWithDelay;
    public List<GameObject> gameObjectsToActivateWithoutDelay;
    public List<GameObject> gameObjectsToDeactivate;
    protected override void OnGameStateChanged()
    {
        var gameState = GameController.Instance.GameState;
        if (gameState == GameState.GameOver)
        {
            _pressed = false;

            SetGameObjectsActiveDelay(gameObjectsToActivateWithDelay, true, waitTime);
            foreach (var child in gameObjectsToActivateWithoutDelay)
            {
                child.SetActive(true);
            }
        }
        else
        {
            foreach (var child in gameObjectsToDeactivate)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    public void OnRestartPanelClicked()
    {
        if (_pressed) return;
        bool isRestartReady = gameObjectsToActivateWithDelay.TrueForAll(b => b.activeInHierarchy);
        if (!isRestartReady) return;
        _pressed = true;
        GameController.Instance.Restart();
    }
}
