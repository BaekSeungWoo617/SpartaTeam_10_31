using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadManager : SingletonBase<RoadManager>
{
    private ObjectPool roadPool;
    private ObjectPool huddlePool;
    private ObjectPool leftPool;
    private ObjectPool rightPool;

    private GameObject roadPrefab;
    private GameObject huddlePrefab;
    private GameObject leftBDPrefab;
    private GameObject rightBDPrefab;


    private GameObject prevRoad;
    private GameObject StartRoad;
    private GameObject EndRoad;

    private float spawnInterval = 2.0f;
    private float timer;
    protected override void Awake()
    {
        base.Awake();

        //SetRoadPrefab();
        roadPrefab = null;
        SetRandomPrefab(ref roadPrefab, "Prefabs/Road");
        huddlePrefab = null;
        SetRandomPrefab(ref huddlePrefab, "Prefabs/Huddle");
        leftBDPrefab = null;
        SetRandomPrefab(ref leftBDPrefab, "Prefabs/LeftBuilding");
        rightBDPrefab = null;
        SetRandomPrefab(ref rightBDPrefab, "Prefabs/RightBuilding");


        InitializeRoadObjectPool();
        InitializeHuddleObjectPool();
    }
    private void Start()
    {
        StartRoad = Resources.Load<GameObject>("Prefabs/SpecialRoad/RoadStart");
        EndRoad= Resources.Load<GameObject>("Prefabs/Road/Special/RoadEnd");
        GameObject newObj = Instantiate(StartRoad);
    }
    private void SetRoadPrefab()
    {
        roadPrefab = Resources.Load<GameObject>("Prefabs/Road/RoadTest");

        if (roadPrefab == null)
        {
            Debug.LogError("오브젝트 불러오기 애러");
        }
    }
    private void SetRandomPrefab(ref GameObject myObject,string folderPath)// 오브젝트 종류, 오브젝트 폴더위치ex)Prefabs/Road
    {
        GameObject[] prefabs = Resources.LoadAll<GameObject>(folderPath);

        if (prefabs.Length == 0)
        {
            Debug.LogError("오브젝트를 불러오는 데 실패했습니다.");
            return;
        }

        int randomIndex = Random.Range(0, prefabs.Length);
        myObject = prefabs[randomIndex];
        Debug.Log($"선택된 오브젝트: {myObject.name}");
    }

    private void InitializeRoadObjectPool()
    {
        roadPool = gameObject.AddComponent<ObjectPool>();
        roadPool.ObjectPrefab = roadPrefab;
    }
    private void InitializeHuddleObjectPool()
    {
        huddlePool = gameObject.AddComponent<ObjectPool>();
        huddlePool.ObjectPrefab = huddlePrefab;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SetActiveObject(roadPool, prevRoad);
            SetActiveObject(huddlePool, huddlePrefab);

            timer = 0f;
        }
    }

    public void SetActiveObject(ObjectPool objectPool, GameObject myObject)
    {
        GameObject road = objectPool.GetObject();

        if (myObject == null)
        {
            road.transform.position = Vector3.zero;
        }
        else
        {
            Vector3 lastRoadPosition = myObject.transform.position;
            Vector3 lastRoadSize = myObject.GetComponent<Renderer>().bounds.size;
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
        myObject = road;
    }

    public void ReleaseRoad(ObjectPool objectPool,GameObject road)
    {
        objectPool.ReleaseObject(road);
    }
}
