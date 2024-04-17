using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerInfoSO _playerInfo;

    private Animator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = transform.Find("Visual").GetComponent<Animator>();
    }

    public void Slide()
    {
        _playerAnimator.SetTrigger("Slide");
        _playerAnimator.SetBool("IsSlide", true);
        StartCoroutine(WaitCoroutine(_playerInfo.slideDuration, () =>
        {
            _playerAnimator.SetBool("IsSlide", false);
        }));
    }

    public void Jump()
    {
        _playerAnimator.SetTrigger("Jump");
        _playerAnimator.SetBool("IsJump", true);
    }

    public void Land()
    {
        _playerAnimator.SetBool("IsJump", false);
    }

    private IEnumerator WaitCoroutine(float duration, System.Action callBack)
    {
        yield return new WaitForSeconds(duration);
        callBack?.Invoke();
    }
}
