using UnityEngine;
using System.Collections;
using System;


public class Player : MonoBehaviour, IRestartableCommand
{
  private PlayerStartTransform _playerStartPos;
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
    _playerStartPos = new PlayerStartTransform(transform);
    _playerController = GetComponent<PlayerController>();

  }

  private void OnGameStateChanged()
  {
    switch (GameController.Instance.GameState)
    {
      case GameState.Playing:
        Begin();
        break;
      case GameState.GameOver:
        GameOver();
        break;
    }
  }

  private void GameOver()
  {
    _playerController.enabled = false;
  }

  void Begin()
  {
    _playerController.enabled = true;
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
#if !UNITY_EDITOR
    TouchMoveInput(); 
#endif
  }
  private void OnEnable()
  {
    GameController.OnGameStateChanged += OnGameStateChanged;
  }
  void OnDisable()
  {
    GameController.OnGameStateChanged -= OnGameStateChanged;
  }
  void OnRestart()
  {
    print("Player: Restart()");
    _running = false;
    _playerController.ResetController();
    LeanTween.cancel(speedTweenId);
    _playerStartPos.UpdateTransform(transform);
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
  struct PlayerStartTransform
  {
    Vector3 _pos;
    Vector3 _localScale;
    Quaternion _rotation;

    public PlayerStartTransform(Transform t)
    {
      _pos = t.localPosition;
      _localScale = t.localScale;
      _rotation = t.localRotation;
    }

    public void UpdateTransform(Transform t)
    {
      t.localPosition = _pos;
      t.localScale = _localScale;
      t.localRotation = _rotation;
    }

  }
}
