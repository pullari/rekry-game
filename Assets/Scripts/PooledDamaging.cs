using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledDamaging : Damaging
{
    public override void ObjectWasHit()
    {
        gameObject.SetActive(false);
    }
}
