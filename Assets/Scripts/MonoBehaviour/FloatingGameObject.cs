using UnityEngine;
using System.Collections;

public class FloatingGameObject : MonoBehaviour
{

  public float floatHeight = -0.5f;
  public float loopDuration = 6f;
  public LeanTweenType tweenType = LeanTweenType.pingPong;
  // Use this for initialization
  void Start()
  {
    transform.position = new Vector3(transform.position.x, transform.position.y - floatHeight * 0.5f, transform.position.z);
    var to = transform.position;
    to.y += floatHeight * 0.5f;
    LeanTween.move(gameObject, to, loopDuration).setEase(tweenType).setLoopPingPong();
  }

}
