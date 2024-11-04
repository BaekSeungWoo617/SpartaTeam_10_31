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
        // "Prefabs/Building"���� ��� �ǹ� ������ �ε�
        buildingPrefabs = Resources.LoadAll<GameObject>("Prefabs/Building");

        // �ǹ� ����
        CreateBuildingsAtPosition(new Vector3(20, 0, 0), 10); // �����ʿ� ��ġ
        CreateBuildingsAtPosition(new Vector3(-20, 0, 0), 10); // ���ʿ� ��ġ
    }

    private void CreateBuildingsAtPosition(Vector3 startPosition, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // ������ �ǹ� ������ ����
            GameObject randomPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];

            // ��ġ ����
            Vector3 buildingPosition = startPosition + new Vector3(0, 0, i * 20);

            // �ν��Ͻ�ȭ
            GameObject buildingInstance = Instantiate(randomPrefab, buildingPosition, Quaternion.identity);

            // ����Ʈ�� �߰�
            buildingInstances.Add(buildingInstance);
        }
    }
}