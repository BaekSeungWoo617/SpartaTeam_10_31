using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    private GameObject _bgmObj;
    private GameObject _sfxObj;

    private AudioSource _bgmSource;
    private AudioSource _sfxSource;
    
    [Header("BGM")]
    [SerializeField] private AudioClip bgmClip;

    [Header("SFX")]
    [SerializeField] private AudioClip collisionSfx;
    [SerializeField] private AudioClip clickSfx;
    
    private void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        
        SetAudioSource();
        SetAudioClip();
    }

    private void SetAudioSource()
    {
        // AudioManager의 자식으로 AudioSource 컴포넌트 가진 @BGM 생성
        _bgmObj = new GameObject("@BGM");
        _bgmObj.transform.parent = transform;
        _bgmSource = _bgmObj.AddComponent<AudioSource>();
        
        // AudioManager의 자식으로 AudioSource 컴포넌트 가진 @SFX 생성
        _sfxObj = new GameObject("@SFX");
        _sfxObj.transform.parent = transform;
        _sfxSource = _sfxObj.AddComponent<AudioSource>();
    }

    private void SetAudioClip()
    {
        // Resource 폴더에서 각 AudioClip에 맞는 파일 로드
        bgmClip = CustomUtil.ResourceLoad<AudioClip>("Audios/BGM_Clip");
        collisionSfx = CustomUtil.ResourceLoad<AudioClip>("Audios/SFX_Collision");
        clickSfx = CustomUtil.ResourceLoad<AudioClip>("Audios/SFX_ButtonClick");
    }

    public void PlayBGM(AudioClip clip)
    {
        if (_bgmSource.clip != clip)
        {
            _bgmSource.clip = clip;
            _bgmSource.loop = true;
            _bgmSource.Play();
        }
    }
    
    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }
    
    public void PlayStartBGM() => PlayBGM(bgmClip);
    public void PlayCollsionSFX() => PlaySFX(collisionSfx);
    public void PlayClickSFX() => PlaySFX(clickSfx);
}
