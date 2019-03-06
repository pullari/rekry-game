using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    public float cooldown = 1;
    public GameObject spawnable;
    public bool isPooled;
    public bool isPoolDynamic;
    public bool shouldSpawn;
    public int poolStartingSize;

    CooledDown cooledDown;
    ObjectPool spawnablePool;
    
    // Start is called before the first frame update
    public void Start()
    {
        if (isPooled)
        {
            spawnablePool = new GameObject("ObjectPool")
                .AddComponent<ObjectPool>()
                .setDynamic(isPoolDynamic)
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
        else
        {
            Debug.Log("No cooldown set. This results in instantiations on every update.");
        }
    }

    private void Update()
    {
        if (cooldown <= 0 && shouldSpawn)
        {
            Debug.Log("Is called");
            Generate();
        }
    }

    public void SetShouldSpawn(bool should)
    {
        shouldSpawn = should;
        if(cooledDown) cooledDown.shouldInvoke = shouldSpawn;
    }

    void Generate()
    {
        GameObject spawned = isPooled ? spawnablePool.GetObject() : Instantiate(spawnable);
        if (!spawned) return;
        spawned.transform.position = transform.position;
        spawned.SetActive(true);
        GameObjectWasCreated(spawned);
    }

    public virtual void GameObjectWasCreated(GameObject created)
    {

    }
}
