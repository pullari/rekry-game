using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public FloatVar HP;
    public DamageTypeArray weaknesses;
    public GameEvent destructionEvent;
    public bool destroyAfterDeath;

    public void TakeDamage(float damage)
    {
        if (!HP)
        {
            Destroy();
            return;
        }

        HP.Value -= damage;

        if (HP.Value < 0)
        {
            Destroy();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Damaging damageComponent = other.GetComponent<Damaging>();

        if (damageComponent)
        {
            for (int i = 0; i < weaknesses.arr.Length; i++)
            {
                if (weaknesses.arr[i] == damageComponent.type) 
                {
                    TakeDamage(damageComponent.damage.Value);
                    damageComponent.ObjectWasHit();
                }
            }
        }
    }

    public virtual void Destroy()
    {
        if(destructionEvent) destructionEvent.Raise();
        if (destroyAfterDeath)
        {
            Destroy(gameObject);
        }
    }
}
