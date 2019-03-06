using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOQueue<T> : ScriptableObject
{
    // Dynamically allocated so adding a lot of commands can trigget a heap allocation (and removing them a deallocation -> GC) so be mindful
    protected Queue<T> queue = new Queue<T>();

    public void Enqueue(T elem)
    {
        queue.Enqueue(elem);
    }

    public T Dequeue()
    {
        return queue.Dequeue();
    }

    public int Count()
    {
        return queue.Count;
    }
}
