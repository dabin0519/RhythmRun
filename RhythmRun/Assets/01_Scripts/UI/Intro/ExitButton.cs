using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : IntroButton
{
    protected override void Click()
    {
        Application.Quit();
    }
}
