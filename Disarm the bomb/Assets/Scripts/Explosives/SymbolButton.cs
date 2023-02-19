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
        if(isPuzzleUnavailable<SymbolButtonPuzzle>()) return;

        StartCoroutine(ButtonDown<SymbolButtonPuzzle>());
        PlayEffectSound();
        RequestCheckAnswer<SymbolButtonPuzzle>(text.text);
    }
}
