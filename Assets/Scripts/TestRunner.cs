using Assets.Scripts.Model;
using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestRunner : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Total duration for single test in ms.")]
    [SerializeField]
    private int testDuration = 5000;

    [Tooltip("Frame interval to test in ms.")]
    [SerializeField]
    private int intervalDuration = 1000;

    [Tooltip("Test repeat count.")]
    [SerializeField]
    private int runCount = 5;

    [Header("View")]
    [SerializeField]
    private TestResultView testResultView;

    [Header("Controls")]
    [SerializeField]
    private Button runButton;

    private TestModel testModel;

    private int currenRun = 1;
    private int currenTestId = -1;
    private TestData currentTest;


    // Start is called before the first frame update
    void Start()
    {
        testModel = GetComponent<TestModel>();
        gameObject.AssertFields(testResultView, runButton);

        runButton.onClick.AddListener(StartTests);

        testResultView.ShowResults(testModel);

#if UNITY_EDITOR
        StartTests();
#endif
    }

    public void StartTests()
    {
        runButton.gameObject.SetActive(false);
        RunNextTest();
    }

    private void RerunTests()
    {
        currenTestId = -1;
        currenRun++;
        RunNextTest();
    }

    private void RunNextTest()
    {
        if (currentTest != null)
        {
            currentTest.TestActivator.Disable();
        }
        currenTestId++;
        if (currenTestId < testModel.TestDatas.Length)
        {
            currentTest = testModel.TestDatas[currenTestId];
            currentTest.TestActivator.StartTest(testDuration, intervalDuration);
            testResultView.ShowCurrentTestName($"[{currenRun}/{runCount}]\t{currentTest.Name}");
        }
        else
        {
            if (currenRun < runCount)
            {
                RerunTests();
            }
            else
            {
                testResultView.ShowAllDone();
            }
        }
    }

    internal void HandleTestResults(double totalDuration, long runCount)
    {
        currentTest.AddTestResult(totalDuration, runCount);
        testResultView.ShowProgress(totalDuration, runCount);
        testResultView.ShowResults(testModel);
        RunNextTest();
    }

    internal void HandleTestProgress(double totalDuration, long runCount)
    {
        testResultView.ShowProgress(totalDuration, runCount);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
