using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
  public bool activated;
  private static bool _activated;
  static Text text;
  static string textString = "";
  void Awake()
  {
    _activated = activated;
    text = GetComponent<Text>();
  }
  public static void SetText(string t)
  {
    if (!_activated) return;
    textString += (textString.Length == 0 ? "" : "\n") + t;
    text.text = textString;
  }
}
