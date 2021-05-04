using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TestActivator : MonoBehaviour
{
    [SerializeField]
    private TestBase testTriger;

    private TestRunner testRunner;

    private float maxDuration;
    private double totalDuration;
    private long runCount = 0;
    private int intervalDuration;

    // Start is called before the first frame update
    void Start()
    {
        testRunner = Singleton<TestRunner>.Instance;
        Assert.IsNotNull(testTriger, $"testTriger must be set to {gameObject.name}");
    }

    // Update is called once per frame
    void Update()
    {
        var startTime = DateTime.Now;
        var alowedDiference = new TimeSpan(0, 0, 0, 0, intervalDuration);
        do
        {
            testTriger.DoTest();
            runCount++;
        } while (DateTime.Now - startTime < alowedDiference);

        totalDuration += (DateTime.Now - startTime).TotalMilliseconds;


        if (totalDuration > maxDuration)
        {
            testRunner.HandleTestResults(totalDuration, runCount);
        }
        else
        {
            testRunner.HandleTestProgress(totalDuration, runCount);
        }
    }

    internal void StartTest(float testDuration, int intervalDuration)
    {
        runCount = 0;
        totalDuration = 0;
        maxDuration = testDuration;
        this.intervalDuration = intervalDuration;
        gameObject.SetActive(true);
        enabled = true;
    }
}
