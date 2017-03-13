using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ScoreController))]
public class ScoreControllerEditor : Editor
{
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    var controller = (ScoreController)target;
    GUILayout.BeginHorizontal("");
    if (GUILayout.Button("Start"))
    {
      controller.Start();
    }
    if (GUILayout.Button("Stop"))
    {
      controller.Stop();
    }
    if (GUILayout.Button("Reset"))
    {
      controller.Reset();
    }
    GUILayout.EndHorizontal();
  }
}
