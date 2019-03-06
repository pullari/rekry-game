using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVelocity : Movable
{
    public override void Move()
    {
        transform.Translate(direction * (velocity * Time.deltaTime));
    }
}
