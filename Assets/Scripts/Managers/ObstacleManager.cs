using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : SingletonBase<ObstacleManager>
{
    private GameObject[] hurdlePrefabs;
    [SerializeField] private int hurdlePerRoad; // 하나의 Road 내에 생성할 장애물 수
    private float minZ = 10f;   // 장애물 생성 시작 지점
    private float maxZ = 200f;  // 장애물 생성 종료 지점

    protected void Awake()
    {
        base.Awake();
    }
    
    private void Start()
    {
        // "Prefabs/Building"에서 모든 건물 프리팹 로드
        hurdlePrefabs = CustomUtil.ResourceLoadAll<GameObject>("Prefabs/Huddle");

        /* 플레이어 레벨(선택한 난이도)에 따라 장애물 개수 변동 */
        // Easy(10), Normal(15), Hard(20) 
        /* TestCode */
        // GameManager.Instance.playerLevel = 1;
        // GameManager.Instance.playerLevel = 2;
        // GameManager.Instance.playerLevel = 3;

        int lev = GameManager.Instance.playerLevel;
        hurdlePerRoad = 5 * (lev + 1);
        
        // 장애물 생성
        CreateHurdlesOnRoad(hurdlePerRoad);
    }

    private void CreateHurdlesOnRoad(int count)
    {
        float intervalZ = (maxZ - minZ) / (count - 1);
        
        for (int i = 0; i < count; i++)
        {
            // 랜덤한 장애물 프리팹 선택
            GameObject randomPrefab = hurdlePrefabs[Random.Range(0, hurdlePrefabs.Length)];
            
            // 위치 생성
            // 도로 너비 내에서 X축을 랜덤하게 설정, 기준점(0) 중심으로 좌우로 배치
            // Z축은 일정한 간격으로 배치
            float zPosition = minZ + (i * intervalZ);
            Vector3 hurdlePosition = new Vector3(Random.Range(-5f, 5f), 0, zPosition);
            
            // 인스턴스화
            GameObject hurdleInstance = Instantiate(randomPrefab, hurdlePosition, Quaternion.identity);

            // 리스트에 추가
            // hurdleInstances.Add(hurdleInstance);
        }
    }

    // public void ResetHurdles()
    // {
    //     foreach (var hurdle in hurdleInstances)
    //     {
    //         hurdle.SetActive(true);
    //         hurdle.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 100);
    //     }
    // }
}