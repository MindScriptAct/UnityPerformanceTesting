using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBehaviour : MonoBehaviour
{
    private Dictionary<string, List<Action<object>>> messageRegister = new Dictionary<string, List<Action<object>>>();


    //[SerializeField]
    //private string name;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void SendMyMessage(string message, object data)
    {
        if (messageRegister.TryGetValue(message, out List<Action<object>> handlers))
        {
            foreach (var handler in handlers)
            {
                handler(data);
            }
        }
    }

    internal void RegisterHandler(string message, Action<object> action)
    {
        List<Action<object>> handlers;
        if (messageRegister.ContainsKey(message))
        {
            handlers = messageRegister[message];
        }
        else
        {
            handlers = new List<Action<object>>();
            messageRegister.Add(message, handlers);
        }
        handlers.Add(action);
    }
}
