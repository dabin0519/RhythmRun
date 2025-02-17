using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public bool isCorrect;
    public bool isHidden;
    public float moveSpeed;

    protected PlayerController _playerController;
    protected PlayerInfoSO _playerInfo;
    protected SpriteRenderer _noteSpriteRenderer;
    protected HitNote _hitObject;
    protected Vector3 _startScale = new Vector3(2, 2, 1);
    protected Vector3 _endScale = new Vector3(1, 1, 1);
    protected float _distance;
    protected float _percent;
    protected bool _isOneCheck;

    protected virtual void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerInfo = _playerController.PlayerInfo;
        _noteSpriteRenderer = GetComponent<SpriteRenderer>();

        if(!isHidden)
        {
            _hitObject = transform.Find("Hit").GetComponent<HitNote>();
            _hitObject.transform.localScale = _startScale;
            _hitObject.gameObject.SetActive(false);
        }

        _percent = 1;
        _distance = Mathf.Abs(_playerController.transform.position.x);

        if (moveSpeed == 0)
            moveSpeed = _playerInfo.moveSpeed;  // 따로 속도를 설정안해주면 기본 이동속도로 따라간다.

        _playerController.InputAction += NoteAction;
    }

    protected virtual void OnDisable()
    {
        _playerController.InputAction -= NoteAction;
    }

    protected virtual void Update()
    {
        Movement();
        CheckDie();
        CheckCorrect();
        CalculatePercent();

        if (!isHidden)
        {
            ChangeScale();
        }
    }

    private void CalculatePercent()
    {
        float distance = Mathf.Abs(_playerController.transform.position.x - transform.position.x);
        _percent = distance / _distance;
    }

    private void CheckCorrect()
    {
        if (_isOneCheck)
            return;

        if(_percent < 0.12f)
        {
            _isOneCheck = true;
            isCorrect = true;
        }
    }

    private bool _isHitNoteOn;

    private void ChangeScale()
    {
        if(transform.position.x < _playerController.transform.position.x)
        {
            return;
        }
        else if(transform.position.x < 0f)
        {
            if(!_isHitNoteOn)
            {
                _isHitNoteOn = true;
                _hitObject.gameObject.SetActive(true);
            }

            Vector3 scale = Vector3.Lerp(_endScale, _startScale, _percent);
            _hitObject.transform.localScale = scale;
        }
    }

    private void CheckDie()
    {
        if(transform.position.x < -10)
        {
            Destroy(gameObject);

            if(isCorrect)
            {
                NoteManager.Instance.Miss++;
            }
        }
    }

    protected abstract void NoteAction(KeyCode key);

    protected virtual void Correct()
    {
        if(!isHidden)
        {
            ChangeColor();
        }
        else
        {
            Debug.Log("숨겨진 박자를 맞췄어요");
        }

        isCorrect = false;

        if(_percent < 0.02f)
        {
            NoteManager.Instance.Perfect++;
        }
        else if( _percent < 0.05f)
        {
            NoteManager.Instance.Good++;
        }
        else if(_percent < 0.08f)
        {
            NoteManager.Instance.Normal++;
        }
        else if(_percent < 0.12f)
        {
            NoteManager.Instance.Bad++;
        }

    }

    protected virtual void ChangeColor()
    {
        _noteSpriteRenderer.color = Color.gray;
    }

    protected virtual void Movement()
    {
        Vector3 moveVec = Vector2.left * moveSpeed * Time.deltaTime;
        transform.position += moveVec;
    }
}
