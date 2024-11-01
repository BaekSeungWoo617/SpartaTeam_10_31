using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverBG : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        GameManager.Instance.OnGameOver += ShowGameOverBG;
        this.gameObject.SetActive(false);
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
}
