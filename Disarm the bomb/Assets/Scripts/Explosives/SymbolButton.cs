using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SymbolButton : PuzzleButton
{
    [SerializeField]
    private TMP_Text text;

    private void OnMouseDown() 
    {
        StartCoroutine(ButtonDown<SymbolButtonPuzzle>());

        RequestCheckAnswer<SymbolButtonPuzzle>(text.text);
    }
}
