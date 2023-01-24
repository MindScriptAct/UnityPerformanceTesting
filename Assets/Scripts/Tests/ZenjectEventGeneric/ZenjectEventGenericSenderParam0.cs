using UnityEngine;
using Zenject;

public class ZenjectEventGenericSenderParam0 : TestBase
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
        //Debug.LogWarning("... DoTest...!");
        eventContainer.TestParam0.Invoke();
    }
}
