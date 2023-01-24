using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectCallParams0Test : TestBase
{

    [SerializeField]
    private CallReceiver callReceiver;

    internal override void DoTest()
    {
        //Debug.Log($"DirectCallParams0Test - DoTest");
        callReceiver.TrigerMethod0();
    }
}
