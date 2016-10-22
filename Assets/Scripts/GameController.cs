using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameController
{
  private static GameController _instance;
  public static GameController Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = new GameController();
      }
      return _instance;
    }
  }
  public static event Action OnPlayerHitDeathTrigger;
  public static event Action OnRestart;
  public void StartMenu()
  {
    hasStarted = true;
    UIManager.OnPlayButtonClicked += OnPlayClicked;
    GameState = GameState.InMenu;
  }
  private bool hasStarted = false;
  public static event Action OnGameStateChanged;
  private GameState _gameState;
  public GameState GameState
  {
    get { return _gameState; }
    set
    {
      if (!hasStarted) return;
      if (_gameState != value)
      {
        _gameState = value;

        Debug.Log("GameController calling OnGameStateChanged");
        if (OnGameStateChanged != null) OnGameStateChanged();
      }
    }
  }
  public GameController()
  {

  }
  public void Restart()
  {
    Debug.Log("GameController: Restart()");

    if (GameState == GameState.GameOver)
    {
      GameState = GameState.InMenu;
    }
    //   GameManager.Instance.Restart();
    if (OnRestart != null)
    {
      OnRestart();
    }
  }
  void OnPlayClicked()
  {
    Debug.Log("GameController: OnPlayClicked()");
    if (GameState == GameState.InMenu)
    {
      GameState = GameState.Playing;
    }
  }
  public void Death()
  {
    GameState = GameState.GameOver;
    if (OnPlayerHitDeathTrigger != null) OnPlayerHitDeathTrigger();
  }
}
public enum GameState
{
  Undefined, InMenu, Waiting, Playing, GameOver
}
