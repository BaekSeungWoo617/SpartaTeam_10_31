using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("MenuScene");
    }
}