using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour, IRestartableCommand
{
    private PlayerStartTransform _playerStartPos;
    public readonly static string PLAYER_TAG = "Player";

    int speedTweenId = -1;
    bool _running = false;

    BaseController _controller;
    private void Start()
    {
        print("BEAR START");
    }
    void Awake()
    {
        _playerStartPos = new PlayerStartTransform(transform);
        _controller = GetComponent<BaseController>();        
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
        _controller.Stop();
    }

    void Begin()
    {
        _controller.Begin();
        _running = true;
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
        _running = false;
        _controller.ResetController();
        _playerStartPos.UpdateTransform(transform);
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
