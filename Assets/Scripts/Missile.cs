using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Movable
{
    // Note: OnBecameInvisible also takes into account Editor Views camera. This might be removed if we add bounds to the game area that handle object "removal"
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public override void Move()
    {
        // Memorizing y pos to make sure that Translate does not affect it
        float yMem = transform.position.y;

        transform.Translate(0, 0, velocity * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, yMem, transform.position.z);
    }
}
