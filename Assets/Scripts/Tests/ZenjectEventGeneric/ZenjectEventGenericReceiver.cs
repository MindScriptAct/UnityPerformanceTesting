using Assets.Scripts.Model;
using System;
using UnityEngine;
using Zenject;

public class ZenjectEventGenericReceiver : MonoBehaviour, IInitializable, IDisposable
{
    private int testNr;
    private int testNr1;
    private int testNr5;

    private GenericEventTest eventContainer;

    [Inject]
    private void Construct(GenericEventTest eventContainer)
    {
        //Debug.LogWarning("ZenjectEventGenericReceiver > Construct " + eventContainer + "  [" + this.gameObject.transform.parent.name);
        this.eventContainer = eventContainer;
    }

    public void Initialize()
    {
        //Debug.LogWarning("ZenjectEventGenericReceiver > Initialize " + eventContainer + "  [" + this.gameObject.transform.parent.name);
        eventContainer.TestParam0.AddHandler(HandleParam0);
        eventContainer.TestParam1.AddHandler(HandleParam1);
        eventContainer.TestParam5.AddHandler(HandleParam5);
    }

    public void Dispose()
    {
        //Debug.LogWarning("ZenjectEventGenericReceiver > Dispose " + eventContainer + "  [" + this.gameObject.transform.parent.name);
        eventContainer.TestParam0.RemoveHandler(HandleParam0);
        eventContainer.TestParam1.RemoveHandler(HandleParam1);
        eventContainer.TestParam5.RemoveHandler(HandleParam5);
    }

    public void HandleParam0()
    {
        //Debug.LogWarning($"HandleSignalParam0" + "  [" + "  [" + this.gameObject.transform.parent.name);
        testNr++;
    }
    public void HandleParam1(int data)
    {
        //Debug.LogWarning($"HandleSignalParam1 {data}" + "  [" + "  [" + this.gameObject.transform.parent.name);
        testNr1++;
    }

    public void HandleParam5(int nr, string text, float nr2, Vector2 vector2, MyData myData)
    {
        //Debug.LogWarning($"HandleSignalParam5 {nr} {text} {nr2} {vector2.x} {myData.Text}" + "  [" + this.gameObject.transform.parent.name);
        testNr5++;
    }
}