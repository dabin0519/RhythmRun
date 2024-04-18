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
    protected GameObject _hitObject;
    protected Vector3 _startScale = new Vector3(2, 2, 1);
    protected Vector3 _endScale = new Vector3(1, 1, 1);
    protected float _distance;
    protected float _percent;

    protected virtual void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerInfo = _playerController.PlayerInfo;
        _noteSpriteRenderer = GetComponent<SpriteRenderer>();

        if(!isHidden)
        {
            _hitObject = transform.Find("Hit").gameObject;
            _hitObject.transform.localScale = _startScale;
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
        
        if(!isHidden)
        {
            ChangeScale();
        }
    }

    private void CheckCorrect()
    {
        if(_percent < 0.12f)
        {
            isCorrect = true;
        }
    }

    private void ChangeScale()
    {
        if(transform.position.x < _playerController.transform.position.x)
        {
            return;
        }
        else if(transform.position.x < 0f)
        {
            float distance = Mathf.Abs(_playerController.transform.position.x - transform.position.x);
            _percent = distance / _distance;
            Vector3 scale = Vector3.Lerp(_endScale, _startScale, _percent);
            _hitObject.transform.localScale = scale;
        }
    }

    private void CheckDie()
    {
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void NoteAction(KeyCode key);

    protected virtual void Correct()
    {
        ChangeColor();

        if(_percent < 0.02f)
        {
            Debug.Log("Perfect");
        }
        else if( _percent < 0.05f)
        {
            Debug.Log("Good");
        }
        else if(_percent < 0.08f)
        {
            Debug.Log("Normal");
        }
        else if(_percent < 0.12f)
        {
            Debug.Log("Bad");
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

    /*protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isCorrect = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isCorrect = false;
        }
    }*/
}
