using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolAmount = 100;
    List<GameObject> objectList;

    private void Awake()
    {
        objectList = new List<GameObject>();
        for (int i = 0; i < initialPoolAmount; i++)
        {
            AddObjectToPool();
        }
    }

    GameObject AddObjectToPool()
    {
        GameObject newObject = Instantiate(prefab);
        newObject.SetActive(false);
        objectList.Add(newObject);
        return newObject;
    }

    /// <summary>
    /// Returns a disable GameObject from the pool.
    /// </summary>
    /// <returns>A GameObject (activeSelf = false)</returns>
    public GameObject GetObjectFromPool()
    {
        if (objectList.Count < 1) return null;

        foreach (GameObject currentObject in objectList)
        {
            if (!currentObject.activeSelf) {
                return currentObject;
            }
        }

        // add new object dynamically
        return AddObjectToPool();
    }
}
