using UnityEngine;
using Zenject;

public class ZenjectSignalCacheSenderParam0 : TestBase
{
    private SignalBus _signalBus;
    private SignalTestParam0 signal = new SignalTestParam0();


    private void Start()
    {
        //Debug.LogWarning("ZenjectSignalCacheSenderParam0 > Start");
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        //Debug.LogWarning("ZenjectSignalCacheSenderParam0 > Construct " + signalBus);
        _signalBus = signalBus;
    }

    internal override void DoTest()
    {
        _signalBus.Fire(signal);
    }
}
