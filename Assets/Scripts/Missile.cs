using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Movable
{
    // Note: OnBecameInvisible also takes into account Editor Views camera
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public override void Move()
    {
        transform.Translate(0, 0, velocity * Time.deltaTime);
    }
}
