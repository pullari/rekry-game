using UnityEngine;

public abstract class Vector3Listener : GenEventListener<Vector3>
{
    public Vector3Event vectorEvent;
    public override GenEvent<Vector3> e
    {
        get { return vectorEvent; }
        set { e = vectorEvent; }
    }
}