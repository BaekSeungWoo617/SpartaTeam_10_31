using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Achieve2 : MonoBehaviour
{
    string baseText = "Achieve2(Die) : ";
    bool managerAchieve2;
    private void Start()
    {
        managerAchieve2 = GameManager.Instance.achievement2;
        Achieve2Update(managerAchieve2);
    }
    public void Achieve2Update(bool value)
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
