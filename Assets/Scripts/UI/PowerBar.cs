using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    [SerializeField] private Image powerBarImg;
    private Color normalColor;  // 게이지 차오르기 전 색상(빨강)
    private Color fulledColor;  // 게이지 차오른 색상(파랑)
    private Color powerColor;   // 파워업 적용 중 색상(마젠타)
    
    private void Start()
    {
        powerBarImg.fillAmount = 0f;
        fulledColor = powerBarImg.color;
        normalColor = new Color(1f, 0f, 0f, 1f);
        powerColor = new Color(1f, 0f, 1f, 1f);
    }

    private void Update()
    {
        if (GameManager.Instance.IsPower)   // 파워업 사용중이면
        {
            // 색상 변경하고 남은 파워업 시간 이미지에 반영
            powerBarImg.color = powerColor;
            powerBarImg.fillAmount = GameManager.Instance.GetPowerTime();
            return;
        }

        float guage = GameManager.Instance.GetPowerGauge();
        if (guage <= 1.0f)  // 파워업 게이지 부족하면
        {
            // 색상 변경하고 현재 게이지 수치 이미지에 반영
            powerBarImg.color = normalColor;
            powerBarImg.fillAmount = guage;
            return;
        }
        powerBarImg.color = fulledColor;    // 게이지 차있으면 색상만 변경

    }
}
