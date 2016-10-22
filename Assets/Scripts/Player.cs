using UnityEngine;
using System.Collections;
using System;


public class Player : MonoBehaviour
{
  public float moveSpeed = 5;
  public Vector3 rotationSpeed = new Vector3(0, 5, 0);
  bool _running = false;

  PlayerController _playerController;


  void Awake()
  {

    _playerController = GetComponent<PlayerController>();

    GameController.OnGameStateChanged += OnGameStateChanged;
    GameController.OnRestart += OnRestart;
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
    _running = true;
  }
  // Update is called once per frame
  void Update()
  {
    MoveInput();
  }
  void OnDisable()
  {
    GameController.OnRestart -= OnRestart;
    GameController.OnGameStateChanged -= OnGameStateChanged;
  }
  public void OnRestart()
  {
    print("Player: Restart()");
    _running = false;
    _playerController.Reset();

  }
  private void MoveInput()
  {
    if (!_running) return;
    if (Input.GetMouseButton(0))
      _playerController.Rotate(rotationSpeed);
    else
    {
      _playerController.Rotate(new Vector3(0, 0, 0));
    }
    _playerController.Move(moveSpeed);
  }


}
