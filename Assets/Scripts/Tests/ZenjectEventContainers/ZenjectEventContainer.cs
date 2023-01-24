using Assets.Scripts.Model;
using System;
using UnityEngine;

public class ZenjectEventContainer
{

    private event Action runTestParam0;
    public void FireTestParam0() => runTestParam0?.Invoke();
    public void AddHandlerTestParam0(Action action) => runTestParam0 += action;
    public void RemoveHandlerTestParam0(Action action) => runTestParam0 -= action;





    private event Action<int> runTestParam1;
    public void FireTestParam1(int data) => runTestParam1?.Invoke(data);
    public void AddHandlerTestParam1(Action<int> action) => runTestParam1 += action;
    public void RemoveHandlerTestParam1(Action<int> action) => runTestParam1 -= action;





    private event Action<int, string, float, Vector2, MyData> runTestParam5;
    public void FireTestParam5(int nr, string text, float nr2, Vector2 vector2, MyData myData) => runTestParam5?.Invoke(nr, text, nr2, vector2, myData);
    public void AddHandlerTestParam5(Action<int, string, float, Vector2, MyData> action) => runTestParam5 += action;
    public void RemoveHandlerTestParam5(Action<int, string, float, Vector2, MyData> action) => runTestParam5 -= action;

    /// <summary>
    /// Super duper event.
    /// <typeparam name="int">My first param,</typeparam>
    /// <typeparam name="string">My second param,</typeparam>
    /// <typeparam name="Vector2">My third param,</typeparam>
    /// <typeparam name="int">My fought param,</typeparam>
    /// </summary>
    public event Action<int, string, Vector2, int> PublicRunTestParam;

}
