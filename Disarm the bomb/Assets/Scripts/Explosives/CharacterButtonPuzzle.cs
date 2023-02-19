using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterButtonPuzzle : Puzzle
{
    private static readonly Dictionary<int, (string, string)> DicForCharacter = new Dictionary<int, (string, string)>{
        {0, ("fjord", "fjordvexz")}, {1, ("swirl", "swirlaqbt")}, {2, ("gusty", "gustypklm")},
        {3, ("quack", "quackrstd")}, {4, ("hymns", "hymnszwxc")}, {5, ("brisk", "briskujmh")},
        {6, ("plush", "plushqazx")}, {7, ("yacht", "yachtnmki")}, {8, ("lucks", "lucksedfr")},
        {9, ("wreck", "wreckyuhi")}, {10, ("coven", "covenkmij")}, {11, ("glaze", "glazebvcx")},
        {12, ("shunt", "shuntygfd")}, {13, ("spicy", "spicytgbr")}, {14, ("crave", "craveijkl")},
        {15, ("fable", "fablevcxs")}, {16, ("skimp", "skimpolnh")}, {17, ("prawn", "prawnzxcv")},
        {18, ("plaid", "plaidgfer")}, {19, ("chant", "chantqwey")}, {20, ("scowl", "scowlmnhy")},
        {21, ("bumps", "bumpsijko")}, {22, ("blunt", "bluntzxcv")}, {23, ("flair", "flairuymj")},
        {24, ("plume", "plumedcfq")}
    };
    [SerializeField]
    private List<CharacterButton> buttons = new List<CharacterButton>();
    private (string, string) answerSet;
    private string answer;

    public override void PuzzleInit()
    {
        int randomIndex = Random.Range(0, DicForCharacter.Count);
        answerSet = DicForCharacter[randomIndex];
        answer = answerSet.Item1;
        string shuffledString = ShuffleString(answerSet.Item2);
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].PutText(shuffledString[i].ToString());
        }
        print(answerSet.Item1);

        CalculateAllottedTime();
    }

    protected override void CalculateAllottedTime()
    {
        allottedTime = 40f;
    }

    public static string ShuffleString(string str)
    {
        string ret = "";
        while(str.Any())
        {
            int random = Random.Range(0, str.Length);
            ret += str[random];
            str = str.Remove(random, 1);
        }
        return ret;
    }

    public override void CheckAnswer(string text)
    {
        if(checkUnavailable) return;
        
        if(text[0] == answer[0])
        {
            answer = answer.Remove(0, 1);
            print("Pass");
            if(answer.Length == 0)
            {
                // clear
                print("Clear");
                checkUnavailable = true;
            }
        }
        else
        {
            //fail
            print("Fail");
            checkUnavailable = true;
        }
    }
}
