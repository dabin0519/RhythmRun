using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideNote : Note
{
    protected override void Awake()
    {
        base.Awake();

        _playerController.SlideAction += NoteAction;
    }

    protected override void NoteAction()
    {
        if(isCorrect)
        {
            Debug.Log("�¾Ҿ��");
            ChangeColor();
        }
    }
}
