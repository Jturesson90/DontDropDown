using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Restart : MonoBehaviour
{
  public RotatorRestartEffect headerRotationEffect;
  public List<GameObject> atStartRestartGameObjects;
  public List<GameObject> duringRestartGameObjects;
  public float restartDuration = 3f;
  public GameObject[] test;
  [Range(0, 1)]
  public float resetDuring = 0.5f;
  void Start()
  {
   // test = FindObjectsOfType(typeof(IRestartableCommand)) as GameObject[];
  }
  void OnEnable()
  {
    GameController.OnRestart += OnRestart;
  }
  void OnDisable()
  {
    GameController.OnRestart -= OnRestart;
  }
  private void OnRestart()
  {
    print("Restart: OnRestart");
    AtStart();
  }
  public void AtStart()
  {
    if (headerRotationEffect != null)
      headerRotationEffect.ExecuteDuration(restartDuration);
    Invoke("OnFinished", restartDuration);
    Invoke("During", restartDuration * resetDuring);
  }


  private void OnFinished()
  {
    print("Restart: OnFinished");
    GameController.Instance.RestartDone();
  }

  public void During()
  {
    Execute(duringRestartGameObjects);
  }

  void Execute(List<GameObject> list)
  {
    foreach (var item in list)
    {
      IRestartableCommand restartable = item.GetComponent<IRestartableCommand>();
      if (restartable != null && restartable is IRestartableCommand)
      {
        restartable.Execute();
      }

    }
  }
}
