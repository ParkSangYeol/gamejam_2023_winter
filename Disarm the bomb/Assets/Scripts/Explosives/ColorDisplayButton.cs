using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorDisplayButton : PuzzleButton
{
    [SerializeField]
    private TMP_Text text;

    private void OnMouseDown() 
    {
        if(isPuzzleUnavailable<ColorDisplayPuzzle>()) return;
        
        StartCoroutine(ButtonDown<ColorDisplayPuzzle>());
        PlayEffectSound();
        RequestCheckAnswer<ColorDisplayPuzzle>(text.text);
    }
}
