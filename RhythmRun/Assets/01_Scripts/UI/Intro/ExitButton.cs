using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : IntroButton
{
    public override void Click()
    {
        Application.Quit();
    }
}
