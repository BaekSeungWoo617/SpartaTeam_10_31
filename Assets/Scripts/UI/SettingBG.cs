using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingBG : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    
    [SerializeField] private Button closeBtn;
    [SerializeField] private Button menuBtn;
    [SerializeField] private Button quitBtn;
    
    private void Start()
    {
        // 초기 볼륨 값 세팅
        bgmSlider.value = AudioManager.Instance.GetBGMVolume();
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();
        
        // 볼륨 슬라이더 조절 시 볼륨 조절 하도록 이벤트 등록
        bgmSlider.onValueChanged.AddListener(AudioManager.Instance.SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
        
        // 닫기 버튼 클릭 시 효과음과 함께 설정창 비활성화
        closeBtn.onClick.AddListener((() =>
        {
            AudioManager.Instance.PlayClickSFX();
            Time.timeScale = 1.0f;  // 일시정지 해제
            gameObject.SetActive(false);
        }));
        
        menuBtn.onClick.AddListener((() =>
        {
            AudioManager.Instance.PlayClickSFX();
            SceneManager.LoadScene("MenuScene");
        }));
        quitBtn.onClick.AddListener(OnClickQuitBtn);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        bgmSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();
        
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