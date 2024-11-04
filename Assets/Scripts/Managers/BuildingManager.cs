using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : SingletonBase<BuildingManager>
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
        // "Prefabs/Building"���� ��� �ǹ� ������ �ε�
        buildingLeft = Resources.LoadAll<GameObject>("Prefabs/BuildingLeft");
        buildingRight = Resources.LoadAll<GameObject>("Prefabs/BuildingRight");
        roadSide = Resources.Load<GameObject>("Prefabs/Road/RoadSide");

        // �ǹ� ����
        CreateBuildingsAtPosition(buildingLeft, new Vector3(-20, 0, 0), 10, Quaternion.Euler(0, 90, 0));
        CreateBuildingsAtPosition(buildingRight, new Vector3(20, 0, 0), 10, Quaternion.Euler(0, -90, 0));
        CreateSideRoad(10);

    }
    private void CreateBuildingsAtPosition(GameObject[] myObjects, Vector3 startPosition, int count, Quaternion rotation)
    {
        for (int i = 0; i < count; i++)
        {
            // ������ �ǹ� ������ ����
            GameObject randomPrefab = myObjects[Random.Range(0, myObjects.Length)];

            // ��ġ ����
            Vector3 buildingPosition = startPosition + new Vector3(0, 0, i * 20);

            // �ν��Ͻ�ȭ
            GameObject buildingInstance = Instantiate(randomPrefab, buildingPosition, rotation);

            // ����Ʈ�� �߰�
            buildingInstances.Add(buildingInstance);
        }
    }
    void CreateSideRoad(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // ��ġ ����
            Vector3 PositionLeft = new Vector3(-20, 0, i * 20);
            Vector3 PositionRight = new Vector3(20, 0, i * 20);

            // �ν��Ͻ�ȭ
            GameObject LeftInstance = Instantiate(roadSide, PositionLeft, Quaternion.identity);
            GameObject RightInstance = Instantiate(roadSide, PositionRight, Quaternion.identity);

        }
    }
}