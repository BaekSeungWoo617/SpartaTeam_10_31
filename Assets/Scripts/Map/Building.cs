using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : SingletonBase<RoadManager>
{
    private List<GameObject> buildingPool;
    private GameObject[] buildingPrefab;


    protected override void Awake()
    {
        base.Awake();

    }
    private void Start()
    {
        GameObject[] roadPrefabs = Resources.LoadAll<GameObject>("Prefabs/Road");

        // 로드된 프리팹들을 리스트에 인스턴스화하여 추가
        foreach (GameObject roadPrefab in roadPrefabs)
        {
            // 인스턴스화
            GameObject roadInstance = Instantiate(roadPrefab);
            // 리스트에 추가
            roadInstances.Add(roadInstance);
        }
    }
}
