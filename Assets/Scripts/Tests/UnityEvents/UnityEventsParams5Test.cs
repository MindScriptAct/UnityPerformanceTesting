using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventsParams5Test : TestBase
{

    public UnityEvent<DataPack> OnEvent5;

    internal override void DoTest()
    {
        OnEvent5.Invoke(new DataPack(5, "Hello", 12.34f, new Vector2(1, 2), new MyData(1, "Hi!")));
    }
}
