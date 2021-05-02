using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectCallParams5Test : TestBase
{

    [SerializeField]
    private CallReceiver callReceiver;

    internal override void DoTest()
    {
        callReceiver.TrigerMethod5(5, "Hello", 12.34f, new Vector2(1, 2), new Vector3(1, 2, 3));
    }
}
