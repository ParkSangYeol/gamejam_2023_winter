using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEventHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject optionPanel;
    [SerializeField]
    private GameObject tutorialPanel;

    public void OnStartGameButtonClick()
    {
        // Move Scene to Disarm the Bomb
        SceneManager.LoadScene("Circuit");
    }

    public void OnOpenOptionButtonClick()
    {
        // Open Option Panel
        optionPanel.SetActive(true);
    }

    public void OnCloseOptionButtonClick()
    {
        // Close Option Panel
        optionPanel.SetActive(false);
    }

    public void OnOpenTutorialButtonClick()
    {
        // Open Tutorial Panel
        tutorialPanel.SetActive(true);
    }

    public void OnCloseTutorialButtonClick()
    {
        // Open Tutorial Panel
        tutorialPanel.SetActive(false);
    }

    public void OnExitGameButtonClick()
    {
        // Exit Game
        Application.Quit();
    }
}
