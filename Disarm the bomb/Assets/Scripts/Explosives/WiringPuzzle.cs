using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiringPuzzle : Puzzle
{
    [SerializeField]
    private List<Material> materialList;
    [SerializeField]
    private List<GameObject> lines;
    private enum ColorName { Red, Green, Blue, Yellow };
    private static readonly Dictionary<int, List<(List<ColorName>, int)>> answerSet = new Dictionary<int, List<(List<ColorName>, int)>>{
        {3, new List<(List<ColorName>, int)>{
            (new List<ColorName>{ColorName.Red, ColorName.Green, ColorName.Blue}, 2),
            (new List<ColorName>{ColorName.Green, ColorName.Blue, ColorName.Yellow}, 2),
            (new List<ColorName>{ColorName.Red, ColorName.Green, ColorName.Red}, 1),
            (new List<ColorName>{ColorName.Blue, ColorName.Yellow, ColorName.Blue}, 1),
            (new List<ColorName>{ColorName.Green, ColorName.Green, ColorName.Green}, 3)}},
        {4, new List<(List<ColorName>, int)>{
            (new List<ColorName>{ColorName.Green, ColorName.Red, ColorName.Blue, ColorName.Yellow}, 1),
            (new List<ColorName>{ColorName.Red, ColorName.Green, ColorName.Green, ColorName.Green}, 1),
            (new List<ColorName>{ColorName.Green, ColorName.Yellow, ColorName.Yellow, ColorName.Yellow}, 1),
            (new List<ColorName>{ColorName.Red, ColorName.Blue, ColorName.Green, ColorName.Blue}, 2),
            (new List<ColorName>{ColorName.Yellow, ColorName.Red, ColorName.Red, ColorName.Blue}, 2)}},
        {5, new List<(List<ColorName>, int)>{
            (new List<ColorName>{ColorName.Green, ColorName.Red, ColorName.Blue, ColorName.Red, ColorName.Green}, 3),
            (new List<ColorName>{ColorName.Yellow, ColorName.Red, ColorName.Yellow, ColorName.Blue, ColorName.Red}, 3),
            (new List<ColorName>{ColorName.Blue, ColorName.Red, ColorName.Blue, ColorName.Red, ColorName.Blue}, 4),
            (new List<ColorName>{ColorName.Red, ColorName.Green, ColorName.Blue, ColorName.Yellow, ColorName.Green}, 5),
            (new List<ColorName>{ColorName.Blue, ColorName.Green, ColorName.Yellow, ColorName.Red, ColorName.Blue}, 5)}},
        {6, new List<(List<ColorName>, int)>{
            (new List<ColorName>{ColorName.Yellow, ColorName.Yellow, ColorName.Yellow, ColorName.Yellow, ColorName.Yellow, ColorName.Yellow}, 1),
            (new List<ColorName>{ColorName.Blue, ColorName.Red, ColorName.Blue, ColorName.Blue, ColorName.Blue, ColorName.Blue}, 1),
            (new List<ColorName>{ColorName.Green, ColorName.Red, ColorName.Red, ColorName.Red, ColorName.Red, ColorName.Blue}, 4),
            (new List<ColorName>{ColorName.Red, ColorName.Green, ColorName.Red, ColorName.Red, ColorName.Green, ColorName.Yellow}, 3),
            (new List<ColorName>{ColorName.Yellow, ColorName.Green, ColorName.Yellow, ColorName.Blue, ColorName.Red, ColorName.Yellow}, 3),
            (new List<ColorName>{ColorName.Blue, ColorName.Yellow, ColorName.Green, ColorName.Green, ColorName.Red, ColorName.Blue}, 6),
            (new List<ColorName>{ColorName.Green, ColorName.Green, ColorName.Red, ColorName.Red, ColorName.Yellow, ColorName.Yellow}, 6)}}
    };
    int lineNumber;
    private List<ColorName> displayedLineSet;
    private int answer;

    public override void PuzzleInit()
    {
        lineNumber = Random.Range(3, 7);
        List<(List<ColorName>, int)> answerCandidate = answerSet[lineNumber];
        int randomIndex = Random.Range(0, answerCandidate.Count);
        displayedLineSet = answerCandidate[randomIndex].Item1;
        answer = answerCandidate[randomIndex].Item2;
        print("Line : " + answer);

        int i = 0;
        for(; i < lineNumber; i++)
        {
            MeshRenderer[] lineMeshes = lines[i].transform.GetChild(0).GetComponentsInChildren<MeshRenderer>();
            foreach(var mesh in lineMeshes)
            {
                if(mesh.transform.childCount != 0) continue;
                mesh.material = materialList[((int)displayedLineSet[i])];
            }
        }

        for(; i < 6; i++)
        {
            lines[i].SetActive(false);
        }

        CalculateAllottedTime();
    }

    protected override void CalculateAllottedTime()
    {
        allottedTime = 10f * lineNumber;
    }

    public override void CheckAnswer(string text)
    {
        if(checkUnavailable) return;
        
        if(int.Parse(text) == answer)
        {
            // clear
            print("Clear");
            
            solvedPuzzleCount++;

            LEDProgressor.instance.PuzzleSolved();
            EffectSoundManager.instance.playBeepAudioClip();
        }
        else
        {
            //fail
            print("Fail");

            solvedPuzzleCount++;
            EffectSoundManager.instance.playWarningAudioClip();
            LEDProgressor.instance.PuzzleFailed();
        }
        checkUnavailable = true;
    }
}
