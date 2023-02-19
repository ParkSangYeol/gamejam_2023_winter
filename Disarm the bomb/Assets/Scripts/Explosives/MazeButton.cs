using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeButton : PuzzleButton
{
    [SerializeField]
    private string key;

    private void OnMouseDown()
    {
        if(isPuzzleUnavailable<MazePuzzle>()) return;
        
        StartCoroutine(ButtonDown<MazePuzzle>());
        PlayEffectSound();
        RequestCheckAnswer<MazePuzzle>(key);
    }
}
