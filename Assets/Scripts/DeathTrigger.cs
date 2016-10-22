using UnityEngine;
using System.Collections;
using System;

public class DeathTrigger : MonoBehaviour
{
  public bool debugActive = false;
  private bool _triggered;
  void Awake()
  {
    GameController.OnGameStateChanged += OnGameStateChanged;
  }

  private void OnGameStateChanged()
  {
    if (debugActive) return;
    if (GameController.Instance.GameState == GameState.Playing)
      _triggered = false;
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag.Equals("Player"))
    {
      if (_triggered) return;
      print("DeathTrigger: OnTriggerEnter");
      GameController.Instance.Death();
    }
  }
}
