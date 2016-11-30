using UnityEngine;
using System.Collections;
using System;


public class Player : MonoBehaviour, IRestartableCommand
{
  public float minSpeed = 5;
  public float maxSpeed = 15;
  public float increasingSpeedDuration = 60f;
  public float moveSpeed = 5;
  public readonly static string PLAYER_TAG = "Player";
  public Vector3 rotationSpeed = new Vector3(0, 5, 0);

  int speedTweenId = -1;
  bool _running = false;

  PlayerController _playerController;
  void Awake()
  {
    _playerController = GetComponent<PlayerController>();
    GameController.OnGameStateChanged += OnGameStateChanged;
  }

  private void OnGameStateChanged()
  {
    switch (GameController.Instance.GameState)
    {
      case GameState.Playing:
        Begin();
        break;
    }
  }
  void Begin()
  {
    speedTweenId = LeanTween.value(gameObject, minSpeed, maxSpeed, increasingSpeedDuration).setOnUpdate((float speed) =>
    {
      moveSpeed = speed;
    }).id;
    _running = true;
  }
  // Update is called once per frame
  void Update()
  {
#if UNITY_EDITOR
    MoveInput();
#endif
  }
  private void FixedUpdate()
  {
#if !UNITY_EDITOR
    TouchMoveInput(); 
#endif
  }
  void OnDisable()
  {
    GameController.OnGameStateChanged -= OnGameStateChanged;
  }
  void OnRestart()
  {
    print("Player: Restart()");
    _running = false;
    _playerController.Reset();
    LeanTween.cancel(speedTweenId);
  }
  private void TouchMoveInput()
  {
    if (!_running) return;
    if (Input.touchCount > 0)
    {
      _playerController.Rotate(rotationSpeed);
    }
    else
    {
      _playerController.StopRotate();
    }
    _playerController.Move(moveSpeed);

  }
  private void MoveInput()
  {
    if (!_running) return;
    if (Input.GetMouseButton(0))
    {
      _playerController.Rotate(rotationSpeed);
    }
    else
    {
      _playerController.StopRotate();
    }
    _playerController.Move(moveSpeed);
  }
  public void Execute()
  {
    OnRestart();
  }
}
