using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{
    [Tooltip("Some spawners override velocity and direction")]
    public float velocity;
    [Tooltip("Some spawners override velocity and direction")]
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public abstract void Move();
}
