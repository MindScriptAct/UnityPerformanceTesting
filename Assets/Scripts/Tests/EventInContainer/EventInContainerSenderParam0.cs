using Assets.Scripts.Model;
using Assets.Scripts.Tests.CustomStringMessenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInContainerSenderParam0 : TestBase
{

    public EventInContainerEventHub TempContainer;

    private MyEventContainerParam0 data;

    private void Start()
    {
        data = TempContainer.GetEventContainer<MyEventContainerParam0>();
    }

    internal override void DoTest()
    {
        data.Event();
    }
}
