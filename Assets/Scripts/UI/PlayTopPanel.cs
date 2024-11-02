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
        //_life = GameManager.Instance.life;
         _life = 3; // TestCode
        for (int i = 0; i < _life; i++)
        {
            UIManager.Instance.LoadAndInstantiatePrefab("Prefabs/UI/Objects/lifeImage", lifePanel.transform);
        }

        // 점수 변경되는 이벤트 구독
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
        // 시작 시 점수판 초기화
        UpdateScoreText(GameManager.Instance.score);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
    /* TestCode */
    // 점수 올라가면 반영되는지 테스트
    // private void Update()
    // {
    //     IncreseScore();
    // }
    // private void IncreseScore()
    // {
    //     GameManager.Instance.score++;
    // }
}
