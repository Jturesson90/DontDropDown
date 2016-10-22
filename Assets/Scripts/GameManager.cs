﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
  public Player player;
  public World world;
  private static GameManager _instance;
  public static GameManager Instance { get { return _instance; } }

  void Awake()
  {
    if (_instance != null)
    {
      Destroy(gameObject);
      return;
    }
    _instance = this;
  }
  void Start()
  {
    var gameController = GameController.Instance;
    gameController.StartMenu();
  }
}