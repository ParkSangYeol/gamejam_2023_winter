using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEventHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject optionPanel;

    public void OnStartGameButtonClick()
    {

    }

    public void OnOpenOptionButtonClick()
    {
        optionPanel.SetActive(true);
    }

    public void OnCloseOptionButtonClick()
    {
        optionPanel.SetActive(false);
    }

    public void OnOpenTutorialButtonClick()
    {

    }

    public void OnExitGameButtonClick()
    {

    }
}
