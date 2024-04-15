using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public bool isCorrect;
    public float moveSpeed;

    protected PlayerController _playerController;
    protected PlayerInfoSO _playerInfo;
    protected SpriteRenderer _noteSpriteRenderer;

    protected virtual void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerInfo = _playerController.PlayerInfo;
        _noteSpriteRenderer = GetComponent<SpriteRenderer>();

        if (moveSpeed == 0)
            moveSpeed = _playerInfo.moveSpeed;  // 따로 속도를 설정안해주면 기본 이동속도로 따라간다.
    }

    protected virtual void Update()
    {
        Movement();
        CheckDie();
    }

    private void CheckDie()
    {
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void NoteAction(KeyCode key);

    protected virtual void ChangeColor()
    {
        _noteSpriteRenderer.color = Color.gray;
    }

    protected virtual void Movement()
    {
        Vector3 moveVec = Vector2.left * moveSpeed * Time.deltaTime;
        transform.position += moveVec;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
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
    }
}
