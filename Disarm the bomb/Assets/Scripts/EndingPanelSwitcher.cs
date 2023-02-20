using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingPanelSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject clearPanel;
    [SerializeField]
    private GameObject failPanel;
    
    public void TurnClearPanelOn(int numOfCorrectAnswer)
    {
        LightOff();
        clearPanel.SetActive(true);
        Destroy(FindObjectOfType<LEDProgressor>().gameObject);

        // Play Music
        // ...
        int resultTime = GameObject.Find("timer display").GetComponent<Timer>().stopTimer();
        TMP_Text[] texts = clearPanel.GetComponentsInChildren<TMP_Text>();
        texts[1].text = "걸린시간 : " + resultTime + "초, 맞힌 문제 : " + numOfCorrectAnswer + "문제";
    }

    public void TurnFailPanelOn(int numOfCorrectAnswer)
    {
        LightOff();
        failPanel.SetActive(true);
        Destroy(FindObjectOfType<LEDProgressor>().gameObject);

        // Play Music
        // ...
        int resultTime = GameObject.Find("timer display").GetComponent<Timer>().getResultTime();
        TMP_Text[] texts = failPanel.GetComponentsInChildren<TMP_Text>();
        texts[1].text = "맞힌 문제 : " + numOfCorrectAnswer + "문제";
    }

    private void LightOff()
    {
        GameObject.Find("Directional Light").SetActive(false);
    }

    public void ReloadCircuit()
    {
        Puzzle.solvedPuzzleCount = 0;
        SceneManager.LoadScene("circuit");
        SoundManagerScript.instance.changeMusicToGameScene();
    }

    public void BackToMain()
    {
        Puzzle.solvedPuzzleCount = 0;
        SceneManager.LoadScene("MainMenu");
        SoundManagerScript.instance.changeMusicToMainMenu();
    }
}
