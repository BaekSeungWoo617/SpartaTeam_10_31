using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Achieve1 : MonoBehaviour
{
    string baseText = "Achieve1(Score50) : ";
    bool managerAchieve1;
    private void Start()
    {
        managerAchieve1 = GameManager.Instance.achievement1;
        Achieve1Update(managerAchieve1);
    }
    public void Achieve1Update(bool value)
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
