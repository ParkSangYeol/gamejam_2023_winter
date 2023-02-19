using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazePuzzle : Puzzle
{
    [SerializeField]
    private List<Sprite> figures;
    private static readonly Dictionary<string, string> DicForAnswer = new Dictionary<string, string>{
        {"Red Circle", "dddrrul"}, {"Blue Square", "druurdd"}, {"Yellow Circle", "ddddlluru"},
        {"Red Triangle", "rulul"}, {"Blue Triangle", "ldrddll"}, {"Green Square", "rrurull"},
        {"Purple Circle", "rddr"}, {"Black Square", "rddruu"}, {"Green Triangle", "rddru"},
    };
    [SerializeField]
    private Image image;
    private string answer;
    public override void PuzzleInit()
    {
        int randomFigureIndex = Random.Range(0, figures.Count);
        image.sprite = figures[randomFigureIndex];
        answer = DicForAnswer[figures[randomFigureIndex].name];
        print("Maze : " + answer);

        CalculateAllottedTime();
    }

    protected override void CalculateAllottedTime()
    {
        allottedTime = 3f * answer.Length;
    }

    public override void CheckAnswer(string key)
    {
        if(checkUnavailable) return;
        
        if(key[0] == answer[0])
        {
            answer = answer.Remove(0, 1);
            print("Pass");
            if(answer.Length == 0)
            {
                // clear
                print("Clear");
                checkUnavailable = true;
                
                solvedPuzzleCount++;
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
