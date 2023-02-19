using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseButton : PuzzleButton
{
    [SerializeField]
    private string key;

    private void OnMouseDown()
    {
        if(isPuzzleUnavailable<MorseCodePuzzle>()) return;

        StartCoroutine(ButtonDown<MorseCodePuzzle>());
        PlayEffectSound();
        RequestCheckAnswer<MorseCodePuzzle>(key);
    }
}
