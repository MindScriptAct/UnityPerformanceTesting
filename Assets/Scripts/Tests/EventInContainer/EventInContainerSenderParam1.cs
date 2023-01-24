using Assets.Scripts.Model;
using Assets.Scripts.Tests.CustomStringMessenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInContainerSenderParam1 : TestBase
{

    public EventInContainerEventHub TempContainer;

    private MyEventContainerParam1 data2;

    private void Start()
    {
        data2 = TempContainer.GetEvent1Container<MyEventContainerParam1, int>();
    }

    internal override void DoTest()
    {
        data2.Event(5);
    }
}
