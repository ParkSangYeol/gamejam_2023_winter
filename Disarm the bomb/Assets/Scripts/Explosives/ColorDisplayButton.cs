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
        StartCoroutine(ButtonDown<ColorDisplayPuzzle>());

        RequestCheckAnswer<ColorDisplayPuzzle>(text.text);
    }
}
