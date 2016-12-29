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
  public static void SetText(string t, bool clear)
  {
    if (!_activated) return;
    if (clear)
      textString = (textString.Length == 0 ? "" : "\n") + t;
    else
      textString += (textString.Length == 0 ? "" : "\n") + t;
    text.text = textString;
  }
  public static void SetText(string t)
  {
    SetText(t, false);
  }
}
