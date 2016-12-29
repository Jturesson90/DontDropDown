using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Light))]
public class DayLight : MonoBehaviour
{

  public Color DayColor;
  public Color NightColor;
  public Transform lookAt;
  public Renderer[] emissionObject;
  private Light sun;
  int emissionId;

  private void Awake()
  {
    sun = GetComponent<Light>();
    emissionId = Shader.PropertyToID("_EmissionColor");
  }
  // Use this for initialization
  void Start()
  {

  }
  // Update is called once per frame
  void Update()
  {
    if (lookAt)
    {
      transform.LookAt(lookAt);
      var d = Mathf.Cos(lookAt.eulerAngles.z * Mathf.Deg2Rad);
      if (sun)
      {
        sun.color = Color.Lerp(NightColor, DayColor, d);
      }
      if (emissionObject.Length > 0)
      {
        if (Input.GetKey(KeyCode.Space))
        {
          for (int i = 0; i < emissionObject.Length; i++)
          {
            emissionObject[i].material.EnableKeyword("_EMISSION");
            emissionObject[i].material.SetFloat("_EMISSION", 1);
          }
        }
        else
        {
          for (int i = 0; i < emissionObject.Length; i++)
          {
            emissionObject[i].material.EnableKeyword("_EMISSION");
            emissionObject[i].material.SetFloat("_EMISSION", 0);
          }
        }
      }
    }
  }
}
