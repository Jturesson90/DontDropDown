using UnityEngine;
using System.Collections;

public class SplashEffect : MonoBehaviour
{
  public GameObject splash;
  void Start()
  {
  }
  void OnTriggerEnter(Collider coll)
  {
    if (coll.transform.tag.Equals("Player"))
    {
      Splash(coll.transform.position);
    }
  }

  public void Splash(Vector3 position)
  {
    GameObject spawnedSplash = Instantiate(splash, new Vector3(position.x, transform.position.y, position.z), splash.transform.rotation) as GameObject;
    ParticleSystem ps = spawnedSplash.GetComponent<ParticleSystem>();
    Destroy(spawnedSplash, ps.startLifetime);
  }
}
