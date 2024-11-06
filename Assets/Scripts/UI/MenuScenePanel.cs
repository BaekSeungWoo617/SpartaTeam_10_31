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
        easyBtn.onClick.AddListener(()=>OnClickMenuBtn(1));
        normalBtn.onClick.AddListener(()=>OnClickMenuBtn(2));
        hardBtn.onClick.AddListener(()=>OnClickMenuBtn(3));
    }

    private void OnDestroy()
    {
        easyBtn.onClick.RemoveAllListeners();
        normalBtn.onClick.RemoveAllListeners();
        hardBtn.onClick.RemoveAllListeners();
    }

    private void OnClickMenuBtn(int level)
    {
        AudioManager.Instance.PlayClickSFX();
        GameManager.Instance.playerLevel = level;
        Time.timeScale = 1.0f;  // 일시정지 해제
        SceneManager.LoadScene("PlayScene");
    }
}
