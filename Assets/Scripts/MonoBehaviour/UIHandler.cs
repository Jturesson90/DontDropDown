using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class UIHandler : MonoBehaviour
{
    protected virtual void Awake()
    {
        GameController.OnGameStateChanged += OnGameStateChanged;
    }

    protected abstract void OnGameStateChanged();

    protected void SetChildrenActive(bool active)
    {
        foreach (Transform item in transform)
        {
            if (item.gameObject.activeSelf != active)
            {
                item.gameObject.SetActive(active);
            }
        }
    }
    protected void SetGameObjectsActiveDelay(List<GameObject> gameObjects, bool active, float waitTime)
    {
        StartCoroutine(Delay(gameObjects, active, waitTime));
    }
    protected IEnumerator Delay(List<GameObject> gameObjects, bool active, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (var child in gameObjects)
        {
            child.SetActive(true);
        }
    }
    void OnDisable()
    {
        GameController.OnGameStateChanged -= OnGameStateChanged;
    }

}
