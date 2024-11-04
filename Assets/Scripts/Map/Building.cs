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

        // �ε�� �����յ��� ����Ʈ�� �ν��Ͻ�ȭ�Ͽ� �߰�
        foreach (GameObject roadPrefab in roadPrefabs)
        {
            // �ν��Ͻ�ȭ
            GameObject roadInstance = Instantiate(roadPrefab);
            // ����Ʈ�� �߰�
            roadInstances.Add(roadInstance);
        }
    }
}
