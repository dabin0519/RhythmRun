using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideNote : Note
{
    protected override void NoteAction(KeyCode key)
    {
        if (key != _playerInfo.slideKey)
            return;

        if(isCorrect)
        {
            Correct();
        }
    }
}
