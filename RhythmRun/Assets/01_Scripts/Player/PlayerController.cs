using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInfoSO _playerInfo;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private GameObject _slideEffect;

    public UnityEvent JumpEvent;
    public UnityEvent SlideEvent;
    public UnityEvent DownEvent;

    public System.Action JumpAction;
    public System.Action SlideAction;
    public System.Action DownAction;

    public PlayerInfoSO PlayerInfo => _playerInfo;

    private CapsuleCollider2D _playerCollider;
    private PlayerAnimation _playerAnimation;
    private Rigidbody2D _playerRigidbody;

    private Vector2 _colliderSize;
    private Vector2 _colliderOffset;
    
    private bool _isJump;
    private bool _isDoubelJump;
    private bool _isSlide;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<CapsuleCollider2D>();

        _colliderSize = _playerCollider.size;
        _colliderOffset = _playerCollider.offset;
        _slideEffect.SetActive(false);
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
            Land();
        }

        if(_isDoubelJump && IsGroundDected())
        {
            Land();
        }
    }

    private void PlayerInput()
    {
        if(Input.GetKeyDown(_playerInfo.jumpKey))
        {
            if (IsGroundDected())
            {
                StartCoroutine(WaitCoroutine(0.2f, () =>
                {
                    _isJump = true;
                }));
                Jump();
            }
            if (!_isDoubelJump && !IsGroundDected())
            {
                _isDoubelJump = true;
                Jump(true);
            }
        }

        if (!_isSlide && Input.GetKeyDown(_playerInfo.slideKey))
        {
            Slide();
        }

        if(Input.GetKeyDown(_playerInfo.downKey))
        {
            if(!IsGroundDected())
                Down();
        }
    }

    private void Down()
    {
        DownAction?.Invoke();
        Vector3 velocity = new Vector3(_playerRigidbody.velocity.x, _playerInfo.downForce);
        SetVelocity(velocity);
    }

    private void Slide()
    {
        _isSlide = true;
        _slideEffect.SetActive(true);
        SlideEvent?.Invoke();
        StartCoroutine(WaitCoroutine(_playerInfo.slideTime, () =>
        {
            _isSlide = false;
        }));

        StartCoroutine(WaitCoroutine(_playerInfo.slideDuration + 0.2f, () =>
        {
            _slideEffect.SetActive(false);
            _playerCollider.size = _colliderSize;
            _playerCollider.offset = _colliderOffset;
        }));
        _playerAnimation.Slide();
        _playerCollider.offset = new Vector2(0, -0.8f);
        _playerCollider.size = new Vector2(_playerCollider.size.x, 1f);

        SlideAction?.Invoke();
    }

    private void Jump(bool isDoubleJump = false)
    {
        float jumpForce = isDoubleJump ? _playerInfo.doubleJumpForce : _playerInfo.jumpForce;
        Vector3 velocity = new Vector3(_playerRigidbody.velocity.x, jumpForce);
        SetVelocity(velocity);
        _playerAnimation.Jump();
        JumpAction?.Invoke();
    }

    private void Land()
    {
        _isJump = false;
        _isDoubelJump = false;
        _playerAnimation.Land();
    }

    public bool IsGroundDected()
    {
        float distance = _isJump ? _playerInfo.jumpCheckDistance : _playerInfo.checkLandDistance;
        return Physics2D.Raycast(_groundChecker.position, Vector2.down, distance, _whatIsGround);
    }

    private void SetVelocity(Vector3 velocity)
    {
        _playerRigidbody.velocity = velocity;
    }

    private void OnDrawGizmos()
    {
        float distance = _isJump ? _playerInfo.jumpCheckDistance : _playerInfo.checkLandDistance;
        Debug.DrawRay(_groundChecker.position, Vector2.down * distance, Color.red);
    }

    private IEnumerator WaitCoroutine(float duration, System.Action callBack)
    {
        yield return new WaitForSeconds(duration);
        callBack?.Invoke();
    }
}
