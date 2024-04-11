using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum KeyType
{
    NONE,
    JUMP,
    DOWN,
    SLIDE
}

public class KeySettup : MonoBehaviour
{
    [SerializeField] private PlayerInfoSO _playerInfo;
    [SerializeField] private KeyType _type;

    private TextMeshProUGUI _keyText;
    private bool _isWaitListen;

    private void Awake()
    {
        _keyText = transform.Find("Image").Find("Text").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(_isWaitListen && Input.anyKeyDown)
        {
            KeyCode key = KeyManager.Instance.ListenPressKey();
            _isWaitListen = false;
            SettingKey(key);
        }
    }

    public void KeyListen()
    {
        _keyText.text = "Waiting...";
        _isWaitListen = true;
    }

    private void SettingKey(KeyCode key)
    {
        _keyText.text = key.ToString();
        switch (_type)
        {
            case KeyType.NONE:
                Debug.LogWarning("키타입을 none으로 설정하면 안돼");
                break;
            case KeyType.JUMP:
                _playerInfo.jumpKey = key;
                break;
            case KeyType.DOWN:
                _playerInfo.downKey = key;
                break;
            case KeyType.SLIDE:
                _playerInfo.slideKey = key;
                break;
        }
    }
}