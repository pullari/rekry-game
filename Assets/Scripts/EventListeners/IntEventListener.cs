using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IntEventListener : GenEventListener<int>
{
    public IntEvent intEvent;
    public override GenEvent<int> e
    {
        get { return intEvent; }
        set { e = intEvent; }
    }
}
