using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LightningManager))]
public class LightningManagerEditor : Editor
{
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    var controller = (LightningManager)target;
    if (GUILayout.Button("Button"))
    {
      controller.ChangeDayAmbient();
    }

  }
}
