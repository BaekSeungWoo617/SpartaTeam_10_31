using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBase<UIManager>
{
    private GameObject _rootUI;
    private Canvas _canvas;

    protected override void Awake()
    {
        base.Awake();

        if (_rootUI == null)
        {
            CreateUIRoot();
        }

        DontDestroyOnLoad(gameObject);
    }

    // Canvas 아래에 UI 요소를 초기화하고 로드
    private void SettingUI(Transform parentCanvas)
    {
        // 지정된 Resources 폴더에서 모든 프리팹을 로드하고 인스턴스화
        LoadAndInstantiatePrefabs("Prefabs/UI", parentCanvas);
    }

    // 루트 UI GameObject와 Canvas 구조를 생성
    private void CreateUIRoot()
    {
        // UI의 루트 GameObject를 생성하고 UI로 이름 설정
        _rootUI = new GameObject("UI");

        // Canvas 생성하고 랜더링 모드 설정
        GameObject canvasObject = new GameObject("Canvas");
        _canvas = canvasObject.AddComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // 해상도 대응
        CanvasScaler scaler = canvasObject.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);

        // UI 상호작용을 처리위한 컴포넌트 추가
        canvasObject.AddComponent<GraphicRaycaster>();

        canvasObject.transform.SetParent(_rootUI.transform);
        
        SettingUI(canvasObject.transform);
    }
    
    // Resources 폴더에서 이름으로 지정된 하나의 프리팹을 로드하고 추가
    private void LoadAndAddPrefab(string prefabName, Transform parent)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);

        if (prefab != null)
        {
            GameObject instance = Instantiate(prefab, parent);
            instance.name = prefab.name;
        }
        else
        {
            Debug.Log($"Prefab '{prefabName}' not found in Resources folder.");
        }
    }
    
    // Resources의 지정된 폴더에서 모든 프리팹을 로드하고 인스턴스화
    private void LoadAndInstantiatePrefabs(string resourceFolder, Transform parent)
    {
        GameObject[] prefabs = Resources.LoadAll<GameObject>(resourceFolder);

        foreach (GameObject prefab in prefabs)
        {
            if (prefab != null)
            {
                GameObject go = Instantiate(prefab, parent);
                go.name = prefab.name;
                go.SetActive(true);
            }
        }
    }
}