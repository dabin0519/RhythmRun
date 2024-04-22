using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContoller : MonoSingleton<UIContoller>
{
    [SerializeField] private AudioClip _onMouseClip;
    [SerializeField] private AudioClip _clickMouseClip;
    [SerializeField] private GameObject _scorePanel;

    private void Awake()
    {
        _scorePanel.SetActive(false);
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
        _scorePanel.SetActive(true);
        GameManager.Instance.Pause(true);
    }
}
