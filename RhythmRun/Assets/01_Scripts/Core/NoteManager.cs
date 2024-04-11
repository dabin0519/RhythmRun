using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private NoteInfoSO _noteInfo;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerController.InputAction += InputKey;
    }

    private void OnDisable()
    {
        _playerController.InputAction -= InputKey;
    }

    private void InputKey(KeyCode key)
    {
        
    }
}
