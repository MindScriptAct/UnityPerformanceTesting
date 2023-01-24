using Assets.Scripts.Model;
using UnityEngine;
using Zenject;

public class ZenjectEventContainerSenderParam5 : TestBase
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
        eventContainer.FireTestParam5(5, "Hello", 12.34f, new Vector2(1, 2), new MyData(1, "hi!"));


        //eventContainer.PublicRunTestParam(54, )
    }
}
