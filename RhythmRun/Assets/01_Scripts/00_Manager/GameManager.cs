using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoSingleton<GameManager>
{
    public bool IsPause;

    public void Pause(bool value)
    {
        IsPause = value;

        if(IsPause)
        {
            Time.timeScale = 0.0f;
            SoundManager.Instance.PauseBGM();
        }
        else
        {
            SoundManager.Instance.RestartBGM();
            Time.timeScale = 1.0f;
        }
    }

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
