using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadManager : SingletonBase<RoadManager>
{
    private ObjectPool roadPool;
    private GameObject roadPrefab;
    private GameObject prevRoad;

    private float spawnInterval = 2.0f;
    private float timer;

    protected override void Awake()
    {
        base.Awake();

        SetRoadPrefab();
        InitializeObjectPool();
    }

    private void SetRoadPrefab()
    {
        roadPrefab = Resources.Load<GameObject>("RoadTest");

        if (roadPrefab == null)
        {
            Debug.LogError("RoadPrefab�� ã�� �� �����ϴ�.");
        }
    }
    private void InitializeObjectPool()
    {
        roadPool = gameObject.AddComponent<ObjectPool>();
        roadPool.ObjectPrefab = roadPrefab;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SetActiveRoad();
            timer = 0f;
        }
    }

    public void SetActiveRoad()
    {
        GameObject road = roadPool.GetObject();

        if (prevRoad == null)
        {
            road.transform.position = Vector3.zero;
        }
        else
        {
            Vector3 lastRoadPosition = prevRoad.transform.position;
            Vector3 lastRoadSize = prevRoad.GetComponent<Renderer>().bounds.size;
            road.transform.position = new Vector3(lastRoadPosition.x, lastRoadPosition.y, lastRoadPosition.z + lastRoadSize.z);
        }

        road.SetActive(true);
        road.transform.position = new Vector3(0, 0, 0); 
        prevRoad = road;
    }

    public void ReleaseRoad(GameObject road)
    {
        roadPool.ReleaseObject(road);
    }
}
