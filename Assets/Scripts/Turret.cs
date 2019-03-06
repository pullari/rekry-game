using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct FireCommand
{
    public Vector3 direction;

    public FireCommand(Vector3 dir)
    {
        direction = dir;
    }
}

// This class could be defined in a separate script but as it is only needed in Turret I do it here.
[CreateAssetMenu(menuName = "FireCommandQueue")]
public class FireCommandQueue : SOQueue<FireCommand> { }

public class Turret : Vector3Listener
{
    public float cooldown = 1;
    public GameObject projectile;

    public Transform firePos;
    public CooledDown cooledDown;

    FireCommandQueue queue;
    ObjectPool missilePool;
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        missilePool = new GameObject("MissilePool")
            .AddComponent<ObjectPool>()
            .setDynamic(false)
            .setStartingSize(25)
            .setPrefab(projectile);

        queue = ScriptableObject.CreateInstance<FireCommandQueue>();


        cooledDown = gameObject.AddComponent<CooledDown>()
            .SetAction(() => {
                FireCommand command = queue.Dequeue();
                Shoot(command.direction);
                shouldCooldownInvoke();
            })
            .SetCooldown(cooldown);
    }

    void shouldCooldownInvoke()
    {
        cooledDown.shouldInvoke = queue.Count() != 0;
    }
    
    void Shoot(Vector3 direction)
    {
        transform.LookAt(direction);
        GameObject missile = missilePool.GetObject();

        if (missile != null)
        {
            missile.transform.position = firePos.position;
            missile.transform.rotation = firePos.rotation;
            missile.SetActive(true);
        }
    }

    public override void onEvent(Vector3 param)
    {
        queue.Enqueue(new FireCommand(param));
        shouldCooldownInvoke();
    }
}
