using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadManager : SingletonBase<RoadManager>
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

            // ���ϴ� ��ŭ ������Ʈ�� �����ͼ� Ȱ��ȭ
            for (int i = 0; i < 10; i++) // ��: �ִ� 10�� Ȱ��ȭ
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
    // private ObjectPool roadPool;
    // private GameObject roadPrefab;
    // private GameObject prevRoad;

    // private float spawnInterval = 2.0f;
    // private float timer;

    // private void Awake()
    // {
    //     base.Awake();

    //     SetRoadPrefab();
    //     InitializeObjectPool();
    // }

    // private void SetRoadPrefab()
    // {
    //     roadPrefab = Resources.Load<GameObject>("Road");

    //     if (roadPrefab == null)
    //     {
    //         Debug.LogError("RoadPrefab�� ã�� �� �����ϴ�.");
    //     }
    // }

    // private void InitializeObjectPool()
    // {
    //     roadPool = gameObject.AddComponent<ObjectPool>();
    //     roadPool.ObjectPrefab = roadPrefab;
    // }

    // void Update()
    // {
    //     // Ÿ�̸� ����
    //     timer += Time.deltaTime;

    //     // �ֱⰡ ������ ���� ����
    //     if (timer >= spawnInterval)
    //     {
    //         SetActiveRoad();
    //         timer = 0f; // Ÿ�̸� ����
    //     }
    // }

    // public void SetActiveRoad()
    // {
    //     GameObject road = roadPool.GetObject();

    //     if (prevRoad == null)
    //     {
    //         road.transform.position = Vector3.zero;
    //     }
    //     else
    //     {
    //         // ���� ������ ��ġ�� �ٿ��� ����
    //         Vector3 lastRoadPosition = prevRoad.transform.position;
    //         Vector3 lastRoadSize = prevRoad.GetComponent<Renderer>().bounds.size; // ������ ũ��
    //         road.transform.position = new Vector3(lastRoadPosition.x, lastRoadPosition.y, lastRoadPosition.z + lastRoadSize.z);
    //     }

    //     road.SetActive(true);
    //     road.transform.position = new Vector3(0, 0, 0); // ���� ��ġ ����
    //     prevRoad = road;
    // }

    // public void ReleaseRoad(GameObject road)
    // {
    //     roadPool.ReleaseObject(road);
    // }
}
