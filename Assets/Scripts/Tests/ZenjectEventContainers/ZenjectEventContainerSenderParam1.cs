using UnityEngine;
using Zenject;

public class ZenjectEventContainerSenderParam1 : TestBase
{
    private ZenjectEventContainer eventContainer;

    private void Start()
    {
        //Debug.LogWarning("ZenjectSignalSenderParam1 > Start");
    }

    [Inject]
    private void Construct(ZenjectEventContainer eventContainer)
    {
        //Debug.LogWarning("ZenjectSignalSenderParam1 > Construct " + signalBus);
        this.eventContainer = eventContainer;
    }

    internal override void DoTest()
    {
        //_signalBus.Fire(new SignalTestParam1(5));
        eventContainer.FireTestParam1(5);
    }
}
