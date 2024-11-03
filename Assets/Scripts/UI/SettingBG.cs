using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingBG : MonoBehaviour
{
    [SerializeField] private Button closeBtn;
    [SerializeField] private Button quitBtn;
    
    private void Start()
    {
        // 닫기 버튼 클릭 시 효과음과 함께 설정창 비활성화
        closeBtn.onClick.AddListener((() =>
        {
            AudioManager.Instance.PlayClickSFX();
            gameObject.SetActive(false);
        }));
        
        quitBtn.onClick.AddListener(OnClickQuitBtn);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        closeBtn.onClick.RemoveAllListeners();
        quitBtn.onClick.RemoveAllListeners();
    }

    private void OnClickQuitBtn()
    {
        AudioManager.Instance.PlayClickSFX();
        
        #if UNITY_EDITOR    // 에디터 상에서 플레이 종료
            UnityEditor.EditorApplication.isPlaying = false;
        #else   // 실제 게임 플레이 시 실행 종료
            Application.Quit(); 
        #endif    
    }
}