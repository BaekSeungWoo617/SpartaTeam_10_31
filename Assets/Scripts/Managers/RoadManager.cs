using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadManager : SingletonBase<RoadManager>
{
    private ObjectPool roadPool;
    private GameObject roadPrefab;
    private GameObject prevRoad;
    private GameObject StartRoad;
    private GameObject EndRoad;

    private float spawnInterval = 2.0f;
    private float timer;
    protected override void Awake()
    {
        base.Awake();

        SetRoadPrefab();
        InitializeObjectPool();
    }
    private void Start()
    {
        StartRoad = Resources.Load<GameObject>("Prefabs/Road/RoadStart");
        EndRoad= Resources.Load<GameObject>("Prefabs/Road/RoadEnd");
        GameObject newObj = Instantiate(StartRoad);
    }
    private void SetRoadPrefab()
    {
        roadPrefab = Resources.Load<GameObject>("Prefabs/Road/RoadTest");

        if (roadPrefab == null)
        {
            Debug.LogError("?§Î∏å?ùÌä∏ Î∂àÎü¨?§Í∏∞ ?†Îü¨");
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
        if(road.tag=="Road")
        {
        road.transform.position = new Vector3(0, 0, 100f); 
        }
        else if(road.tag == "Huddle")
        {
            float randX = Random.Range(-10f, 10f);
            road.transform.position = new Vector3(randX, 0, 100f);
        }
        else if (road.tag == "LeftBuildings")
        {
            road.transform.position = new Vector3(-20f, 0, 100f);
            road.transform.rotation = Quaternion.Euler(90,0,0);
        }
        else if (road.tag == "RightBuildings")
        {
            road.transform.position = new Vector3(20f, 0, 100f);
            road.transform.rotation = Quaternion.Euler(-90, 0, 0);

        }
        else road.transform.position = new Vector3(0, 0, 0);
        prevRoad = road;
    }

    public void ReleaseRoad(GameObject road)
    {
        roadPool.ReleaseObject(road);
    }
}
