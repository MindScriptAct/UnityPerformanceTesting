using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySendMessageParams0Test : TestBase
{

    [SerializeField]
    private GameObject messageReceiver;

    internal override void DoTest()
    {
        messageReceiver.SendMessage("HandleMessageParam0");
    }
}
