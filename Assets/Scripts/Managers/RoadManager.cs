using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    PoolManager poolManager;
    private void Awake()
    {
        poolManager = GetComponent<PoolManager>();
}
    void Start()
    {
    }
    void SetActiveRoad()
    {

        GameObject road = poolManager.SpawnFromPool("Road");
        road.SetActive(true);
    }
}
