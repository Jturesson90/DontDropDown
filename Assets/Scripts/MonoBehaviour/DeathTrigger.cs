using UnityEngine;
using System.Collections;
using System;

public class DeathTrigger : MonoBehaviour
{
    private bool _triggered;
    void Awake()
    {
        GameController.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState gameState)
    {
        if (gameState == GameState.Playing)
            _triggered = false;
    }

    private string playerTag = Player.PLAYER_TAG;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            if (_triggered) return;
            if (GameController.Instance.GameState == GameState.Playing)
            {
                GameController.Instance.Death();
            }
        }
    }
}
