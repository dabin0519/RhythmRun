using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : ButtonController
{
    [SerializeField] private Sprite _muteSprite;
    [SerializeField] private AudioSource _source;

    private Sprite _currentSprite;
    private Image _image;
    private bool _isMute;

    protected override void Awake()
    {
        _image = GetComponent<Image>();
        _currentSprite = _image.sprite;
        _isMute = false;
    }

    public override void Click()
    {
        base.Click();
        _isMute = !_isMute;
        _source.mute = _isMute;

        if(_isMute)
            _image.sprite = _muteSprite;
        else
            _image.sprite = _currentSprite;
    }
}
