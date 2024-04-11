using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContoller : MonoSingleton<UIContoller>
{
    [SerializeField] private AudioClip _onMouseClip;
    [SerializeField] private AudioClip _clickMouseClip;

    public void PlayMouseOnSound()
    {
        SoundManager.Instance.PlaySFX(_onMouseClip);
    }

    public void PlayMouseClickSound()
    {
        SoundManager.Instance.PlaySFX(_clickMouseClip);
    }
}
