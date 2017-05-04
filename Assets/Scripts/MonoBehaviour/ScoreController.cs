using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using System;

[RequireComponent(typeof(Text))]
public class ScoreController : MonoBehaviour
{
    private Text _scoreText;
    Stopwatch _stopwatch;

    public bool IsRunning
    {
        get { return _stopwatch.IsRunning; }
    }
    bool _running = false;
    void Awake()
    {
        _scoreText = GetComponent<Text>();
        _stopwatch = new Stopwatch();
        ResetWatcher();
    }
    private void OnEnable()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.playmodeStateChanged += HandleOnPlayModeChanged;
#endif
    }
    private void OnDisable()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.playmodeStateChanged -= HandleOnPlayModeChanged;
#endif
    }
    public void StartWatcher()
    {
        print("ScoreController: StartCounting()");
        _running = true;
        _stopwatch.Start();
        StartCoroutine(Runner());
    }
    void SetUIScore()
    {
        print("ScoreController: SetUIScore()");
        _scoreText.text = FormatTime(_stopwatch);
    }

    internal long GetScore()
    {
        return _stopwatch.ElapsedMilliseconds;
    }


    WaitForSeconds delay = new WaitForSeconds(0.01f);
    IEnumerator Runner()
    {
        while (_running)
        {
            _scoreText.text = FormatTime(_stopwatch);
            yield return delay;
        }
        yield return null;
    }
    public void StopWatcher()
    {
        print("ScoreController: Stop()");
        _running = false;
        _stopwatch.Stop();
        StopCoroutine(Runner());
        SetUIScore();
    }
    public void ResetWatcher()
    {
        print("ScoreController: Reset()");
        _running = false;
        _scoreText.text = "0:00.00";
        _stopwatch.Reset();
    }

    string FormatTime(Stopwatch sw)
    {
        TimeSpan ts = sw.Elapsed;
        string elapsedTime = string.Format("{0:0}:{1:00}.{2:00}", ts.Minutes, ts.Seconds,
           ts.Milliseconds / 10);
        return elapsedTime;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        OnPause(pauseStatus);
    }

    private void OnPause(bool pauseStatus)
    {
        if (GameController.Instance.GameState != GameState.Playing) return;
        if (pauseStatus)
            StopWatcher();
        else
            StartWatcher();
    }
#if UNITY_EDITOR
    void HandleOnPlayModeChanged()
    {
        OnPause(UnityEditor.EditorApplication.isPaused);
    }
#endif
}
