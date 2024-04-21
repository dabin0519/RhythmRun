using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoSingleton<KeyManager>
{
    private List<KeyCode> _keyList = new List<KeyCode>();

    private void Awake()
    {
        SettupKey();
    }

    private void SettupKey()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            _keyList.Add(keyCode);
        }
    }

    public KeyCode ListenPressKey()
    {
        foreach(KeyCode k in _keyList)
        {
            if (Input.GetKeyDown(k))
                return k;
        }

        return KeyCode.None;
    }
}
