using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventsParams0Test : TestBase
{

    public UnityEvent OnEvent0;

    internal override void DoTest()
    {
        OnEvent0.Invoke();
    }
}
