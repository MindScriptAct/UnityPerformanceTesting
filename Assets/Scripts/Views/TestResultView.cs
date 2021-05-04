using Assets.Scripts.Model;
using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestResultView : MonoBehaviour
{
    [SerializeField]
    private Text testLabel;

    [SerializeField]
    private Text testProgress;

    [SerializeField]
    private InputField testResults;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AssertFields(testLabel, testProgress, testResults);
    }

    // Update is called once per frame
    void Update()
    {
    }

    internal void ShowAllDone()
    {
        testLabel.text = "All tests done.";
        testProgress.text = "";
    }

    internal void ShowProgress(double totalDuration, long runCount)
    {
        testProgress.text = $"Running ...  time:{totalDuration}ms  count:{runCount}";
    }

    internal void ShowCurrentTestName(string name)
    {
        testLabel.text = name;
    }

    internal void ShowResults(TestModel testModel)
    {
        string result = "";

        TestData controlTest = testModel.TestDatas[0];

        foreach (TestData test in testModel.TestDatas)
        {
            result += test.GetSumary(controlTest);
        }
        testResults.text = result;
    }
}
