using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    private AudioSource _audioSource;
    public AudioClip audioClip;

    void Start()
    {

    }
}