using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [Tooltip("Number of minutes per second that pass, try 60")]
    public float minutesPerSecond = 60f;
    public float maximumMinutesPerSecond = 180f;

    private float currentMinutesPerSecond = 0f;
    private Quaternion _startRotation;

    void OnEnable()
    {
        GameController.OnGameStateChanged += OnGameStateChanged;
    }
    void OnDisable()
    {
        GameController.OnGameStateChanged -= OnGameStateChanged;

    }
    private void OnGameStateChanged(GameState gameState)
    {
        if (gameState == GameState.Restarting)
        {
            currentMinutesPerSecond = maximumMinutesPerSecond;
        }
        else
        {
            currentMinutesPerSecond = minutesPerSecond;
        }
    }


    // Use this for initialization
    void Start()
    {
        currentMinutesPerSecond = minutesPerSecond;
        _startRotation = transform.rotation;
    }

    readonly Vector3 forward = Vector3.forward;
    readonly float threeSixty = 1 / 360f;
    // Update is called once per frame
    void Update()
    {
        float angleThisFrame = Time.deltaTime * threeSixty * currentMinutesPerSecond;
        transform.RotateAround(transform.position, forward, angleThisFrame);
    }
}
