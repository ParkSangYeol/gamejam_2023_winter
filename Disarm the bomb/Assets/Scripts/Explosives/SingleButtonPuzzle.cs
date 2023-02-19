using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButtonPuzzle : Puzzle
{
    public override void PuzzleInit()
    {

        CalculateAllottedTime();
        return;
    }

    protected override void CalculateAllottedTime()
    {
        allottedTime = 10f;
    }

    public override void CheckAnswer(string text)
    {
        
    }
}
