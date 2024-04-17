using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInfoSO _playerInfo;

    [Header("--Info--")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _attackTrm;
    [SerializeField] private LayerMask _whatIsEnemy;

    [Header("--Effect--")]
    [SerializeField] private Effect _slideEffect;
    [SerializeField] private Effect _jumpEffect;
    [SerializeField] private Effect _landEffect;
    [SerializeField] private Effect _downEffect;
    [SerializeField] private Effect _groundAttackEffect;

    [Header("--Event--")]
    public UnityEvent JumpEvent;
    public UnityEvent SlideEvent;
    public UnityEvent DownEvent;
    public UnityEvent LandEvent;
    public UnityEvent GroundAttackEvent;

    public System.Action<KeyCode> InputAction;

    public PlayerInfoSO PlayerInfo => _playerInfo;

    private CapsuleCollider2D _playerCollider;
    private PlayerAnimation _playerAnimation;
    private Rigidbody2D _playerRigidbody;

    private Vector2 _colliderSize;
    private Vector2 _colliderOffset;
    
    private bool _isJump;
    private bool _isDoubelJump;
    private bool _isSlide;
    private bool _isDown;
    private bool _isPause;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<CapsuleCollider2D>();

        _colliderSize = _playerCollider.size;
        _colliderOffset = _playerCollider.offset;
        _slideEffect.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isPause)
            return;
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

        if(Input.GetKeyDown(_playerInfo.attackKey))
        {
            if(IsGroundDected())
            {
                GroundAttack();
            }
        }
    }

    private void GroundAttack()
    {
        InputAction?.Invoke(_playerInfo.attackKey);
        GroundAttackEvent?.Invoke();
        SpawnEffect(_groundAttackEffect, 0.8f, _attackTrm.position);

        if (IsEnemyHit())
        {
            Debug.Log("이거 적이 맞았어용");
        }
    }

    private void Down()
    {
        _isDown = true;
        InputAction?.Invoke(_playerInfo.downKey);
        DownEvent?.Invoke();
        Vector3 velocity = new Vector3(_playerRigidbody.velocity.x, _playerInfo.downForce);
        SetVelocity(velocity);
    }

    private void Slide()
    {
        _isSlide = true;
        _slideEffect.gameObject.SetActive(true);
        SlideEvent?.Invoke();
        StartCoroutine(WaitCoroutine(_playerInfo.slideTime, () =>
        {
            _isSlide = false;
        }));

        StartCoroutine(WaitCoroutine(_playerInfo.slideDuration + 0.2f, () =>
        {
            _slideEffect.gameObject.SetActive(false);
            _playerCollider.size = _colliderSize;
            _playerCollider.offset = _colliderOffset;
        }));
        _playerAnimation.Slide();
        _playerCollider.offset = new Vector2(0, -0.8f);
        _playerCollider.size = new Vector2(_playerCollider.size.x, 1f);

        InputAction?.Invoke(_playerInfo.slideKey);
    }

    private void Jump(bool isDoubleJump = false)
    {
        float jumpForce = isDoubleJump ? _playerInfo.doubleJumpForce : _playerInfo.jumpForce;
        Vector3 velocity = new Vector3(_playerRigidbody.velocity.x, jumpForce);
        SetVelocity(velocity);
        JumpActions();
    }

    private void JumpActions()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - _colliderSize.y / 2f);
        SpawnEffect(_jumpEffect, 0.8f, spawnPos);
        JumpEvent?.Invoke();
        InputAction?.Invoke(_playerInfo.jumpKey);
    }

    private void Land()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - _colliderSize.y / 2f - 0.1f);
        Effect efffect = _isDown ? _downEffect : _landEffect;
        SpawnEffect(efffect, 0.8f, spawnPos);

        if (!_isDown)
            LandEvent?.Invoke();

        _playerAnimation.Land();
        _isDoubelJump = false;
        _isJump = false;
        _isDown = false;
    }

    private void SpawnEffect(Effect effect, float lifeTime, Vector3 spawnPos)
    {
        Effect newEffect = Instantiate(effect, spawnPos, Quaternion.identity);
        Destroy(newEffect.gameObject, lifeTime);
    }

    public bool IsGroundDected()
    {
        float distance = _isJump ? _playerInfo.jumpCheckDistance : _playerInfo.checkLandDistance;
        return Physics2D.Raycast(_groundChecker.position, Vector2.down, distance, _whatIsGround);
    }

    public bool IsEnemyHit() => Physics2D.CircleCast(_attackTrm.position, _playerInfo.attackRadius, Vector2.right, _playerInfo.attackDistance, _whatIsEnemy);

    private void SetVelocity(Vector3 velocity)
    {
        _playerRigidbody.velocity = velocity;
    }

    private void OnDrawGizmos()
    {
        float distance = _isJump ? _playerInfo.jumpCheckDistance : _playerInfo.checkLandDistance;
        Debug.DrawRay(_groundChecker.position, Vector2.down * distance, Color.red);

        Debug.DrawRay(_attackTrm.position, Vector2.right * _playerInfo.attackDistance, Color.red);
    }

    private IEnumerator WaitCoroutine(float duration, System.Action callBack)
    {
        yield return new WaitForSeconds(duration);
        callBack?.Invoke();
    }
}
