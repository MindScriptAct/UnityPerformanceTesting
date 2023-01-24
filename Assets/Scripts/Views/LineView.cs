using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LineView : MonoBehaviour
{
    [SerializeField] private TMP_Text dependencyTypeText;
    [SerializeField] private TMP_Text nameTextText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text totalTimeText;
    [SerializeField] private TMP_Text actiensPerSecText;
    [SerializeField] private TMP_Text performanceText;

    internal void Show(TestResultData testResultData)
    {
        dependencyTypeText.text = testResultData.CouplingType;
        nameTextText.text = testResultData.TestName;
        timeText.text = testResultData.RunCount;
        totalTimeText.text = testResultData.TotalDuration.ToString();
        actiensPerSecText.text = testResultData.ActionsPerSec.ToString();
        performanceText.text = $"{testResultData.Performance} %";
    }
}
