using Assets.Scripts.Model;
using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TestResultView : MonoBehaviour
{
    [SerializeField] private Text testLabel;

    [SerializeField] private Text testProgress;

    [SerializeField] private ResultPanelView basePanelView;
    [SerializeField] private ResultPanelView resultPanelView;


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.AssertFields(testLabel, testProgress, testResults);
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
        //string result = "";


        List<TestResultData> baseDatas = new List<TestResultData>();
        foreach (TestData item in testModel.BaseDatas)
        {
            baseDatas.Add(CreateTestResultData(item, item));
        }
        basePanelView.ShowResult(baseDatas);

        List<TestResultData> resultDatas = new List<TestResultData>();
        foreach (TestData item in testModel.TestDatas)
        {
            TestData controlTest = testModel.BaseDatas.FirstOrDefault(t => t.Type == item.Type);
            if (controlTest == null)
            {
                Debug.LogError(" Controll data not found for test : " + item.Name);
            }
            resultDatas.Add(CreateTestResultData(item, controlTest));
        }
        resultPanelView.ShowResult(resultDatas);
    }

    private TestResultData CreateTestResultData(TestData test, TestData controlTest)
    {
        return new TestResultData()
        {
            CouplingType = test.CouplingModeName,
            TestName = test.Name,
            RunCount = test.RunCountSumText,
            TotalActionCount = test.TotalActionCount,
            TotalDuration = test.TotalDuration,
            ActionsPerSec = test.ActionsPerSec,
            Performance = test.GetPerformanceComparedTo(controlTest)
        };
    }

    internal string GetText(TestModel testModel)
    {
        var strnigBuilder = new StringBuilder();

        strnigBuilder.AppendLine($"Base ##############################################################################################");
        strnigBuilder.AppendLine($"Type\tName\tRun Count Sum\tTotal run count\tDuration sec \t Actions/Sec\tPerformance %");
        foreach (TestData item in testModel.BaseDatas)
        {
            strnigBuilder.AppendLine($"{item.CouplingModeName}\t{item.Name}\t{item.RunCountSumText}\t{item.TotalActionCount}\t{item.TotalDuration}\t {item.ActionsPerSec}\t{item.GetPerformanceComparedTo(item)}");
        }

        strnigBuilder.AppendLine($"Tests #############################################################################################");
        strnigBuilder.AppendLine($"Type\tName\tRun Count Sum\tTotal run count\tDuration sec \t Actions/Sec\tPerformance %");
        foreach (TestData item in testModel.TestDatas)
        {
            TestData controlTest = testModel.BaseDatas.FirstOrDefault(t => t.Type == item.Type);
            strnigBuilder.AppendLine($"{item.CouplingModeName}\t{item.Name}\t{item.RunCountSumText}\t{item.TotalActionCount}\t{item.TotalDuration}\t {item.ActionsPerSec}\t{item.GetPerformanceComparedTo(controlTest)}");
        }

        return strnigBuilder.ToString();
    }
}