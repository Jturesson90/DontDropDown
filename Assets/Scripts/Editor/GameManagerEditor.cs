﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var controller = (GameManager)target;
        GUILayout.BeginHorizontal("");
        if (GUILayout.Button("Start"))
        {
            GameController.Instance.StartGame();
        }
        if (GUILayout.Button("Stop"))
        {
           // GameController.Instance. = GameState.GameOver;
        }
        if (GUILayout.Button("Reset"))
        {
          //  GameController.Instance.GameState = GameState.Restarting;
        }
        GUILayout.EndHorizontal();
    }
}
