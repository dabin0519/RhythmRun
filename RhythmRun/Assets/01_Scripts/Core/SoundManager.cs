using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource _bgmSource;
    private AudioSource _sfxSource;

    private void Awake()
    {
        _bgmSource = GetComponent<AudioSource>();
        _sfxSource = transform.Find("SFX").GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip sfx)
    {
        _sfxSource.clip = sfx;
        _sfxSource.Play();
    }

    public void PlayBGM(AudioClip bgm)
    {
        _bgmSource.clip = bgm;
        _bgmSource.Play();
    }

    public void PauseBGM()
    {
        _bgmSource.Pause();
    }

    public void RestartBGM()
    {
        _bgmSource.UnPause();
    }
}
