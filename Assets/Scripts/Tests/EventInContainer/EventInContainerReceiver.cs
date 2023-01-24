using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInContainerReceiver : MonoBehaviour
{
    public EventInContainerEventHub eventHub;
    
    private int testNr;
    private int testNr1;
    private int testNr5;

    private void Start()
    {
        eventHub.RegisterEventHandler<MyEventContainerParam0>(HandleMyEventParam0);
        eventHub.RegisterEventHandlerParam1<MyEventContainerParam1, int>(HandleMyEventParam1);
        eventHub.RegisterEventHandlerParam5<MyEventContainerParam5, int, string, double, Vector2, MyData>(HandleMyEventParam5);
    }

    private void HandleMyEventParam0()
    {
        //Debug.LogWarning("Shit gets done...");
        testNr++;
    }

    private void HandleMyEventParam1(int dataIn)
    {
        //Debug.LogWarning("Shit realy gets done... " + dataIn);
        testNr1++;
    }

    private void HandleMyEventParam5(int nr, string text, double nr2, Vector2 vector2, MyData data)
    {
        //Debug.LogWarning("A lot of Shit realy gets done... " + text);
        testNr5++;
    }

}