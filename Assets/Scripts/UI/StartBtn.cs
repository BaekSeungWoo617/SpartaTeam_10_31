using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
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