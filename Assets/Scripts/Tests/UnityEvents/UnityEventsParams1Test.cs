using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventsParams1Test : TestBase
{

    public UnityEvent<int> OnEvent1;

    internal override void DoTest()
    {
        OnEvent1.Invoke(5);
    }
}
