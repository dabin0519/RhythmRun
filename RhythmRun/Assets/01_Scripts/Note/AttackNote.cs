using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNote : Note
{
    protected override void NoteAction(KeyCode key)
    {
        if (key != _playerInfo.attackKey)
            return;

        if(isCorrect)
        {
            Correct();
        }
    }
}
