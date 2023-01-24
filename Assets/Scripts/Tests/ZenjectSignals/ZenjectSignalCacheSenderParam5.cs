using Assets.Scripts.Model;
using UnityEngine;
using Zenject;

public class ZenjectSignalCacheSenderParam5 : TestBase
{
    private SignalBus _signalBus;
    private SignalTestParam5 signal = new SignalTestParam5();

    private void Start()
    {
        //Debug.LogWarning("ZenjectSignalCacheSenderParam5 > Start");
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        //Debug.LogWarning("ZenjectSignalCacheSenderParam5 > Construct " + signalBus);
        _signalBus = signalBus;
    }

    internal override void DoTest()
    {
        signal.Nr = 5;
        signal.Text = "Hello";
        signal.Nr2 = 12.34f;
        signal.Vector2 = new Vector2(1, 2);
        signal.MyData = new MyData(1, "hi!");

        _signalBus.Fire(signal);
    }
}
