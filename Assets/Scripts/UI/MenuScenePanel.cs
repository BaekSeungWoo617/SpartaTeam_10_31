using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScenePanel : MonoBehaviour
{
    [SerializeField] private Button easyBtn;
    [SerializeField] private Button normalBtn;
    [SerializeField] private Button hardBtn;

    private void Start()
    {
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
