using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpNote : Note
{
    protected override void Awake()
    {
        base.Awake();

        _playerController.JumpAction += NoteAction;
    }

    protected override void NoteAction()
    {
        if(isCorrect)
        {
            ChangeColor();
        }
    }
}
