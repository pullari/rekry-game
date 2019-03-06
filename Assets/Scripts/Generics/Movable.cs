using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{
    public float velocity;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public abstract void Move();
}
