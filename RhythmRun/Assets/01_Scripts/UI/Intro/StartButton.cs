using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : IntroButton
{
    [SerializeField] private string _sceneName;

    public override void Click()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
