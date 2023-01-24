using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenjectSignalReceiver : MonoBehaviour, IInitializable, IDisposable
{
    private int testNr;
    private int testNr1;
    private int testNr5;

    private SignalBus _signalBus;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        //Debug.LogWarning("ZenjectSignalReceiver > Construct " + signalBus + "  [" + this.gameObject.transform.parent.name);
        _signalBus = signalBus;
    }

    public void Initialize()
    {
        //Debug.LogWarning("ZenjectSignalReceiver > Initialize " + _signalBus + "  [" + this.gameObject.transform.parent.name);
        _signalBus.Subscribe<SignalTestParam0>(HandleSignalParam0);
        _signalBus.Subscribe<SignalTestParam1>(HandleSignalParam1);
        _signalBus.Subscribe<SignalTestParam5>(HandleSignalParam5);
    }

    public void Dispose()
    {
        //Debug.LogWarning("ZenjectSignalReceiver > Dispose " + _signalBus + "  [" + this.gameObject.transform.parent.name);
        _signalBus.Unsubscribe<SignalTestParam0>(HandleSignalParam0);
        _signalBus.Unsubscribe<SignalTestParam1>(HandleSignalParam1);
        _signalBus.Unsubscribe<SignalTestParam5>(HandleSignalParam5);
    }

    public void HandleSignalParam0(SignalTestParam0 data)
    {
        //Debug.Log($"HandleSignalParam0" + "  [" + "  [" + this.gameObject.transform.parent.name);
        testNr++;
    }
    public void HandleSignalParam1(SignalTestParam1 data)
    {
        //Debug.Log($"HandleSignalParam1 {data.nr}" + "  [" + "  [" + this.gameObject.transform.parent.name);
        testNr1++;
    }

    public void HandleSignalParam5(SignalTestParam5 data)
    {
        //Debug.Log($"HandleSignalParam5 {data.Nr} {data.Text} {data.Nr2} {data.Vector2.x} {data.MyData.Text}" + "  [" + this.gameObject.transform.parent.name);
        testNr5++;
    }
}