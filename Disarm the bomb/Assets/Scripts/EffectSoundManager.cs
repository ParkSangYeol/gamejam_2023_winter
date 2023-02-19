using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundManager : MonoBehaviour
{
    public static EffectSoundManager instance;

    [SerializeField]
    private AudioClip buttonAudioClip;
    [SerializeField]
    private AudioClip uiButtonAudioClip;
    [SerializeField]
    private AudioClip redButtonAudioClip;
    [SerializeField]
    private AudioClip warningAudioClip;
    [SerializeField]
    private AudioClip beepAudioClip;
    [SerializeField]
    private AudioClip bombCountAudioClip;
    [SerializeField]
    private AudioClip BombExplosionAudioClip;
    [SerializeField]
    private AudioClip endingAudioClip;

    private AudioSource m_audioSource;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(transform.gameObject);
        m_audioSource = this.GetComponent<AudioSource>();
    }
    public void playButtonAudioClip()
    {
        m_audioSource.clip = buttonAudioClip;
        m_audioSource.Play();
    }
    public void playUIButtonAudioClip()
    {
        m_audioSource.clip = uiButtonAudioClip;
        m_audioSource.Play();
    }
    public void playRedButtonAudioClip()
    {
        m_audioSource.clip = redButtonAudioClip;
        m_audioSource.Play();
    }
    public void playWarningAudioClip()
    {
        m_audioSource.clip = warningAudioClip;
        m_audioSource.Play();
    }
    public void playBeepAudioClip()
    {
        m_audioSource.clip = beepAudioClip;
        m_audioSource.Play();
    }
    public void playBombCountdownAudioClip()
    {
        m_audioSource.clip = bombCountAudioClip;
        m_audioSource.Play();
    }
    public void playBombExplosionAudioClip()
    {
        m_audioSource.clip = BombExplosionAudioClip;
        m_audioSource.Play();
    }
    public void playEndingAudioClip()
    {
        m_audioSource.clip = endingAudioClip;
        m_audioSource.Play();
    }
}
