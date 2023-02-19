using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript instance;

    [SerializeField]
    private AudioClip gameBackgroundMusic;
    [SerializeField]
    private AudioClip mainMenuBackgroundMusic;
    [SerializeField]
    private AudioClip startGameAudioClip;
    private AudioSource audioSource;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(transform.gameObject);
        audioSource = this.GetComponent<AudioSource>();
    }

    public void  changeMusicToGameScene()
    {
        audioSource.clip = gameBackgroundMusic;
        audioSource.PlayDelayed(1);
        audioSource.PlayOneShot(startGameAudioClip);

    }
    public void changeMusicToMainMenu()
    {
        audioSource.clip = mainMenuBackgroundMusic;
        audioSource.Play();
    }

    public void stopMusic()
    {
        audioSource.Stop();
    }
}
