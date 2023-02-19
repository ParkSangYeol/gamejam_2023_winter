using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MorseCodePuzzle : Puzzle
{
    [SerializeField]
    private TMP_Text indicator;
    // Morse Rule
    // line => 0 ─
    // dot => 1 ·
    private static readonly Dictionary<int, (string, string)> DicForMorse = new Dictionary<int, (string, string)>{
        {0, ("001 111 010", "0101111110")}, {1, ("010 01 010", "1011101")}, {2, ("1001 1111 110", "11011111101")},
        {3, ("001 0 1101", "10011111")}, {4, ("001 1 010", "100000")}, {5, ("1011 111 010", "011101011")},
        {6, ("1011 110", "100010")}, {7, ("010 101 1101", "00101011")}, {8, ("010 011 1101", "0011111")},
        {9, ("00 110 1101", "10010010")}
    };
    private static readonly Dictionary<char, string> DicForDecoder = new Dictionary<char, string>{
        {'0', "─"}, {'1', "·"}, {' ', ""}, {'e', "───"}
    };
    private string displayedMorse;
    private string answer;
    private float displayInterval = 0.6f;

    public override void PuzzleInit()
    {
        int randomIndex = Random.Range(0, DicForMorse.Count);
        displayedMorse = DicForMorse[randomIndex].Item1;
        answer = DicForMorse[randomIndex].Item2;

        print("MorseCode : " + answer);

        StartCoroutine(MorseIndicator());

        CalculateAllottedTime();
    }

    private IEnumerator MorseIndicator()
    {
        string prompter = displayedMorse;
        while(!checkUnavailable)
        {
            indicator.text = DicForDecoder[prompter[0]];
            prompter = prompter.Remove(0, 1);
            yield return new WaitForSeconds(displayInterval);
            
            indicator.text = "";
            yield return new WaitForSeconds(displayInterval/2);

            if(prompter.Length == 0)
            {
                prompter = " e " + displayedMorse;
            }
        }
    }

    protected override void CalculateAllottedTime()
    {
        allottedTime = 40f;
    }

    public override void CheckAnswer(string text)
    {
        if(checkUnavailable) return;
        
        if(text[0] == answer[0])
        {
            answer = answer.Remove(0, 1);
            if(answer.Length == 0)
            {
                // clear
                print("Clear");
                checkUnavailable = true;

                solvedPuzzleCount++;

                EffectSoundManager.instance.playBeepAudioClip();

                LEDProgressor.instance.PuzzleSolved();
            }
        }
        else
        {
            //fail
            print("Fail");
            checkUnavailable = true;

            EffectSoundManager.instance.playWarningAudioClip();

            LEDProgressor.instance.PuzzleFailed();
            
        }
    }
}
