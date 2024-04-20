using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HitNote : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;

    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0f);

        FadeIn();
    }

    public void FadeIn()
    {
        _spriteRenderer.DOFade(1, _duration).SetEase(_ease);
    }
}
