using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool;
    private GameObject objectPrefab;
    private const int minSize = 10;
    private const int maxSize = 30;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < minSize; i++)
        {
            pool.Add(CreateNewObject());
        }
    }

    private GameObject CreateNewObject()
    {
        var newObj = Instantiate(objectPrefab); ;
        newObj.SetActive(false);
        return newObj;
    }

    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        if (pool.Count < maxSize)
        {
            var newObj = CreateNewObject();
            pool.Add(newObj);
            newObj.SetActive(true);
            return newObj;
        }
        else
        {
            var tempObject = new GameObject("Temporary Object");
            tempObject.SetActive(true);
            return tempObject;
        }
    }

    public void ReleaseObject(GameObject obj)
    {
        if (obj.name == "Temporary Object")
        {
            Destroy(obj);
        }
        else
        {
            obj.SetActive(false);
        }
    }

    public GameObject ObjectPrefab
    {
        get => objectPrefab;
        set => objectPrefab = value;
    }
}
