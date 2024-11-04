using System.Collections.Generic;
using UnityEngine;

public class Building : SingletonBase<RoadManager>
{
    private List<GameObject> buildingInstances = new List<GameObject>();
    private GameObject[] buildingLeft;
    private GameObject[] buildingRight;
    private GameObject roadSide;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // "Prefabs/Building"에서 모든 건물 프리팹 로드
        buildingLeft = Resources.LoadAll<GameObject>("Prefabs/BuildingLeft");
        buildingRight = Resources.LoadAll<GameObject>("Prefabs/BuildingRight");
        roadSide = Resources.Load<GameObject>("Prefabs/Road/RoadSide");

        // 건물 생성
        CreateBuildingsAtPosition(buildingLeft, new Vector3(-20, 0, 0), 10, Quaternion.Euler(0, 90, 0));
        CreateBuildingsAtPosition(buildingRight, new Vector3(20, 0, 0), 10, Quaternion.Euler(0, -90, 0));
        CreateSideRoad(10);

    }
    private void CreateBuildingsAtPosition(GameObject[] myObjects, Vector3 startPosition, int count, Quaternion rotation)
    {
        for (int i = 0; i < count; i++)
        {
            // 랜덤한 건물 프리팹 선택
            GameObject randomPrefab = myObjects[Random.Range(0, myObjects.Length)];

            // 위치 생성
            Vector3 buildingPosition = startPosition + new Vector3(0, 0, i * 20);

            // 인스턴스화
            GameObject buildingInstance = Instantiate(randomPrefab, buildingPosition, rotation);

            // 리스트에 추가
            buildingInstances.Add(buildingInstance);
        }
    }
    void CreateSideRoad(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // 위치 생성
            Vector3 PositionLeft = new Vector3(-20, 0, i * 20);
            Vector3 PositionRight = new Vector3(20, 0, i * 20);

            // 인스턴스화
            GameObject LeftInstance = Instantiate(roadSide, PositionLeft, Quaternion.identity);
            GameObject RightInstance = Instantiate(roadSide, PositionRight, Quaternion.identity);

        }
    }
}