using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public bool DEBUG;
    public float startingHP;
    public FloatVar HP;
    public DamageTypeArray weaknesses;
    public GameEvent destructionEvent;
    public bool destroyAfterDeath;

    private void Start()
    {
        HP.Value = startingHP;
    }

    public void TakeDamage(Damaging damagedBy)
    {
        float damage = damagedBy.damage.Value;

        if (!HP)
        {
            Destroy(damagedBy);
            return;
        }
        
        HP.Value -= damage;

        if (HP.Value <= 0)
        {
            HP.Value = 0;
            Destroy(damagedBy);
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
                    TakeDamage(damageComponent);
                    damageComponent.ObjectWasHit();
                }
            }
        }
    }

    public virtual void Destroy(Damaging destroyedBy)
    {
        if(destructionEvent) destructionEvent.Raise();
        if (destroyAfterDeath)
        {
            Destroy(gameObject);
        }
    }
}
