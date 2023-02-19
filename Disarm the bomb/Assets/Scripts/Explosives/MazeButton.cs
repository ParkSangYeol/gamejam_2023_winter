using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeButton : PuzzleButton
{
    [SerializeField]
    private string key;

    private void OnMouseDown()
    {
        StartCoroutine(ButtonDown<MazePuzzle>());

        RequestCheckAnswer<MazePuzzle>(key);
    }
}
