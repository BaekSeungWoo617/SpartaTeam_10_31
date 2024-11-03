using System;
using TMPro;
using UnityEngine;

public class PlayTopPanel : MonoBehaviour
{
    private int _life;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject lifePanel;
    
    private void Start()
    {
        // 시작 시 라이프 세팅
        // _life = GameManager.Instance.life;
        _life = 3; // TestCode
        for (int i = 0; i < _life; i++)
        {
            CustomUtil.LoadAndInstantiatePrefab("Prefabs/UI/Objects/lifeImage", lifePanel.transform);
        }
        
        // 점수 변경되는 이벤트 구독
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
        // 라이프 변경되는 이벤트 구독
        GameManager.Instance.OnLifeChanged += DestroyLifeImg;
        // 시작 시 점수판 초기화
        UpdateScoreText(GameManager.Instance.score);
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
    
    /* TestCode */
    // 점수 올라가면 반영되는지 테스트
    // private void Update()
    // {
    //     IncreaseScore();
    // }
    // private void IncreaseScore()
    // {
    //     GameManager.Instance.score++;
    // }
}
