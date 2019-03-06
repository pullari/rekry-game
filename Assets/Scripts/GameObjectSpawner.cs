using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    public float cooldown = 1;
    public GameObject spawnable;
    public bool isPooled;
    public bool shouldSpawn;
    public int poolStartingSize;

    CooledDown cooledDown;
    ObjectPool spawnablePool;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isPooled)
        {
            spawnablePool = new GameObject("ObjectPool")
                .AddComponent<ObjectPool>()
                .setDynamic(true)
                .setStartingSize(poolStartingSize)
                .setPrefab(spawnable);
        }

        if (cooldown > 0)
        {
            cooledDown = gameObject.AddComponent<CooledDown>()
                .SetAction(Generate)
                .SetCooldown(cooldown);

            cooledDown.shouldInvoke = shouldSpawn;
        }
    }

    public void SetShouldSpawn(bool should)
    {
        shouldSpawn = should;
        cooledDown.shouldInvoke = shouldSpawn;
    }

    void Generate()
    {
        GameObject spawned = isPooled ? spawnablePool.GetObject() : Instantiate(spawnable);
        Debug.Log(spawned);
        spawned.transform.position = transform.position;
        spawned.SetActive(true);
    }
}
