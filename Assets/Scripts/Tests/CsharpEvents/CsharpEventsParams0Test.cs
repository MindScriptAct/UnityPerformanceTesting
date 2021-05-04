using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsharpEventsParams0Test : TestBase
{

    public event Action OnEvent0;

    internal override void DoTest()
    {
        if (OnEvent0 != null)
        {
            OnEvent0();
        }
    }
}
