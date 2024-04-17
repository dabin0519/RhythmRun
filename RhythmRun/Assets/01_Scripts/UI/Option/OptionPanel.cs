using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Start()
    {
        _bgmSlider.value = SoundManager.Instance.bgmSource.volume;
        _sfxSlider.value = SoundManager.Instance.sfxSource.volume;
    }
}
