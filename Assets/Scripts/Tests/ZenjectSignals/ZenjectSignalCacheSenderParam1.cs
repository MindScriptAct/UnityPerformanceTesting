using UnityEngine;
using Zenject;

public class ZenjectSignalCacheSenderParam1 : TestBase
{
    private SignalBus _signalBus;
    private SignalTestParam1 signal = new SignalTestParam1();
    
    private void Start()
    {
        //Debug.LogWarning("ZenjectSignalCacheSenderParam1 > Start");
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        //Debug.LogWarning("ZenjectSignalCacheSenderParam1 > Construct " + signalBus);
        _signalBus = signalBus;
    }

    internal override void DoTest()
    {
        signal.nr = 5;
        _signalBus.Fire(signal);
    }
}
