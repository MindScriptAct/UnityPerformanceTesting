using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySendMessageParams1Test : TestBase
{

    [SerializeField]
    private GameObject messageReceiver;

    internal override void DoTest()
    {
        messageReceiver.SendMessage("HandleMessageParam1", 5);
    }
}
