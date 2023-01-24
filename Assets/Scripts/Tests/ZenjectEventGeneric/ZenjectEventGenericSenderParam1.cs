using UnityEngine;
using Zenject;

public class ZenjectEventGenericSenderParam1 : TestBase
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
        eventContainer.TestParam1.Invoke(5);
    }
}
