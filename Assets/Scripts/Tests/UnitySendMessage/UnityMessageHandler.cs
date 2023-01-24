using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMessageHandler : MonoBehaviour
{
    private int testNr;
    private int testNr1;
    private int testNr5;
    private int testNrT5;

    public void HandleMessageParam0()
    {
        //Debug.Log($"HandleMessageParam0");
        testNr++;
    }
    public void HandleMessageParam1(int nr)
    {
        //Debug.Log($"HandleMessageParam1 {nr}");
        testNr1++;
    }

    public void HandleMessageParam5Struct(DataPack data)
    {
        //Debug.Log($"HandleMessageParam5Struct {data.Nr} {data.Text} {data.Nr2} {data.Vector2.x} {data.MyData.Text}");
        testNr5++;
    }

    public void HandleMessageParam5Tupple((int, string, float, Vector2, MyData) data)
    {
        //Debug.Log($"HandleMessageParam5Tupple {data.Item1} {data.Item2} {data.Item3} {data.Item4.x} {data.Item5.Text}");
        testNrT5++;
    }



}
