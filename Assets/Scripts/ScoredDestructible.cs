using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoredDestructible : Destructible
{
    public IntVar scoreAmount;
    public IntEvent scoreEvent;

    public override void Destroy(Damaging destroyedBy)
    {
        if (destructionEvent) destructionEvent.Raise();

        // Make sure scoring event exists and that object was destroyed by player
        if (scoreEvent && destroyedBy.type == DamageType.PlayerDamage) scoreEvent.RaiseEvent(scoreAmount.Value);

        gameObject.SetActive(false);

        if (destroyAfterDeath)
        {
            Destroy(gameObject);
        }
    }
}
