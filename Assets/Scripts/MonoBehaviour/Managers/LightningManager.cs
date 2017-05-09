using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour
{
  [Header("Day Colors")]
  public Color DayEquatorColor = Color.white;
  public Color DayGroundColor = Color.white;
  public Color DaySkyColor = Color.white;
  [Header("Night Colors")]
  public Color NightEquatorColor = Color.white;
  public Color NightGroundColor = Color.white;
  public Color NightSkyColor = Color.white;

  [Header("")]
  public float AnimationInSeconds = 1f;
  public static LightningManager Instance { get; private set; }

  private BackgroundImage _bgImage;
  private static readonly float DAY_HOURS = 24;
  private float _timeOfDay = 0f;
  float TimeOfDay
  {
    get { return _timeOfDay; }
    set
    {
      _timeOfDay = value > DAY_HOURS ? 0 : value;
      _timeOfDay = Mathf.Clamp(_timeOfDay, 0, DAY_HOURS);
    }
  }
  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    _bgImage = FindObjectOfType<BackgroundImage>();
    ChangeDayAmbient();
  }


  private void OnRestart()
  {
    ChangeDayAmbient();
  }

  public void ChangeDayAmbient()
  {
    TimeOfDay++;
    var procent = TimeOfDay / DAY_HOURS;
    var targetedSkyColor = Color.Lerp(NightGroundColor, DayGroundColor, procent);
    var targetedEquatorColor = Color.Lerp(NightGroundColor, DayGroundColor, procent);
    var targetedGroundColor = Color.Lerp(NightGroundColor, DayGroundColor, procent);
    StartCoroutine(AnimateAmbientColors(targetedSkyColor, targetedEquatorColor, targetedGroundColor));
  }
  IEnumerator AnimateAmbientColors(Color skyTarget, Color equatorTarget, Color groundTarget)
  {
    float percent = 0;
    var startSkyColor = RenderSettings.ambientSkyColor;
    var startEquatorColor = RenderSettings.ambientEquatorColor;
    var startGroundColor = RenderSettings.ambientGroundColor;


    while (percent < 1)
    {
      percent += Time.deltaTime * AnimationInSeconds;
      RenderSettings.ambientSkyColor = Color.Lerp(startSkyColor, skyTarget, percent);
      RenderSettings.ambientEquatorColor = Color.Lerp(startEquatorColor, equatorTarget, percent);
      RenderSettings.ambientGroundColor = Color.Lerp(startGroundColor, groundTarget, percent);
      yield return null;
    }
  }
  private void OnEnable()
  {
    GameController.OnRestart += OnRestart;
  }
  private void OnDisable()
  {
    GameController.OnRestart -= OnRestart;
  }
}
