using System;

public class MvcEvent
{
    private Action action;

    public void AddHandler(Action handler) => action += handler;
    public void RemoveHandler(Action handler) => action -= handler;

    public virtual void Invoke() => action?.Invoke();

}

public class MvcEvent<T1>
{
    private event Action<T1> action;

    public void AddHandler(Action<T1> handler) => action += handler;
    public void RemoveHandler(Action<T1> handler) => action -= handler;

    public virtual void Invoke(T1 arg1) => action?.Invoke(arg1);
}

public class MvcEvent<T1, T2, T3, T4, T5>
{
    private event Action<T1, T2, T3, T4, T5> action;

    public void AddHandler(Action<T1, T2, T3, T4, T5> handler) => action += action;
    public void RemoveHandler(Action<T1, T2, T3, T4, T5> handler) => action -= action;

    public virtual void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => action?.Invoke(arg1, arg2, arg3, arg4, arg5);
}