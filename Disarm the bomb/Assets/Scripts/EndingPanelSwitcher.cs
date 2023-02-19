using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingPanelSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject clearPanel;
    [SerializeField]
    private GameObject failPanel;
    
    public void TurnClearPanelOn()
    {
        LightOff();
        clearPanel.SetActive(true);
        Destroy(FindObjectOfType<LEDProgressor>().gameObject);
        
        // Play Music
        // ...
        EffectSoundManager.instance.playEndingAudioClip();
    }

    public void TurnFailPanelOn()
    {
        LightOff();
        failPanel.SetActive(true);
        Destroy(FindObjectOfType<LEDProgressor>().gameObject);
        
        // Play Music
        // ...
    }

    private void LightOff()
    {
        GameObject.Find("Directional Light").SetActive(false);
    }

    public void ReloadCircuit()
    {
        SceneManager.LoadScene("circuit");
        SoundManagerScript.instance.changeMusicToGameScene();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
        SoundManagerScript.instance.changeMusicToMainMenu();
    }
}
