using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButtonPuzzle : Puzzle
{
    int targetNumber;
    Timer timer;

    private void Start()
    {
        timer = GameObject.Find("TNT/circuitboard/timer display").GetComponent<Timer>();
    }

    public override void PuzzleInit()
    {
        switch(BatteryRandomizer.activeBatteryNumber)
        {
            case 0:
                targetNumber = 0;
                break;
            case 1:
                targetNumber = 5;
                break;
            case 2:
                targetNumber = 1;
                break;
            case 3:
                targetNumber = 8;
                break;
            case 4:
                targetNumber = 2;
                break;
            default:
                targetNumber = -1;
                break;
        }
        if(targetNumber == -1) return;

        print("Single Btn : " + targetNumber);

        CalculateAllottedTime();
    }

    protected override void CalculateAllottedTime()
    {
        allottedTime = 10f;
    }

    public override void CheckAnswer(string text = "")
    {
        string timeText = timer.getTime();
        if(timeText.Contains(targetNumber.ToString()) && solvedPuzzleCount == PuzzlePlacer.GetPuzzleCount() - 1)
        {
            // Clear
            print("CLear");

            solvedPuzzleCount++;
            
            LEDProgressor.instance.PuzzleSolved();
            EffectSoundManager.instance.playBeepAudioClip();
        }
        else
        {
            // Fail
            print("Fail");
            
            LEDProgressor.instance.PuzzleFailed();

            EffectSoundManager.instance.playWarningAudioClip();
        }
        checkUnavailable = true;
    }
}
