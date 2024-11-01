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

    private void Awake()
    {
        base.Awake();

        SetRoadPrefab();
        InitializeObjectPool();
    }

    private void SetRoadPrefab()
    {
        roadPrefab = Resources.Load<GameObject>("Road");

        if (roadPrefab == null)
        {
            Debug.LogError("RoadPrefab을 찾을 수 없습니다.");
        }
    }

    private void InitializeObjectPool()
    {
        roadPool = gameObject.AddComponent<ObjectPool>();
        roadPool.ObjectPrefab = roadPrefab;
    }

    void Update()
    {
        // 타이머 증가
        timer += Time.deltaTime;

        // 주기가 지나면 도로 생성
        if (timer >= spawnInterval)
        {
            SetActiveRoad();
            timer = 0f; // 타이머 리셋
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
            // 이전 도로의 위치에 붙여서 생성
            Vector3 lastRoadPosition = prevRoad.transform.position;
            Vector3 lastRoadSize = prevRoad.GetComponent<Renderer>().bounds.size; // 도로의 크기
            road.transform.position = new Vector3(lastRoadPosition.x, lastRoadPosition.y, lastRoadPosition.z + lastRoadSize.z);
        }

        road.SetActive(true);
        road.transform.position = new Vector3(0, 0, 0); // 예시 위치 설정
        prevRoad = road;
    }

    public void ReleaseRoad(GameObject road)
    {
        roadPool.ReleaseObject(road);
    }
}
