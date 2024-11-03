using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScenePanel : MonoBehaviour
{
    [SerializeField] private Button easyBtn;
    [SerializeField] private Button normalBtn;
    [SerializeField] private Button hardBtn;

    private void Start()
    {
        // 버튼에 이벤트 한번에 등록
        // Button[] instances = FindObjectsByType<Button>(FindObjectsSortMode.None);
        // foreach (Button btn in instances)
        // {
        //     btn.onClick.AddListener(AudioManager.Instance.PlayClickSFX);
        // }
        
        easyBtn.onClick.AddListener(AudioManager.Instance.PlayClickSFX);
        normalBtn.onClick.AddListener(AudioManager.Instance.PlayClickSFX);
        hardBtn.onClick.AddListener(AudioManager.Instance.PlayClickSFX);
        
        easyBtn.onClick.AddListener((() => { SceneManager.LoadScene("PlayScene"); }));
        normalBtn.onClick.AddListener((() => { SceneManager.LoadScene("PlayScene"); }));
        hardBtn.onClick.AddListener((() => { SceneManager.LoadScene("PlayScene"); }));
    }

    private void OnDestroy()
    {
        easyBtn.onClick.RemoveAllListeners();
        normalBtn.onClick.RemoveAllListeners();
        hardBtn.onClick.RemoveAllListeners();
    }
}
