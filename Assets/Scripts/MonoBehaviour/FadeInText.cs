using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Text))]
public class FadeInText : MonoBehaviour
{

  float duration = 0.2f;

  Color _textColor;
  Color _fadedTextColor;
  Text _text;
  RectTransform _rectTransform;

  void Awake()
  {
    _text = GetComponent<Text>();
    _textColor = _text.color;
    _fadedTextColor = _textColor;
    _fadedTextColor.a = 0f;
    _rectTransform = GetComponent<RectTransform>();
  }
  // Use this for initialization
  void Start()
  {
  }
  void OnEnable()
  {
    _text.color = _fadedTextColor;
    LeanTween.colorText(_rectTransform, _textColor, duration);
  }
}
