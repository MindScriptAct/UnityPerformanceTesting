using Assets.Scripts.Tests.CustomStringMessenger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send1ParamsViewMediator : ViewMediatorBehaviour
{
    void Start()
    {
    }

    internal override void DoTest()
    {
        SendStringMessage(MessageNames.TestParam1, 5);
    }

}
