using UnityEngine;
using System.Collections;
using System;

public class DeathTrigger : MonoBehaviour
{
  private bool _triggered;
  void Awake()
  {
    GameController.OnGameStateChanged += OnGameStateChanged;
  }

  private void OnGameStateChanged()
  {
    if (GameController.Instance.GameState == GameState.Playing)
      _triggered = false;
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag.Equals("Player"))
    {
      if (_triggered) return;
      print("DeathTrigger: OnTriggerEnter");
      if (GameController.Instance.GameState == GameState.Playing)
      {
        GameController.Instance.Death();
      }
    }
  }
}
