using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType {
    PlayerDamage,
    EnemyDamage
}

public class Damaging : MonoBehaviour
{
    public DamageType type;
    public FloatVar damage;

    public virtual void ObjectWasHit()
    {
        Destroy(gameObject);
    }
}


