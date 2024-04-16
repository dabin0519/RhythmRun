using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoSingleton<NoteManager>
{
    public void Log(string value)
    {
        Debug.Log(value);
    }
}
