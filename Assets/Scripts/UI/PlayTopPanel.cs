using System;
using TMPro;
using UnityEngine;

public class PlayTopPanel : MonoBehaviour
{
    private int _life;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject lifePanel;
    
    private void Awake()
    {
        // 점수 변경되는 이벤트 구독
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
        // 라이프 변경되는 이벤트 구독
        GameManager.Instance.OnLifeChanged += DestroyLifeImg;
        // 시작 시 점수판 초기화
        UpdateScoreText(GameManager.Instance.score);
    }

    private void Start()
    {
        // 시작 시 라이프 세팅
        _life = GameManager.Instance.life;
        for (int i = 0; i < _life; i++)
        {
            CustomUtil.LoadAndInstantiatePrefab("Prefabs/UI/Objects/lifeImage", lifePanel.transform);
        }
        scoreText.text = "0";   // 점수판 숫자 초기화
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnScoreChanged -= UpdateScoreText;
        GameManager.Instance.OnLifeChanged -= DestroyLifeImg;
    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();   // 점수판 숫자 갱신
    }

    private void DestroyLifeImg()
    {
        // 라이프 패널 자식 오브젝트(라이프 이미지)를 파괴
        GameObject go = lifePanel.transform.GetChild(0).gameObject;
        if (go == null)
        {
            Debug.Log("Null Reference LifeImg");
            return;
        }
        Destroy(go);
    }   
}
