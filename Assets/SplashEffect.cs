using UnityEngine;
using System.Collections;

public class SplashEffect : MonoBehaviour
{
  public ParticleSystem pl;
  void Start()
  {
    print("start");
  }
  void OnTriggerEnter(Collider coll)
  {
    print("mmm");
    if (coll.transform.tag.Equals("Player"))
    {
      pl.transform.position = coll.transform.position;
      pl.gameObject.SetActive(false);
      pl.gameObject.SetActive(true);

    }
  }
}
