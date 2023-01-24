using Assets.Scripts.Model;
using UnityEngine;
using Zenject;

public class ZenjectEventGenericSenderParam5 : TestBase
{
    private GenericEventTest eventContainer;

    private void Start()
    {
        //Debug.LogWarning("ZenjectSignalSenderParam1 > Start");
    }

    [Inject]
    private void Construct(GenericEventTest eventContainer)
    {
        //Debug.LogWarning("ZenjectSignalSenderParam1 > Construct " + eventContainer);
        this.eventContainer = eventContainer;
    }

    internal override void DoTest()
    {
        //_signalBus.Fire(new SignalTestParam1(5));
        eventContainer.TestParam5.Invoke(5, "Hello", 12.34f, new Vector2(1, 2), new MyData(1, "hi!"));


        //eventContainer.PublicRunTestParam(54, )
    }
}
