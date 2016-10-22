using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{

  public GameObject gameManager;
  //public GameObject inputManager;
  public GameObject uiManager;

  void Awake()
  {
    if (!GameManager.Instance)
    {
      Instantiate(gameManager);
    }
    //if (!InputManager.Instance)
    //{
    //  Instantiate(inputManager);
    //}
    if (!UIManager.Instance)
    {
      Instantiate(uiManager);
    }

    Destroy(gameObject);
  }
}
