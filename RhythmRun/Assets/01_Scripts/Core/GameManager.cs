using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public bool Active;

    public void WaitTime(float duration, System.Action callback)
    {
        StartCoroutine(WaitCoroutine(duration, callback));
    }

    private IEnumerator WaitCoroutine(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }
}
