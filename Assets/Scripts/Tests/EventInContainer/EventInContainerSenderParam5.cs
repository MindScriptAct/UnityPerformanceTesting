using Assets.Scripts.Model;
using Assets.Scripts.Tests.CustomStringMessenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInContainerSenderParam5 : TestBase
{

    public EventInContainerEventHub TempContainer;

    private MyEventContainerParam5 data5;

    private void Start()
    {
        data5 = TempContainer.GetEvent5Container<MyEventContainerParam5, int, string, double, Vector2, MyData>();
    }

    internal override void DoTest()
    {
        data5.Event(5, "Hello", 12.34f, new Vector2(1, 2), new MyData(1, "Hi!"));
    }
}
