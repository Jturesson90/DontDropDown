using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(ScoreController))]
public class ScoreHandler : MonoBehaviour
{

  ScoreController _controller;
  void Start()
  {
    print("ScoreHandler Awake");
    _controller = GetComponent<ScoreController>();
    GameController.OnGameStateChanged += OnGameStateChanged;
  }

  private void OnGameStateChanged()
  {
    var state = GameController.Instance.GameState;
    switch (state)
    {
      case GameState.InMenu:
        _controller.Reset();
        break;
      case GameState.Playing:
        if (_controller.IsRunning) break;
        _controller.Start();
        break;
      case GameState.GameOver:
        _controller.Stop();
        break;
    }
  }
}
