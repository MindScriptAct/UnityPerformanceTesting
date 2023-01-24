using Assets.Scripts.Model;
using UnityEngine;

public class SignalTestParam5
{
    public int Nr;
    public string Text;
    public float Nr2;
    public Vector2 Vector2;
    public MyData MyData;

    public SignalTestParam5() { }

    public SignalTestParam5(int nr, string text, float nr2, Vector2 vector2, MyData myData)
    {
        Nr = nr;
        Text = text;
        Nr2 = nr2;
        Vector2 = vector2;
        MyData = myData;
    }
}

