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
        // 자식 오브젝트에서 TextMeshProUGUI 컴포넌트를 찾기
        TextMeshProUGUI childText = GetComponentInChildren<TextMeshProUGUI>();

        // TextMeshProUGUI 컴포넌트가 있으면 텍스트를 수정
        if (childText != null)
        {
            childText.text = baseText + value.ToString();
        }
        else
        {
            Debug.LogError("자식 오브젝트에 TextMeshProUGUI 컴포넌트가 없습니다!");
        }
    }
}
