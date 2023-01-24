using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInContainerEventHub : MonoBehaviour
{
    internal T GetEventContainer<T>() where T : MyActionType, new()
    {
        if (MyActionContainer<T>.Container == null) MyActionContainer<T>.Container = new T();
        return MyActionContainer<T>.Container;
    }

    internal T1 GetEvent1Container<T1, P1>() where T1 : MyAction1Type<P1>, new()
    {
        if (MyAction1Container<T1, P1>.Container == null) MyAction1Container<T1, P1>.Container = new T1();
        return MyAction1Container<T1, P1>.Container;
    }

    internal T5 GetEvent5Container<T5, P1, P2, P3, P4, P5>() where T5 : MyAction5Type<P1, P2, P3, P4, P5>, new()
    {
        if (MyAction5Container<T5, P1, P2, P3, P4, P5>.Container == null) MyAction5Container<T5, P1, P2, P3, P4, P5>.Container = new T5();
        return MyAction5Container<T5, P1, P2, P3, P4, P5>.Container;
    }

    internal void RegisterEventHandler<T>(Action handleMyData) where T : MyActionType, new()
    {
        if (MyActionContainer<T>.Container == null) MyActionContainer<T>.Container = new T();
        MyActionContainer<T>.Container.Event += handleMyData;
    }
    internal void RegisterEventHandlerParam1<T1, P1>(Action<P1> handleMyData) where T1 : MyAction1Type<P1>, new()
    {
        if (MyAction1Container<T1, P1>.Container == null) MyAction1Container<T1, P1>.Container = new T1();
        MyAction1Container<T1, P1>.Container.Event += handleMyData;
    }
    internal void RegisterEventHandlerParam5<T5, P1, P2, P3, P4, P5>(Action<P1, P2, P3, P4, P5> handleMyData) where T5 : MyAction5Type<P1, P2, P3, P4, P5>, new()
    {
        if (MyAction5Container<T5, P1, P2, P3, P4, P5>.Container == null) MyAction5Container<T5, P1, P2, P3, P4, P5>.Container = new T5();
        MyAction5Container<T5, P1, P2, P3, P4, P5>.Container.Event += handleMyData;
    }

    private static class MyActionContainer<T> where T : MyActionType
    {
        public static T Container;
    }
    private static class MyAction1Container<T1, P1> where T1 : MyAction1Type<P1>
    {
        public static T1 Container;
    }
    private static class MyAction5Container<T5, P1, P2, P3, P4, P5> where T5 : MyAction5Type<P1, P2, P3, P4, P5>
    {
        public static T5 Container;
    }
}
