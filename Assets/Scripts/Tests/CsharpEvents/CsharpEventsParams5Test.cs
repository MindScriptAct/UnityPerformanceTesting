using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsharpEventsParams5Test : TestBase
{

    public event Action<int, string, double, Vector2, MyData> OnEvent5;

    internal override void DoTest()
    {
        if (OnEvent5 != null)
        {
            OnEvent5(5, "Hello", 12.34f, new Vector2(1, 2), new MyData(1, "Hi!"));
        }
    }
}
