using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    string baseText = "HighScore : ";
    int managerHighScore;
    private void Start()
    {
        managerHighScore = GameManager.Instance.highScore;
        HighScoreUpdate(managerHighScore);
    }
    public void HighScoreUpdate(int value)
    {
        // �ڽ� ������Ʈ���� TextMeshProUGUI ������Ʈ�� ã��
        TextMeshProUGUI childText = GetComponentInChildren<TextMeshProUGUI>();

        // TextMeshProUGUI ������Ʈ�� ������ �ؽ�Ʈ�� ����
        if (childText != null)
        {
            childText.text = baseText + value.ToString();
        }
        else
        {
            Debug.LogError("�ڽ� ������Ʈ�� TextMeshProUGUI ������Ʈ�� �����ϴ�!");
        }
    }
}
