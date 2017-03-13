using UnityEngine;
using System.Collections;

public class FloatingGameObject : MonoBehaviour
{

  public float floatHeight = 3f;
  public float loopDuration = 4f;
  public LeanTweenType tweenType;
  // Use this for initialization
  void Start()
  {
    transform.position = new Vector3(transform.position.x, transform.position.y - floatHeight * 0.5f, transform.position.z);
    var to = transform.position;
    to.y += floatHeight * 0.5f;
    LeanTween.move(gameObject, to, loopDuration).setEase(tweenType).setLoopPingPong();
  }

}
