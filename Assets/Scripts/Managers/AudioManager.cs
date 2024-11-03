using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    }

    private void SetAudioSource()
    {
        _bgmObj = new GameObject("@BGM");
        _bgmObj.transform.parent = transform;
        _bgmSource = _bgmObj.AddComponent<AudioSource>();
        
        _sfxObj = new GameObject("@SFX");
        _sfxObj.transform.parent = transform;
        _sfxSource = _sfxObj.AddComponent<AudioSource>();
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
