using System.Collections.Generic;
using UnityEngine;

public class ObjectPoool
{    
    private GameObject prefab;
    private Transform poolRoot;
    private int optimumObjectCounter;

    private Queue<GameObject> objectsInPool = new Queue<GameObject>();

    public ObjectPoool(GameObject prefab, Transform poolRoot, int optimumObjectCounter)
    {
        this.prefab = prefab;
        this.poolRoot = poolRoot;
        this.optimumObjectCounter = optimumObjectCounter;

        for (int i = 0; i < optimumObjectCounter; i++)
        {
          CreatePoolObject();
        }
    }

    private void CreatePoolObject()
    {
        GameObject instantiatedObject = GameObject.Instantiate(prefab);
        objectsInPool.Enqueue(instantiatedObject);
        instantiatedObject.SetActive(false);
        instantiatedObject.transform.parent = poolRoot;
    }

    public GameObject GetFromPool()
    {
        if (objectsInPool.Count == 0)
        {
            CreatePoolObject();
        }
        
        return objectsInPool.Dequeue();
    }

    public void ReturnToPool(GameObject pooledObject)
    {
        if (objectsInPool.Count > optimumObjectCounter)
        {
            GameObject.Destroy(pooledObject);
            return;
        }
        objectsInPool.Enqueue(pooledObject);      
    }
}