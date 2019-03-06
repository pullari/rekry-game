using System;
using System.Collections.Generic;
using UnityEngine;

public class GenEvent<T> : ScriptableObject
{
    List<Action<T>> list = new List<Action<T>>();

    public void Subscribe(Action<T> func)
    {
        list.Add(func);
    }


    public void Unsubscribe(Action<T> func)
    {
        list.Remove(func);
    }

    public void RaiseEvent(T param)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            list[i].Invoke(param);
        }
    }
}