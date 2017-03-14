using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    public GameObject LightningManagerPrefab;
    public GameObject GameManagerPrefab;
    //public GameObject inputManager;
    public GameObject UIManagerPrefab;

    void Awake()
    {
        if (!GameManager.Instance)
        {
            Instantiate(GameManagerPrefab, transform);
        }
        else
        {
            GameManager.Instance.gameObject.transform.parent = transform;
        }
        if (!LightningManager.Instance)
        {
            Instantiate(LightningManagerPrefab, transform);
        }
        else
        {
            LightningManager.Instance.gameObject.transform.parent = transform;
        }
        if (!UIManager.Instance)
        {
            Instantiate(UIManagerPrefab, transform);
        }
        else
        {
            UIManager.Instance.gameObject.transform.parent = transform;
        }


    }
}
