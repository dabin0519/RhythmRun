using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class IntroButton : ButtonController
{
    [SerializeField] private float _fillTime;
    [SerializeField] private float _sizeDuration;

    private SlicedFilledImage _fillImage;
    private RectTransform _rectTransform;

    private Vector2 _rectSize;
    private bool _isEnter;
    private float _enterTime = 0;

    protected override void Awake()
    {
        _fillImage = transform.Find("Fill").GetComponent<SlicedFilledImage>();
        _rectTransform = GetComponent<RectTransform>();

        if (_fillImage == null)
            Debug.LogError("자식의 [Fill] 오브젝트를 추가해줘야해");

        _fillImage.fillAmount = 0;
        _rectSize = _rectTransform.sizeDelta;
    }

    protected override void Update()
    {
        if(_isEnter)
        {
            _enterTime += Time.deltaTime;

            if(_enterTime > _fillTime)
            {
                Click();
                UIContoller.Instance.PlayMouseClickSound();
                _isEnter = false;
            }
            else
            {
                _fillImage.fillAmount = _enterTime / _fillTime;
            }
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        UIContoller.Instance.PlayMouseOnSound();

        _isEnter = true;
        _rectTransform.DOSizeDelta(_rectSize * 1.2f, _sizeDuration);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _rectTransform.DOSizeDelta(_rectSize, _sizeDuration);
        _fillImage.fillAmount = 0;
        _isEnter = false;
        _enterTime = 0;
    }
}
