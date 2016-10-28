using UnityEngine;
using System.Collections;
using System;


public class Player : MonoBehaviour, IRestartableCommand
{
  public float minSpeed = 5;
  public float maxSpeed = 15;

  public float moveSpeed = 5;

  public Vector3 rotationSpeed = new Vector3(0, 5, 0);


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
  void Start()
  {
  }
  void Begin()
  {
    print("Player: Begin()");
    LeanTween.value(gameObject, minSpeed, maxSpeed, 60f).setOnUpdate((float speed) =>
    {
      moveSpeed = speed;
    });

    _running = true;
  }
  // Update is called once per frame
  void Update()
  {
    MoveInput();
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
