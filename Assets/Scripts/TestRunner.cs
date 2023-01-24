using Assets.Scripts.Model;
using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
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

    [Tooltip("Interval to warm up each test in ms.")]
    [SerializeField]
    private int warmUpDuration = 500;


    [Tooltip("Test repeat count.")]
    [SerializeField]
    private int runCount = 5;

    [Header("View")][SerializeField] private TestResultView testResultView;

    [SerializeField] private GameObject clonePlaceholder;

    [Header("Controls")][SerializeField] private Button runButton;
    [SerializeField] private Button copyButton;

    private TestModel testModel;

    private int currenRun = 0;
    private int currenTestId = -1;
    private TestData currentTest;
    private GameObject currentTestObject;
    private bool useBase = true;

    public string CurrentTestName => currentTest.Name;


    // Start is called before the first frame update
    void Start()
    {
        testModel = GetComponentInChildren<TestModel>();

        gameObject.AssertFields(testResultView, runButton);
        Assert.IsNotNull(testModel, "TestModel component must be added.");

        runButton.onClick.AddListener(StartTests);
        copyButton.onClick.AddListener(CopyLog);

        copyButton.gameObject.SetActive(false);


#if UNITY_EDITOR
        //StartTests();
#endif
        testResultView.ShowResults(testModel);
    }

    public void StartTests()
    {
        runButton.gameObject.SetActive(false);
        copyButton.gameObject.SetActive(true);
        StartCoroutine(RunNextTest());
    }

    private void CopyLog()
    {
        GUIUtility.systemCopyBuffer = testResultView.GetText(testModel);
    }

    private void RerunTests()
    {
        useBase = true;
        currenTestId = -1;
        currenRun++;
        StartCoroutine(RunNextTest());
    }

    private IEnumerator RunNextTest()
    {
        //Debug.LogWarning(" ............ Destroy(currentTestObject)");
        if (currentTestObject != null)
        {
            Destroy(currentTestObject);
            currentTestObject = null;
        }

        yield return null;

        //Debug.LogWarning(" ............ run new test..");

        currentTest = GetNextTest();


        if (currentTest != null)
        {
            Debug.Log($"\tStarting test {currentTest.Name} {currenRun}/{runCount}");

            currentTestObject = clonePlaceholder.InstantiateChild(currentTest.testPrefab);
            var testActivator = currentTestObject.GetComponent<TestActivator>();

            if (currenRun == 0)
            {
                testActivator.StartTest(warmUpDuration, warmUpDuration);
            }
            else
            {
                testActivator.StartTest(testDuration, intervalDuration);

            }
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

    private TestData GetNextTest()
    {
        currenTestId++;

        if (useBase)
        {
            if (currenTestId < testModel.BaseDatas.Length)
            {
                return testModel.BaseDatas[currenTestId];
            }
            else
            {
                currenTestId = 0;
                useBase = false;
            }
        }

        if (!useBase)
        {
            if (currenTestId < testModel.TestDatas.Length)
            {
                return testModel.TestDatas[currenTestId];
            }
        }
        return null;


    }

    internal void HandleTestResults(double totalDuration, long runCount)
    {
        if (currenRun != 0)
        {
            currentTest.AddTestResult(totalDuration, runCount);
            testResultView.ShowProgress(totalDuration, runCount);
            testResultView.ShowResults(testModel);
        }
        StartCoroutine(RunNextTest());
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