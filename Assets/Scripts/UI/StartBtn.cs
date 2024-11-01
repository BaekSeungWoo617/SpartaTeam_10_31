using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void OnStartBtnClicked()
    {
        UIManager.Instance.DisableAllUI();
        SceneManager.LoadScene("PlayScene");
        Debug.Log("Start");
    }
}