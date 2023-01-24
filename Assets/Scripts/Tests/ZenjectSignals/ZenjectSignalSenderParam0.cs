using UnityEngine;
using Zenject;

public class ZenjectSignalSenderParam0 : TestBase
{
    private SignalBus _signalBus;

    private void Start()
    {
        //Debug.LogWarning("ZenjectSignalSenderParam0 > Start");
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        //Debug.LogWarning("ZenjectSignalSenderParam0 > Construct " + signalBus);
        _signalBus = signalBus;
    }

    internal override void DoTest()
    {
        //Debug.LogWarning("ZenjectSignalSenderParam0 > DoTest ");
        _signalBus.Fire(new SignalTestParam0());
    }
}
