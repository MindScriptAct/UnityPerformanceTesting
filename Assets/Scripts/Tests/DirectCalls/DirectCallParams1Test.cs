using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectCallParams1Test : TestBase
{

	[SerializeField]
	private CallReceiver callReceiver;

	internal override void DoTest()
	{
		callReceiver.TrigerMethod1(5);
	}
}
