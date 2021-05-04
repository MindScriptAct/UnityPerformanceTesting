using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallReceiver : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    internal void TrigerMethod0()
    {
        //Debug.Log("TrigerMethod0");
    }

    internal void TrigerMethod1(int nr)
    {
        //Debug.Log($"TrigerMethod1 {nr}");
    }

    internal void TrigerMethod5(int nr, string text, float nr2, Vector2 vector2, MyData data)
    {
        //Debug.Log($"TrigerMethod5 {nr} {text} {nr2} {vector2.x} {data.Text}");
    }

    // Update is called once per frame
    void Update()
    {
    }
}