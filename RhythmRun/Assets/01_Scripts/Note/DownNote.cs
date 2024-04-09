using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownNote : Note
{
    protected override void Awake()
    {
        base.Awake();

        _playerController.DownAction += NoteAction;
    }

    protected override void NoteAction()
    {
        if (isCorrect)
        {
            ChangeColor();
        }
    }
}
