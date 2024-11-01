using TMPro;
using UnityEngine;

public class GameOverBG : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        GameManager.Instance.OnGameOver += ShowGameOverBG;
        this.gameObject.SetActive(false);
        
        // Test
        // 1초 뒤에 게임오버 되면 팝업 뜨는지 확인
        // Invoke("MakeGameOver", 1.0f);
    }
    
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameOver -= ShowGameOverBG;
        }
    }

    private void ShowGameOverBG()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        highscoreText.text = GameManager.Instance.highScore.ToString();
        this.gameObject.SetActive(true);
    }
    
    /* TestCode */
    // GameOver 시 팝업 활성화되고 재시작 버튼 작동하는지 확인
    private void MakeGameOver()
    {
        GameManager.Instance.GameOver();
    }
}
