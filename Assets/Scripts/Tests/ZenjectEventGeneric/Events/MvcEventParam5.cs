using Assets.Scripts.Model;
using UnityEngine;
public class MvcEventParam5 : MvcEvent<int, string, float, Vector2, MyData>
{
    /// <summary>
    /// Comments here!
    /// </summary>
    /// <param name="nr"></param>
    /// <param name="text"></param>
    /// <param name="nr2"></param>
    /// <param name="vector"></param>
    /// <param name="myData"></param>
    public override void Invoke(int nr, string text, float nr2, Vector2 vector, MyData myData)
        => base.Invoke(nr, text, nr2, vector, myData);
}