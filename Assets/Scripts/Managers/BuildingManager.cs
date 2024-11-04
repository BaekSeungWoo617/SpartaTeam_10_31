using System.Collections.Generic;
using UnityEngine;

public class Building : SingletonBase<RoadManager>
{
    private List<GameObject> buildingInstances = new List<GameObject>();
    private GameObject[] buildingPrefabs;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // "Prefabs/Building"에서 모든 건물 프리팹 로드
        buildingPrefabs = Resources.LoadAll<GameObject>("Prefabs/Building");

        // 건물 생성
        CreateBuildingsAtPosition(new Vector3(20, 0, 0), 10); // 오른쪽에 배치
        CreateBuildingsAtPosition(new Vector3(-20, 0, 0), 10); // 왼쪽에 배치
    }

    private void CreateBuildingsAtPosition(Vector3 startPosition, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // 랜덤한 건물 프리팹 선택
            GameObject randomPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];

            // 위치 생성
            Vector3 buildingPosition = startPosition + new Vector3(0, 0, i * 20);

            // 인스턴스화
            GameObject buildingInstance = Instantiate(randomPrefab, buildingPosition, Quaternion.identity);

            // 리스트에 추가
            buildingInstances.Add(buildingInstance);
        }
    }
}