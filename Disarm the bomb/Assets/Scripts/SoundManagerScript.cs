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
    }

    public void  changeMusicToGameScene()
    {
        this.GetComponent<AudioSource>().clip = gameBackgroundMusic;
        this.GetComponent<AudioSource>().PlayDelayed(1);
        this.GetComponent<AudioSource>().PlayOneShot(startGameAudioClip);

    }
    public void changeMusicToMainMenu()
    { 
        this.GetComponent<AudioSource>().clip = mainMenuBackgroundMusic;
        this.GetComponent<AudioSource>().Play();
    }
}
