using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiringButton : PuzzleButton
{
    [SerializeField]
    private string key;

    protected new T GetPuzzle<T>() where T : Puzzle
    {
        if(transform.parent.parent.parent.TryGetComponent<T>(out T puzzle))
        {
            return puzzle;
        }
        else
        {
            Debug.LogError("Parent has no Puzzle Component!");
            return null;
        }
    }

    public new bool isPuzzleUnavailable<T>() where T : Puzzle
    {
        return GetPuzzle<T>().checkUnavailable;
    }

    protected new void RequestCheckAnswer<T>(string value) where T : Puzzle
    {
        GetPuzzle<T>().CheckAnswer(value);
    }

    private void OnMouseDown()
    {
        if(isPuzzleUnavailable<WiringPuzzle>()) return;

        PlayEffectSound();
        RequestCheckAnswer<WiringPuzzle>(key);

        Destroy(gameObject);
    }
}
