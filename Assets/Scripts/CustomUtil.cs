using UnityEngine;

public static class CustomUtil
{
    public static T ResourceLoad<T>(string path) where T : Object
    {
        T instance = Resources.Load<T>(path);
        if (instance == null)
        {
            Debug.Log($"{typeof(T).Name} not found in Resources folder at {path}.");
        }
        return instance;
    }
    
    // Resources 폴더에서 이름으로 지정된 하나의 프리팹을 로드하고 추가
    public static void LoadAndInstantiatePrefab(string prefabName, Transform parent)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        if (prefab != null)
        {
            GameObject instance = Object.Instantiate(prefab, parent);
            instance.name = prefab.name;
        }
        else
        {
            Debug.Log($"Prefab '{prefabName}' not found in Resources folder.");
        }
    }

    // Resources의 지정된 폴더에서 모든 프리팹을 로드하고 인스턴스화
    public static void LoadAndInstantiatePrefabs(string resourceFolder, Transform parent)
    {
        GameObject[] prefabs = Resources.LoadAll<GameObject>(resourceFolder);
        foreach (GameObject prefab in prefabs)
        {
            if (prefab != null)
            {
                GameObject instance = Object.Instantiate(prefab, parent);
                instance.name = prefab.name;
                instance.SetActive(true);
            }
        }
    }
}