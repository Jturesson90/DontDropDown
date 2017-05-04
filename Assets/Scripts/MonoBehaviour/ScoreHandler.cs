using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class ScoreHandler : MonoBehaviour
{

    public BestScoreText bestScoreText;
    [SerializeField]
    private ScoreController _controller;
    void Start()
    {
        if (!_controller)
            _controller = FindObjectOfType<ScoreController>();
        //  OnStateChanged(GameController.Instance.GameState);
    }
    private void OnEnable()
    {
        GameController.OnGameStateChanged += OnStateChanged;
    }
    private void OnDisable()
    {
        GameController.OnGameStateChanged -= OnStateChanged;
    }
    private void OnStateChanged(GameState gameState)
    {
        var state = gameState;
        switch (state)
        {
            case GameState.InMenu:
                _controller.ResetWatcher();
                break;
            case GameState.Playing:

                if (_controller.IsRunning) break;
                _controller.StartWatcher();
                break;
            case GameState.GameOver:
                _controller.StopWatcher();

                PlayerPrefsManager.SetHighscore(_controller.GetScore());
                long score1 = _controller.GetScore();
                long score2 = PlayerPrefsManager.GetHighscore();

                long bestScore = score1 > score2 ? score1 : score2;
                bestScoreText.SetScore(bestScore);

                GameController.Instance.SubmitScore(_controller.GetScore());
                break;
        }
    }
}
