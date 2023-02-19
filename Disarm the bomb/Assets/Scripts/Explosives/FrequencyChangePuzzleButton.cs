using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyChangePuzzleButton : PuzzleButton
{
    [SerializeField]
    private int change;
    private void OnMouseDown()
    {
        if (isPuzzleUnavailable<FrequencyModuleDisplayScript>()) return;

        StartCoroutine(ButtonDown<FrequencyModuleDisplayScript>());
        PlayEffectSound();
        if (change != 0)
        {
            GetPuzzle<FrequencyModuleDisplayScript>().changeText(change);
        }
        else
        {
            RequestCheckAnswer<FrequencyModuleDisplayScript>("");
        }
    }
}
