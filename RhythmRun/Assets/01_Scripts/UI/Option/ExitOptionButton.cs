using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOptionButton : ButtonController
{
    public override void Click()
    {
        base.Click();
        Application.Quit();
    }
}
