using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMediatorBehaviour : TestBase
{

    private ModuleBehaviour module;

    // Start is called before the first frame update
    void Awake()
    {
        module = transform.root.GetComponent<ModuleBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendStringMessage(string message, object data = null)
    {
        module.SendMyMessage(message, data);
    }

    public void RegisterHandler(string message, Action<object> action)
    {
        module.RegisterHandler(message, action);
    }

    internal override void DoTest()
    {
        throw new NotImplementedException();
    }
}
