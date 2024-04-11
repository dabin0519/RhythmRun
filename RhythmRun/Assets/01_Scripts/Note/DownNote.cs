using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownNote : Note
{
    protected override void Awake()
    {
        base.Awake();

        _playerController.InputAction += NoteAction;
    }

    private void OnDisable()
    {
        _playerController.InputAction -= NoteAction;
    }

    protected override void NoteAction(KeyCode key)
    {
        if (key != _playerInfo.downKey)
            return;

        if (isCorrect)
        {
            ChangeColor();
        }
    }
}
