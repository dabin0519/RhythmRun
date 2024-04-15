using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    [SerializeField] private NoteInfoSO _noteInfo;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private Note _jumpNote;
    [SerializeField] private Note _slideNote;
    [SerializeField] private Note _downNote;

    private PlayerController _playerController;
    private CapsuleCollider2D _playerCollider;
    private PlayerInfoSO _playerInfo;
    private bool _isOnRecord;
    private bool _isNextSlide;
    private float _recordTime = 0;

    private void Start()
    {
        _playerController = _playerTrm.GetComponent<PlayerController>();
        _playerCollider = _playerTrm.GetComponent<CapsuleCollider2D>();
        _playerInfo = _playerController.PlayerInfo; 
        _playerController.InputAction += InputKey;
        _timerText.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _playerController.InputAction -= InputKey;
    }

    private void InputKey(KeyCode key)
    {
        if (!_isOnRecord)
            return;
        
        NoteInfo newInfo = new();

        newInfo.spawnTime = Time.time - _recordTime;
        _recordTime = Time.time;

        newInfo.spawnYPos = _playerTrm.position.y;

        if(_isNextSlide)
        {
            _isNextSlide = false;
            if(!_playerController.IsGroundDected())
            {
                newInfo.spawnYPos -= 0.8f;
            }
        }

        if (key == _playerInfo.jumpKey)
        {
            newInfo.note = _jumpNote;
        }
        else if (key == _playerInfo.slideKey)
        {
            newInfo.note = _slideNote;
            _isNextSlide = true;
        }
        else if(key == _playerInfo.downKey)
        {
            newInfo.note = _downNote;
        }

       _noteInfo.noteInfoLists.Add(newInfo);
    }

    public void OnRecord()
    {
        _timerText.gameObject.SetActive(true);
        StartCoroutine(WaitCoroutine());
    }

    public void Pause()
    {
        _isOnRecord = false;
        _timerText.gameObject.SetActive(true);
        _timerText.text = "||";
    }

    private IEnumerator WaitCoroutine()
    {
        for(int i = 0; i < 3; i++)
        {
            _timerText.text = $"{3 - i}";
            yield return new WaitForSeconds(1f);
        }
        _isOnRecord = true;
        _recordTime = Time.time;
        _timerText.gameObject.SetActive(false);
    }
}
