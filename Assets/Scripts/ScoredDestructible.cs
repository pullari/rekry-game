using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoredDestructible : Destructible
{
    public IntVar scoreAmount;
    public IntEvent scoreEvent;

    public override void Destroy()
    {
        if (destructionEvent) destructionEvent.Raise();
        if (scoreEvent)
        {
            scoreEvent.RaiseEvent(scoreAmount.Value);
        }

        gameObject.SetActive(false);

        if (destroyAfterDeath)
        {
            Destroy(gameObject);
        }
    }
}
