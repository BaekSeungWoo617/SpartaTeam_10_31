using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverBG : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private Button retryBtn;
    
    private void Start()
    {
        GameManager.Instance.OnGameOver += ShowGameOverBG;
        gameObject.SetActive(false);
        
        // 재시작 버튼 클릭 시 현재 Scene 다시 로드
        retryBtn.onClick.AddListener(()=>SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        
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
        gameObject.SetActive(true);
    }
    
    /* TestCode */
    // GameOver 시 팝업 활성화되고 재시작 버튼 작동하는지 확인
    private void MakeGameOver()
    {
        GameManager.Instance.GameOver();
    }
}
