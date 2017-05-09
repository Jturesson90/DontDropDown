using UnityEngine;
using System.Collections;

public static class PlayerPrefsManager
{

  const string HIGHSCORE_KEY = "HIGHSCORE_KEY";
  public static void SetHighscore(long time)
  {
    if (GetHighscore() < time)
    {
      PlayerPrefs.SetInt(HIGHSCORE_KEY, (int)time);
    }
  }
  public static long GetHighscore()
  {
    long l = (long)PlayerPrefs.GetInt(HIGHSCORE_KEY, -1);
    return l;
  }
}
