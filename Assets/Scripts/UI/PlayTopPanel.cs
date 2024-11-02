using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayTopPanel : MonoBehaviour
{
    private int _life;
    [SerializeField] private Button settingBtn;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject lifePanel;
    [SerializeField] private GameObject settingBg;
    
    private void Start()
    {
        // 설정창 생성    
        settingBg = Instantiate(settingBg, gameObject.transform.parent);
        // 설정 버튼 클릭 시 설정 팝업 활성화
        settingBtn.onClick.AddListener(()=>settingBg.SetActive(true));
        
        // 시작 시 라이프 세팅
        //_life = GameManager.Instance.life;
         _life = 3; // TestCode
        for (int i = 0; i < _life; i++)
        {
            UIManager.Instance.LoadAndInstantiatePrefab("Prefabs/UI/Objects/lifeImage", lifePanel.transform);
        }

        // 점수 변경되는 이벤트 구독
        GameManager.Instance.OnScoreChanged += UpdateScoreText;
        // 시작 시 점수판 초기화
        UpdateScoreText(GameManager.Instance.score);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= UpdateScoreText;
        }
    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
    /* TestCode */
    // 점수 올라가면 반영되는지 테스트
    // private void Update()
    // {
    //     IncreseScore();
    // }
    // private void IncreseScore()
    // {
    //     GameManager.Instance.score++;
    // }
}
