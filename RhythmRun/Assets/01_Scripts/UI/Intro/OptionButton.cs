using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : IntroButton
{
    [SerializeField] private Image _optionPanel;

    public override void Click()
    {
        _optionPanel.gameObject.SetActive(true);
        UIContoller.Instance.PlayMouseClickSound();
    }
}
