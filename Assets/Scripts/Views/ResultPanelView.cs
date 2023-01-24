using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResultPanelView : MonoBehaviour
{
    [SerializeField] private GameObject linePerefab;

    private List<LineView> lineViews = new List<LineView>();

    void Start()
    {
        linePerefab.SetActive(false);
    }

    internal void ShowResult(List<TestResultData> resultDatas)
    {
        while (resultDatas.Count > lineViews.Count)
        {
            AddLine();
        }

        for (int i = 0; i < resultDatas.Count; i++)
        {
            lineViews[i].Show(resultDatas[i]);
        }
    }

    private void AddLine()
    {
        var clone = Instantiate(linePerefab, Vector3.zero, Quaternion.identity, this.gameObject.transform);
        clone.SetActive(true);
        lineViews.Add(clone.GetComponent<LineView>());
    }
}
