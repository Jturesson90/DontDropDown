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
        print("ScoreHandler Start");
        _controller = GetComponent<ScoreController>();

    }
    private void OnEnable()
    {
        GameController.OnGameStateChanged += OnGameStateChanged;
    }
    private void OnDisable()
    {
        GameController.OnGameStateChanged -= OnGameStateChanged;
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
