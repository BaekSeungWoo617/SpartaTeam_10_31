using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 1;

    private List<GameObject> pool;

    public void Initialize(GameObject prefab, int poolSize)
    {
        this.prefab = prefab;
        this.poolSize = poolSize;

        pool = new List<GameObject>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.name = $"{prefab.name}_{i}";
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject Get()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}
