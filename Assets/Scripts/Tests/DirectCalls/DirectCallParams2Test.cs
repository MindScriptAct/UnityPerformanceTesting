using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectCallParams2Test : TestBase
{

	[SerializeField]
	private CallReceiver callReceiver;

	internal override void DoTest()
	{
		callReceiver.TrigerMethod2(5, "Hello");
	}
}
