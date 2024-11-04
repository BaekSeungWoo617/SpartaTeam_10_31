using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleSpawner : MonoBehaviour
{
    public GameObject[] hurdlePrefabs; // ��ֹ� ������ �迭
    public float spawnInterval; // ��ֹ� ���� ����
    public float spawnPositionZ; // ��ֹ� ���� ��ġ(Z��)
    public float minX; // ���� ��ġ �ּ� X��
    public float maxX; // ���� ��ġ �ִ� X��

    void Start()
    {
        StartCoroutine(SpawnHurdle());
    }

    IEnumerator SpawnHurdle()
    {
        while (true)
        {
            // X���� ������ ��ġ ����
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, 0, spawnPositionZ);

            // �������� ��ֹ� ������ ����
            int randomIndex = Random.Range(0, hurdlePrefabs.Length);
            GameObject selectedPrefab = hurdlePrefabs[randomIndex];

            // ��ֹ� ����
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            // ���� �������� ���
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
