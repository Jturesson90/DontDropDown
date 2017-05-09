using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayButtonHandler : ButtonHandler
{
    public override void OnClick()
    {
        UIManager.Instance.OnClick(this);
        GetComponent<Button>().interactable = false;
        GetComponent<Animator>().SetTrigger("Pressed");
    }

    public void Reset()
    {
        //TODO Change Animation to LeanTween
        GetComponent<Button>().interactable = true;
        GetComponent<Animator>().SetTrigger("Normal");
    }
}
