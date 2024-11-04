using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    /* StartScene에서 시작 버튼 생성하며 AudioManager DonDestroyOnLoad로 생성 */

    private void Start()
    {
        AudioManager.Instance.PlayStartBGM();
    }

    public void GameStart()
    {
        AudioManager.Instance.PlayClickSFX();
        SceneManager.LoadScene("MenuScene");
    }
}