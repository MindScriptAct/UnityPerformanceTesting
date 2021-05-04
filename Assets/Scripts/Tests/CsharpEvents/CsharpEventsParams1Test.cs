using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsharpEventsParams1Test : TestBase
{

    public event Action<int> OnEvent1;

    internal override void DoTest()
    {
        if (OnEvent1 != null)
        {
            OnEvent1(5);
        }
    }
}
