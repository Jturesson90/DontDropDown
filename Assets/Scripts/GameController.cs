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
  public static event Action OnGameStateChanged;
  public void StartMenu()
  {
    hasStarted = true;
    UIManager.OnPlayButtonClicked += OnPlayClicked;
    GameState = GameState.Intro;
  }
  private bool hasStarted = false;

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
  private long _time = -1;
  public long GetTime()
  {
    return _time;
  }
  internal void SubmitScore(long time)
  {
    _time = time;
  }

  public GameController()
  {

  }
  public void Restart()
  {
    Debug.Log("GameController: Restart()");

    if (GameState == GameState.GameOver)
    {
      GameState = GameState.Restarting;
      if (OnRestart != null)
      {
        OnRestart();
      }
    }
  }
  public void IntroDone()
  {
    if (GameState == GameState.Intro)
    {
      GameState = GameState.InMenu;
    }
  }
  public void RestartDone()
  {
    if (GameState == GameState.Restarting)
    {
      GameState = GameState.InMenu;
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
  Undefined, Intro, InMenu, Waiting, Playing, GameOver, Restarting
}
