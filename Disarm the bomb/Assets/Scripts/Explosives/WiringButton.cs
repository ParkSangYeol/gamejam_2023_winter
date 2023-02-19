using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiringButton : PuzzleButton
{
    [SerializeField]
    private string key;

    private void OnMouseDown()
    {
        if(isPuzzleUnavailable<WiringPuzzle>()) return;

        PlayEffectSound();
        RequestCheckAnswer<WiringPuzzle>(key);
    }
}
