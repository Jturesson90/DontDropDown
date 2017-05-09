using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Restart))]
public class RestartEditor : Editor
{

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    var controller = (Restart)target;
    if (GUILayout.Button("During"))
    {
      controller.During();
    }
    if (GUILayout.Button("AtStart"))
    {
      controller.AtStart();
    }
  }
}
