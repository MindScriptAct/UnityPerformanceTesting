using Assets.Scripts.Model;
using Assets.Scripts.Tests.CustomStringMessenger;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveViewMediator : ViewMediatorBehaviour
{

    void OnEnable()
    {
        RegisterHandler(MessageNames.TestParam0, HandleParam0Test);
        RegisterHandler(MessageNames.TestParam1, HandleParam1Test);
        RegisterHandler(MessageNames.TestParam5, HandleParam5Test);
    }

    void HandleParam0Test(object payload = null)
    {
        //Debug.Log("HandleParam0Test");
    }

    void HandleParam1Test(object payload = null)
    {
        //Debug.Log("HandleParam1Test " + (int)payload);
    }

    void HandleParam5Test(object payload = null)
    {
        DataPack data = (DataPack)payload;
        //Debug.Log($"HandleParam5Test {data.Nr} {data.Text} {data.Nr2} {data.Vector2.x} {data.MyData.Text}");
    }
}
