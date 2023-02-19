using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterButton : PuzzleButton
{
    [SerializeField]
    private TMP_Text text;

    public void PutText(string text)
    {
        this.text.text = text;
    }

    private void OnMouseDown()
    {
        StartCoroutine(ButtonDown<CharacterButtonPuzzle>());

        RequestCheckAnswer<CharacterButtonPuzzle>(text.text);
    }
}
