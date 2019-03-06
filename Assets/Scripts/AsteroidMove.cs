using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : Movable
{
    void Start()
    {
        direction.x = Random.Range(-1f, 1f);
    }

    public override void Move()
    {
        transform.Translate(Vector3.Normalize(direction) * (velocity * Time.deltaTime));
    }
}
