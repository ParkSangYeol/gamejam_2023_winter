using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignButtonPuzzle : Puzzle
{
    private static readonly List<string> CharactersByLevel = new List<string>{"ξψ‡¤ĦÞŦДЮБÆζ‰ЩЖ", "æ§¶ß∞ЁΓø", "đŧł"};
    private static readonly List<string> CharactersByGroup = new List<string>{"ξψ‡đæ§¶ß", "¤ĦÞđŧ§∞ø", "ŦДЮđłæЁΓ", "БÆζŧł¶∞Γ", "‰ЩЖŧłßЁø"};
    private string answer = "";
    private int levelSum = 0;

    public override void PuzzleInit()
    {
        // choose answer
        int randomGroupIndex = Random.Range(0, CharactersByGroup.Count);
        string selectedString = CharactersByGroup[randomGroupIndex];
        
        for(int i = 0; i < 4; i++)
        {
            int stringIndex = Random.Range(0, selectedString.Length);
            answer += selectedString[stringIndex];

            // calculate levelSum
            for(int charLevel = 0; charLevel < 3; charLevel++)
            {
                if(CharactersByLevel[charLevel].Contains(selectedString[stringIndex]))
                {
                    levelSum += charLevel;
                    break;
                }
            }

            selectedString.Remove(stringIndex, 1);
        }
    }

    protected override void CalculateAllottedTime()
    {
        allottedTime = 30f + levelSum * 5f;
    }
}
