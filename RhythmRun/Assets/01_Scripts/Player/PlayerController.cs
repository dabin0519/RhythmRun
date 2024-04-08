using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInfoSO _playerInfo;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _whatIsGround;

    private PlayerAnimation     _playerAnimation;
    private Rigidbody2D         _playerRigidbody;
    private bool _isJump;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerInput();
        CheckAction();
    }

    private void CheckAction()
    {
        if(_isJump && IsGroundDected())
        {
            _isJump = false;
            _playerAnimation.Land();
        }
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(_playerInfo.jumpKey))
        {
            _isJump = true;
            Jump();
            _playerAnimation.Jump();
        }
        if (Input.GetKeyDown(_playerInfo.slideKey))
        {
            Slide();
            _playerAnimation.Slide();
        }
    }

    private void Slide()
    {

    }

    private void Jump()
    {
        _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, _playerInfo.jumpForce);
    }

    public bool IsGroundDected() =>
        Physics2D.Raycast(_groundChecker.position, Vector2.down, _playerInfo.checkLandDistance, _whatIsGround);

    private void OnDrawGizmos()
    {
        Debug.DrawRay(_groundChecker.position, Vector2.down * _playerInfo.checkLandDistance, Color.red);
    }
}
