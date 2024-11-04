using System.Collections.Generic;
using UnityEngine;

public class Building : SingletonBase<RoadManager>
{
    private List<GameObject> buildingInstances = new List<GameObject>();
    private GameObject[] buildingLeft;
    private GameObject[] buildingRight;


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // "Prefabs/Building"���� ��� �ǹ� ������ �ε�
        buildingLeft = Resources.LoadAll<GameObject>("Prefabs/BuildingLeft");
        buildingRight = Resources.LoadAll<GameObject>("Prefabs/BuildingRight");


        // �ǹ� ����
        CreateBuildingsAtPosition(buildingLeft, new Vector3(-20, 0, 0), 10, Quaternion.Euler(0, 90, 0));
        CreateBuildingsAtPosition(buildingRight, new Vector3(20, 0, 0), 10, Quaternion.Euler(0, -90, 0));

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
}