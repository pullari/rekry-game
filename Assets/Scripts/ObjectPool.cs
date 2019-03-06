using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int startingPoolSize;
    public GameObject prefab;
    public bool dynamic;

    private List<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<GameObject>();

        if (prefab != null)
        {
            for (int i = 0; i < startingPoolSize; i++)
            {
                AddToPool();
            }
        }
        else
        {
            Debug.Log("No poolable GameObject defined");
        }
    }

    public ObjectPool setStartingSize(int size)
    {
        startingPoolSize = size;
        return this;
    }

    public ObjectPool setPrefab(GameObject obj)
    {
        prefab = obj;
        return this;
    }

    public ObjectPool setDynamic(bool dyn)
    {
        dynamic = dyn;
        return this;
    }

    GameObject AddToPool()
    {
        GameObject instad = Instantiate(prefab);
        instad.transform.parent = transform;
        pool.Add(instad);
        instad.SetActive(false);
        return instad;
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy) return pool[i];
        }
        
        if(dynamic) return AddToPool();
        return null;
    }
}
