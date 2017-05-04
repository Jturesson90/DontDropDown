using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
[RequireComponent(typeof(ScoreController))]
public class ScoreHandler : MonoBehaviour
{

    ScoreController _controller;
    public BestScoreText bestScoreText;
    void Start()
    {
        _controller = GetComponent<ScoreController>();
        OnStateChanged(GameController.Instance.GameState);
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
                _controller.Reset();
                break;
            case GameState.Playing:

                if (_controller.IsRunning) break;
                _controller.StartCounting();
                break;
            case GameState.GameOver:
                _controller.Stop();

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
