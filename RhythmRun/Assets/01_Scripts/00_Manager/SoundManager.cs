using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource _bgmSource;
    private AudioSource _sfxSource;

    public AudioSource bgmSource => _bgmSource;
    public AudioSource sfxSource => _sfxSource;

    private bool _isFinish;

    private void Awake()
    {
        _bgmSource = GetComponent<AudioSource>();
        _sfxSource = transform.Find("SFX").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPause && !_bgmSource.isPlaying)
        {
            if (_isFinish)
                return;

            _isFinish = true;
            UIContoller.Instance.ScorePanelOn();
        }
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
