using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BackgroundImage : MonoBehaviour
{

  public Color TopColor;
  public Color BottomColor;
  public Color StartTopColor;
  public Color StartBottomColor;

  private Material _material;
  private int _topColorID;
  private int _bottomColorID;
  private string _topColorString = "_TopColor";
  private string _bottomColorString = "_BottomColor";


  private void Awake()
  {
    _material = GetComponent<Image>().material;
  }
  void Start()
  {
    _topColorID = Shader.PropertyToID(_topColorString);
    _bottomColorID = Shader.PropertyToID(_bottomColorString);

    SetTopColor(StartTopColor);
    SetBottomColor(StartBottomColor);
  }

  void SetBottomColor(Color color)
  {
    _material.SetColor(_bottomColorID, color);
  }
  void SetTopColor(Color color)
  {
    _material.SetColor(_topColorID, color);
  }
}
