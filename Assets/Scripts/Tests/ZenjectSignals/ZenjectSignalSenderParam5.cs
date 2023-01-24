using Assets.Scripts.Model;
using UnityEngine;
using Zenject;

public class ZenjectSignalSenderParam5 : TestBase
{
    private SignalBus _signalBus;

    private void Start()
    {
        //Debug.LogWarning("ZenjectSignalSenderParam5 > Start");
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        //Debug.LogWarning("ZenjectSignalSenderParam5 > Construct " + signalBus);
        _signalBus = signalBus;
    }

    internal override void DoTest()
    {
        _signalBus.Fire(new SignalTestParam5(5, "Hello", 12.34f, new Vector2(1, 2), new MyData(1, "hi!")));
    }
}
