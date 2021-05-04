using Assets.Scripts.Tests.CustomStringMessenger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send0ParamsViewMediator : ViewMediatorBehaviour
{
    void Start()
    {
    }

    internal override void DoTest()
    {
        SendStringMessage(MessageNames.TestParam0);
    }

}
