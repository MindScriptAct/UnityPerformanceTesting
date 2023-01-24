using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankCallTest : TestBase
{
    private int testNr;

    internal override void DoTest()
    {
        //Debug.Log($"BlankCallTest - DoTest");
        testNr++;
    }
}
