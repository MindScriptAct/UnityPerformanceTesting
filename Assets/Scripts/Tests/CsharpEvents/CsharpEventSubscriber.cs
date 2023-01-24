using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsharpEventSubscriber : MonoBehaviour
{
    [SerializeField]
    private CsharpEventsParams0Test publisher0;

    [SerializeField]
    private CsharpEventsParams1Test publisher1;

    [SerializeField]
    private CsharpEventsParams5Test publisher5;
    private int testNr;
    private int testNr1;
    private int testNr5;


    // Start is called before the first frame update
    void Start()
    {
        if (publisher0 != null)
        {
            publisher0.OnEvent0 += HandleParam0;
        }
        if (publisher1 != null)
        {
            publisher1.OnEvent1 += HandleParam1;
        }
        if (publisher5 != null)
        {
            publisher5.OnEvent5 += HandleParam5;
        }
    }

    private void HandleParam0()
    {
        //Debug.Log("HandleParam0");
        testNr++;
    }


    private void HandleParam1(int nr)
    {
        //Debug.Log($"HandleParam1 {nr}");
        testNr1++;
    }

    private void HandleParam5(int nr, string text, double nr2, Vector2 vector2, MyData data)
    {
        //Debug.Log($"HandleParam5 {nr} {text} {nr2} {vector2.x} {data.Text}");
        testNr5++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
