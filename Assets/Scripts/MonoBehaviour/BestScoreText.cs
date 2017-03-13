using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BestScoreText : MonoBehaviour
{
  Text _text;
  // Use this for initialization
  void Awake()
  {
    _text = GetComponent<Text>();
  }
  public void SetScore(long time)
  {
    _text.text = "Best: " + time.ToFormattedTimeString();
  }
}
