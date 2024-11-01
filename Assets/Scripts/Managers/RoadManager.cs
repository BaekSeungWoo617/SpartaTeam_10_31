using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public static RoadManager Instance;
    public GameObject[] road;
    private Dictionary<string, ObjectPool> pools;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            pools = new Dictionary<string, ObjectPool>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        for (int i = 0; i < road.Length; i++)
        {
            ObjectPool pool = new ObjectPool();
            pool.Initialize(road[i], 10);
            pools.Add(road[i].name, pool);

        }

        ActivateAllRoads();
    }
    public void ActivateAllRoads()
    {
        foreach (KeyValuePair<string, ObjectPool> kvp in pools)
        {
            ObjectPool pool = kvp.Value;

            // 원하는 만큼 오브젝트를 가져와서 활성화
            for (int i = 0; i < 10; i++) // 예: 최대 10개 활성화
            {
                GameObject obj = pool.Get();
                if (obj != null)
                {
                    obj.SetActive(true);
                    Debug.Log($"{kvp.Key} activated.");
                }
            }
        }
    }
    public void AddPool(string key, GameObject prefab, int poolSize)
    {
        if (!pools.ContainsKey(key))
        {
            GameObject poolContainer = new GameObject(key + "Pool");
            poolContainer.transform.SetParent(transform);
            ObjectPool pool = poolContainer.AddComponent<ObjectPool>();
            pool.Initialize(prefab, poolSize);
            pools.Add(key, pool);
        }
        
    }

    public GameObject Get(string key)
    {
        if (pools.ContainsKey(key))
        {
            return pools[key].Get();
        }
        return null;
    }

    public void Release(string key, GameObject obj)
    {
        if (pools.ContainsKey(key))
        {
            pools[key].Release(obj);
        }
    }
}
