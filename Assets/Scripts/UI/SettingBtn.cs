using UnityEngine;

public class SettingBtn : MonoBehaviour
{
    [SerializeField] private GameObject settingBg;

    private void Start()
    {
        // 설정창 생성    
        settingBg = Instantiate(settingBg, gameObject.transform.parent);
    }

    public void OnClickSettingBtn()
    {
        // 설정 버튼 클릭 시 효과음과 함께 설정 팝업 활성화
        AudioManager.Instance.PlayClickSFX();
        settingBg.SetActive(true);
    }
}
