using UnityEngine;
using Zenject;

public class ZenjectSignalSenderParam1 : TestBase
{
    private SignalBus _signalBus;

    private void Start()
    {
        //Debug.LogWarning("ZenjectSignalSenderParam1 > Start");
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        //Debug.LogWarning("ZenjectSignalSenderParam1 > Construct " + signalBus);
        _signalBus = signalBus;
    }

    internal override void DoTest()
    {
        _signalBus.Fire(new SignalTestParam1(5));
    }
}
