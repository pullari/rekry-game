using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Serializing this so that it can be set in inspector
[System.Serializable]
public struct FloatTuple
{
    public float min;
    public float max;
}

public class AsteroidField : GameObjectSpawner
{
    public Collider spawnArea;
    public Collider targetArea;

    [Tooltip("Used to randomize velocity of movable objects")]
    public FloatTuple velocityRange;

    private new void Start()
    {
        base.Start();

        if (!spawnArea || !targetArea)
        {
            Debug.LogError("No spawnArea or targetArea set in asteroid field. These are required");
            Destroy(this);
        }
    }

    public override void GameObjectWasCreated(GameObject created)
    {
        Vector3 spawnPoint = RandomPointInBounds(spawnArea.bounds);
        Vector3 targetPoint = RandomPointInBounds(targetArea.bounds);

        spawnPoint.y = targetPoint.y = spawnArea.transform.position.y;

        created.transform.position = spawnPoint;

        Movable mov = created.GetComponent<Movable>();
        
        Vector3 direction = targetPoint - spawnPoint;
        
        direction.Normalize();
        if (mov)
        {
            mov.direction = direction;
            mov.velocity = Random.Range(velocityRange.min, velocityRange.max);
        }
    }

    public Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
