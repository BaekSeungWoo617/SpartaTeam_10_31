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
        // 설정 버튼 클릭 시 설정 팝업 활성화
        settingBg.SetActive(true);
    }
}
