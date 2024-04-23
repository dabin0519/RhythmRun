using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    OPTION,
    SCORE
}

[System.Serializable]
public struct UIPanel
{
    public UIType type;
    public GameObject panel;
}

public class UIContoller : MonoSingleton<UIContoller>
{
    [SerializeField] private AudioClip _onMouseClip;
    [SerializeField] private AudioClip _clickMouseClip;
    [SerializeField] private UIPanel[] _uiPanels;

    private void Awake()
    {
        UIPanelOff();
    }

    private void UIPanelOff()
    {
        foreach(var p in _uiPanels)
        {
            p.panel.SetActive(false);
        }
    }

    public void PlayMouseOnSound()
    {
        if(_onMouseClip != null)
            SoundManager.Instance.PlaySFX(_onMouseClip);
    }

    public void PlayMouseClickSound()
    {
        if(_clickMouseClip != null)
            SoundManager.Instance.PlaySFX(_clickMouseClip);
    }

    public void ScorePanelOn()
    {
        GetPanel(UIType.SCORE).SetActive(true);
        GameManager.Instance.Pause(true);
    }

    private GameObject GetPanel(UIType type)
    {
        foreach(var p in _uiPanels)
        {
            if(p.type == type)
            {
                return p.panel;
            }
        }
        return null;
    }
}
