using TMPro;
using UnityEngine;

public class ScoreBG : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Start()
    {
        // 자식 오브젝트로 있는 텍스트 컴포넌트 가져오기
        _scoreText = GetComponentInChildren<TMP_Text>();
        // 점수 변경되는 이벤트 구독
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
        // 시작 시 점수판 초기화
        UpdateScoreText(GameManager.Instance.score);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= UpdateScoreText;
        }
    }

    private void UpdateScoreText(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }
}