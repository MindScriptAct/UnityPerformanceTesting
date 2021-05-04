using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventSubscriber : MonoBehaviour
{
    [SerializeField]
    private UnityEventsParams0Test publisher0;

    [SerializeField]
    private UnityEventsParams1Test publisher1;

    [SerializeField]
    private UnityEventsParams5Test publisher5;


    // Start is called before the first frame update
    void Start()
    {
        if (publisher0 != null)
        {
            //publisher0.OnEvent0 += HandleParam0;
        }
        if (publisher1 != null)
        {
            //publisher1.OnEvent1 += HandleParam1;
        }
        if (publisher5 != null)
        {
            //publisher5.OnEvent5 += HandleParam5;
        }
    }

    private void HandleParam0()
    {
        Debug.Log("HandleParam0");
    }


    private void HandleParam1(int nr)
    {
        Debug.Log($"HandleParam1 {nr}");
    }

    private void HandleParam5(DataPack data)
    {
        Debug.Log($"HandleParam5 {data.Nr} {data.Text} {data.Nr2} {data.Vector2.x} {data.MyData.Text}");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
