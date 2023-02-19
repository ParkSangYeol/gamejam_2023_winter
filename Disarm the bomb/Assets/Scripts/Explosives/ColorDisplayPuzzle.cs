using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDisplayPuzzle : Puzzle
{
    [SerializeField]
    MeshRenderer displayTarget;
    [SerializeField]
    private List<Material> materialList;
    private enum ColorName { Default, White, Pink, Cyan, Green, Orange, Red, Purple };
    private static readonly Dictionary<int, List<(List<ColorName>, List<int>)>> answerSet = new Dictionary<int, List<(List<ColorName>, List<int>)>>{
        {4, new List<(List<ColorName>, List<int>)>{
            (new List<ColorName>{ColorName.Cyan, ColorName.Pink, ColorName.Green, ColorName.Orange}, new List<int>{1, 2, 3, 4}),
            (new List<ColorName>{ColorName.Orange, ColorName.Cyan, ColorName.Green, ColorName.Purple}, new List<int>{1, 3, 2, 4}),
            (new List<ColorName>{ColorName.Purple, ColorName.Green, ColorName.Orange, ColorName.Cyan}, new List<int>{4, 3, 2, 1}),
            (new List<ColorName>{ColorName.Red, ColorName.Green, ColorName.Cyan, ColorName.Purple}, new List<int>{3, 1, 4, 2}),
            (new List<ColorName>{ColorName.Green, ColorName.Cyan, ColorName.Orange, ColorName.Red}, new List<int>{3, 1, 4, 2})}},
        {5, new List<(List<ColorName>, List<int>)>{
            (new List<ColorName>{ColorName.Pink, ColorName.Red, ColorName.Green, ColorName.Cyan, ColorName.Purple}, new List<int>{2, 3, 1, 4}),
            (new List<ColorName>{ColorName.Red, ColorName.Pink, ColorName.Purple, ColorName.Green, ColorName.Cyan}, new List<int>{4, 2, 1, 3}),
            (new List<ColorName>{ColorName.Orange, ColorName.Green, ColorName.Purple, ColorName.Cyan, ColorName.Pink}, new List<int>{1, 4, 3, 2}),
            (new List<ColorName>{ColorName.Cyan, ColorName.Purple, ColorName.Green, ColorName.Orange, ColorName.Red}, new List<int>{3, 2, 4, 1}),
            (new List<ColorName>{ColorName.Red, ColorName.Orange, ColorName.Cyan, ColorName.Green, ColorName.Purple}, new List<int>{3, 2, 4, 1}),
            (new List<ColorName>{ColorName.Orange, ColorName.Pink, ColorName.Purple, ColorName.Red, ColorName.Green}, new List<int>{3, 2, 4, 1})}},
        {6, new List<(List<ColorName>, List<int>)>{
            (new List<ColorName>{ColorName.Pink, ColorName.Cyan, ColorName.Purple, ColorName.Green, ColorName.Red, ColorName.Orange}, new List<int>{4, 1, 2, 3}),
            (new List<ColorName>{ColorName.Purple, ColorName.Green, ColorName.Pink, ColorName.Cyan, ColorName.Orange, ColorName.Red}, new List<int>{2, 1, 3, 4}),
            (new List<ColorName>{ColorName.Cyan, ColorName.Orange, ColorName.Purple, ColorName.Green, ColorName.Red, ColorName.Pink}, new List<int>{1, 4, 2, 3}),
            (new List<ColorName>{ColorName.Orange, ColorName.Pink, ColorName.Cyan, ColorName.Red, ColorName.Purple, ColorName.Green}, new List<int>{3, 4, 1, 2}),
            (new List<ColorName>{ColorName.Green, ColorName.Purple, ColorName.Orange, ColorName.Pink, ColorName.Cyan, ColorName.Red}, new List<int>{3, 4, 1, 2}),
            (new List<ColorName>{ColorName.Purple, ColorName.Cyan, ColorName.Green, ColorName.Red, ColorName.Orange, ColorName.Pink}, new List<int>{3, 4, 1, 2})}}
    };
    private List<ColorName> displayedColorSet;
    private List<int> answer;
    private float displayInterval = 0.6f;

    public override void PuzzleInit()
    {
        int colorNumber = Random.Range(4, 7);
        List<(List<ColorName>, List<int>)> answerCandidate = answerSet[colorNumber];
        int randomIndex = Random.Range(0, answerCandidate.Count);
        displayedColorSet = answerCandidate[randomIndex].Item1;
        answer = answerCandidate[randomIndex].Item2;
        print("Color Display : " + answer[0] + " " + answer[1] + " " + answer[2] + " "  + answer[3]);
        StartCoroutine(ColorChanger());
    }

    private IEnumerator ColorChanger()
    {
        while(!checkUnavailable)
        {
            // set as default
            PutColor(ColorName.Default);
            yield return new WaitForSeconds(displayInterval);
            if(checkUnavailable) break;

            // blink two times
            for(int i = 0; i < 2; i++)
            {
                PutColor(ColorName.White);
                yield return new WaitForSeconds(displayInterval);
                if(checkUnavailable) break;
                PutColor(ColorName.Default);
                yield return new WaitForSeconds(displayInterval);
                if(checkUnavailable) break;
            }

            // show color set
            foreach(ColorName cn in displayedColorSet)
            {
                PutColor(cn);
                yield return new WaitForSeconds(displayInterval);
                if(checkUnavailable) break;
            }
        }
        PutColor(ColorName.Default);
    }

    private void PutColor(ColorName cn)
    {
        displayTarget.material = materialList[((int)cn)];
    }

    protected override void CalculateAllottedTime()
    {
    }

    public override void CheckAnswer(string text)
    {
        if(checkUnavailable) return;
        
        if(int.Parse(text) == answer[0])
        {
            answer.RemoveAt(0);
            print("Pass");
            if(answer.Count == 0)
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
