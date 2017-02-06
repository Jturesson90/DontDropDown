using UnityEngine;
using System.Collections;

public class SplashEffect : MonoBehaviour
{
  public GameObject splash;
  private GameObject _spawnedSplash;
  private ParticleSystem _splashParticle;

  void Start()
  {
    _spawnedSplash = Instantiate(splash, Vector3.zero, splash.transform.rotation) as GameObject;
    _splashParticle = _spawnedSplash.GetComponent<ParticleSystem>();
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
    _splashParticle.Play();
  }
}
