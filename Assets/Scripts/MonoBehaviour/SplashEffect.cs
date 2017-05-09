using UnityEngine;
using System.Collections;

public class SplashEffect : MonoBehaviour
{
    public GameObject splash;
    private WaterSplash _spawnedSplash;

    void Start()
    {
        _spawnedSplash = Instantiate(splash, Vector3.zero, splash.transform.rotation).GetComponent<WaterSplash>();
    }
    private string playerTag = Player.PLAYER_TAG;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag(playerTag))
        {
            Splash(coll.transform.position);
        }
    }

    public void Splash(Vector3 position)
    {
        _spawnedSplash.transform.position = new Vector3(position.x, transform.position.y, position.z);
        _spawnedSplash.Splash();
    }
}
