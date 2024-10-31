using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleSpawner : MonoBehaviour
{
    public GameObject[] hurdlePrefabs; // 장애물 프리팹 배열
    public float spawnInterval; // 장애물 스폰 간격
    public float spawnPositionZ; // 장애물 스폰 위치(Z축)
    public float minX; // 스폰 위치 최소 X값
    public float maxX; // 스폰 위치 최대 X값

    void Start()
    {
        StartCoroutine(SpawnHurdle());
    }

    IEnumerator SpawnHurdle()
    {
        while (true)
        {
            // X축의 무작위 위치 결정
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, 0, spawnPositionZ);

            // 무작위로 장애물 프리팹 선택
            int randomIndex = Random.Range(0, hurdlePrefabs.Length);
            GameObject selectedPrefab = hurdlePrefabs[randomIndex];

            // 장애물 생성
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            // 다음 스폰까지 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
