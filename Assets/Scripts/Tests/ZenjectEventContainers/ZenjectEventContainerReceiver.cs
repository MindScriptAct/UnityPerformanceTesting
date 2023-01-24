using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenjectEventContainerReceiver : MonoBehaviour, IInitializable, IDisposable
{
    private int testNr;
    private int testNr1;
    private int testNr5;

    private ZenjectEventContainer eventContainer;

    [Inject]
    private void Construct(ZenjectEventContainer eventContainer)
    {
        //Debug.LogWarning("ZenjectSignalReceiver > Construct " + signalBus + "  [" + this.gameObject.transform.parent.name);
        this.eventContainer = eventContainer;
    }

    public void Initialize()
    {
        //Debug.LogWarning("ZenjectSignalReceiver > Initialize " + _signalBus + "  [" + this.gameObject.transform.parent.name);

        eventContainer.AddHandlerTestParam0(HandleParam0);
        eventContainer.AddHandlerTestParam1(HandleParam1);
        eventContainer.AddHandlerTestParam5(HandleParam5);
    }

    public void Dispose()
    {
        //Debug.LogWarning("ZenjectSignalReceiver > Dispose " + _signalBus + "  [" + this.gameObject.transform.parent.name);
        eventContainer.RemoveHandlerTestParam0(HandleParam0);
        eventContainer.RemoveHandlerTestParam1(HandleParam1);
        eventContainer.RemoveHandlerTestParam5(HandleParam5);
    }

    public void HandleParam0()
    {
        //Debug.Log($"HandleSignalParam0" + "  [" + "  [" + this.gameObject.transform.parent.name);
        testNr++;
    }
    public void HandleParam1(int data)
    {
        //Debug.Log($"HandleSignalParam1 {data}" + "  [" + "  [" + this.gameObject.transform.parent.name);
        testNr1++;
    }

    public void HandleParam5(int nr, string text, float nr2, Vector2 vector2, MyData myData)
    {
        //Debug.Log($"HandleSignalParam5 {nr} {text} {nr2} {vector2.x} {myData.Text}" + "  [" + this.gameObject.transform.parent.name);
        testNr5++;
    }
}