using UnityEngine;

public class HurdleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hurdlePrefab;
    [SerializeField] private int maxHurdlesPerRoad = 1; // 도로 한 블럭 당 최대 장애물 리스폰 개수
    [SerializeField] private float roadWidth = 8.5f;    // 도로 폭(회색 부분)
    [SerializeField] private float minX;    // 도로 양끝 제한
    [SerializeField] private float maxX;
    
    public void SpawnHurdlesOnRoad(GameObject road)
    {
        Renderer roadRenderer = road.GetComponent<Renderer>();
        if (roadRenderer == null)
        {
            Debug.Log("Road doesn't have a Renderer component.");
            return;
        }

        Bounds roadBounds = roadRenderer.bounds;

        int hurdlesToSpawn = Random.Range(1, maxHurdlesPerRoad + 1);

        for (int i = 0; i < hurdlesToSpawn; i++)
        {
            minX = roadBounds.center.x - roadWidth / 2;
            maxX = roadBounds.center.x + roadWidth / 2;
            float randX = Random.Range(minX, maxX);

            float randZ = Random.Range(roadBounds.min.z, roadBounds.max.z);

            Vector3 spawnPosition = new Vector3(randX, roadBounds.max.y, randZ);

            GameObject hurdle = Instantiate(hurdlePrefab, spawnPosition, Quaternion.identity);

            hurdle.transform.SetParent(road.transform);
        }
    }
}