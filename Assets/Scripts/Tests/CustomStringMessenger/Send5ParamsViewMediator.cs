using Assets.Scripts.Model;
using Assets.Scripts.Tests.CustomStringMessenger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send5ParamsViewMediator : ViewMediatorBehaviour
{
    void Start()
    {
    }

    internal override void DoTest()
    {
        SendStringMessage(MessageNames.TestParam5, new DataPack(5, "Hello", 12.34f, new Vector2(1, 2), new MyData(1, "Hi!")));
    }

}
