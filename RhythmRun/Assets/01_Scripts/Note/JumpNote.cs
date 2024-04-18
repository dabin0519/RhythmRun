using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpNote : Note
{
    protected override void NoteAction(KeyCode key)
    {
        if (key != _playerInfo.jumpKey)
            return;

        if(isCorrect)
        {
            Correct();
        }
    }
}
