using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySendMessageParams5StructTest : TestBase
{

    [SerializeField]
    private GameObject messageReceiver;

    internal override void DoTest()
    {
        messageReceiver.SendMessage("HandleMessageParam5Struct", new DataPack(5, "Hello", 12.34f, new Vector2(1, 2), new MyData(1, "hi!")));
    }
}
