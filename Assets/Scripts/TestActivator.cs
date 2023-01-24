using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TestActivator : MonoBehaviour
{
    [SerializeField] private TestBase testTrigger;

    private TestRunner testRunner;

    private float maxDuration;
    private double totalDuration;
    private double iterationDuration;
    private long runCount = 0;
    private long totalRunCount = 0;
    private int intervalDuration;
    private TimeSpan alowedDiference;
    private double runsPerMilisecond;
    private double totalRunsPerMilisecond;

    // Start is called before the first frame update
    void Start()
    {
        testRunner = Singleton<TestRunner>.Instance;
        Assert.IsNotNull(testTrigger, $"testTrigger must be set to {gameObject.name}");
    }

    // Update is called once per frame
    void Update()
    {
        var startTime = DateTime.Now;
        runCount = 0;
        alowedDiference = new TimeSpan(0, 0, 0, 0, intervalDuration);
        do
        {
            testTrigger.DoTest();
            runCount++;
        } while (DateTime.Now - startTime < alowedDiference);

        totalRunCount += runCount;

        iterationDuration = (DateTime.Now - startTime).TotalMilliseconds;
        totalDuration += iterationDuration;

        //runsPerMilisecond = runCount / iterationDuration;
        //totalRunsPerMilisecond = totalRunCount / totalDuration;

        //Debug.Log($"Itteration : {runCount}({totalRunCount}) / {iterationDuration}({totalDuration}) / {runsPerMilisecond}({totalRunsPerMilisecond})  [{testRunner.CurrentTestName}]");

        if (totalDuration > maxDuration)
        {
            testRunner.HandleTestResults(totalDuration, totalRunCount);
        }
        else
        {
            testRunner.HandleTestProgress(totalDuration, totalRunCount);
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
