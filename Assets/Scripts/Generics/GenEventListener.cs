using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenEventListener<T> : MonoBehaviour
{
    public abstract GenEvent<T> e { get; set; }

    // Start is called before the first frame update
    public void Start()
    {
        e.Subscribe(onEvent);
    }

    void Destroy()
    {
        e.Subscribe(onEvent);
    }

    public abstract void onEvent(T param);
}
