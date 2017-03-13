using UnityEngine;
using System.Collections;
using UnityEditor;

public class ClearPlayerPrefs : ScriptableWizard
{
  [MenuItem("Tools/Delete all Playerprefs")]
  static void ClearPlayerPrefsWizard()
  {
    PlayerPrefs.DeleteAll();
  }
}
