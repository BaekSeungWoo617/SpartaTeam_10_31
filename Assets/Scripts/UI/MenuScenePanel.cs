using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScenePanel : MonoBehaviour
{
    [SerializeField] private Button easyBtn;
    [SerializeField] private Button normalBtn;
    [SerializeField] private Button hardBtn;

    private void Awake()
    {
        // 효과음과 함께 각 난이도별 Scene으로 넘어가는 이벤트 등록
        
        // easyBtn.onClick.AddListener(AudioManager.Instance.PlayClickSFX);
        // normalBtn.onClick.AddListener(AudioManager.Instance.PlayClickSFX);
        // hardBtn.onClick.AddListener(AudioManager.Instance.PlayClickSFX);
        
        // easyBtn.onClick.AddListener((() => { SceneManager.LoadScene("PlayScene"); }));
        // normalBtn.onClick.AddListener((() => { SceneManager.LoadScene("PlayScene"); }));
        // hardBtn.onClick.AddListener((() => { SceneManager.LoadScene("PlayScene"); }));
        
        easyBtn.onClick.AddListener((() =>
        {
            GameManager.Instance.playerLevel = 1;
            GameManager.Instance.GameStartSettings(1);
            OnClickMenuBtn();
            Time.timeScale = 1f;
        }));
        normalBtn.onClick.AddListener((() =>
        {
            GameManager.Instance.playerLevel = 2;
            GameManager.Instance.GameStartSettings(2);
            OnClickMenuBtn();
            Time.timeScale = 1f;

        }));
        hardBtn.onClick.AddListener((() =>
        {
            GameManager.Instance.playerLevel = 3;
            GameManager.Instance.GameStartSettings(3);
            OnClickMenuBtn();
            Time.timeScale = 1f;

        }));
        
    }

    private void OnDestroy()
    {
        easyBtn.onClick.RemoveAllListeners();
        normalBtn.onClick.RemoveAllListeners();
        hardBtn.onClick.RemoveAllListeners();
    }

    private void OnClickMenuBtn()
    {
        AudioManager.Instance.PlayClickSFX();
        SceneManager.LoadScene("PlayScene");
        
    }
}
