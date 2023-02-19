using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SymbolButtonPuzzle : Puzzle
{
    private static readonly List<string> CharactersByLevel = new List<string>{"ξψ‡¤ĦÞŦДЮБÆζ‰ЩЖ", "æ§¶ß∞ЁΓø", "đŧł"};
    private static readonly List<string> CharactersByGroup = new List<string>{ "ßđξ§‡æψ¶", "Þŧ¤øĦđ§∞", "ΓŦłЁđЮæД", "Æ∞БŧΓł¶ζ", "łЩЁЖ‰ŧøß" };
    private string displayedText = "";
    private string selectedString;
    private int levelSum = 0;

    [SerializeField]
    private List<TMP_Text> texts;

    private List<int> answer = new List<int>();
    public override void PuzzleInit()
    {
        // choose answer
        int randomGroupIndex = Random.Range(0, CharactersByGroup.Count);
        selectedString = CharactersByGroup[randomGroupIndex];

        for(int i = 0; i < 4; i++)
        {
            int stringIndex = Random.Range(0, selectedString.Length);
            displayedText += selectedString[stringIndex];
            // display text
            texts[i].text = displayedText[i].ToString();

            // calculate levelSum
            for(int charLevel = 0; charLevel < 3; charLevel++)
            {
                if(CharactersByLevel[charLevel].Contains(selectedString[stringIndex]))
                {
                    levelSum += charLevel;
                    break;
                }
            }

            answer.Add(CharactersByGroup[randomGroupIndex].IndexOf(selectedString[stringIndex]));

            selectedString = selectedString.Remove(stringIndex, 1);
        }

        selectedString = CharactersByGroup[randomGroupIndex];
        answer.Sort();

        print("Symbol : " + selectedString[answer[0]] + selectedString[answer[1]] + selectedString[answer[2]] + selectedString[answer[3]]);

        CalculateAllottedTime();
    }

    protected override void CalculateAllottedTime()
    {
        allottedTime = 30f + levelSum * 5f;
    }

    public override void CheckAnswer(string text)
    {
        if(checkUnavailable) return;

        int num = selectedString.IndexOf(text[0]);
        if(num == answer[0])
        {
            answer.RemoveAt(0);
            print("Pass");
            if(answer.Count == 0)
            {
                // clear
                print("Clear");
                checkUnavailable = true;
                
                solvedPuzzleCount++;
                
                LEDProgressor.instance.PuzzleSolved();
                EffectSoundManager.instance.playBeepAudioClip();
            }
        }
        else
        {
            //fail
            print("Fail");
            checkUnavailable = true;

            LEDProgressor.instance.PuzzleFailed();

            EffectSoundManager.instance.playWarningAudioClip();
        }
    }
}
