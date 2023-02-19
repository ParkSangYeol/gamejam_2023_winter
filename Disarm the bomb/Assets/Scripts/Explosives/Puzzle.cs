using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    protected float allottedTime;
    public bool checkUnavailable = false;

    protected abstract void CalculateAllottedTime();

    public float GetAllottedTime()
    {
        return allottedTime;
    }

    public abstract void PuzzleInit();

    public abstract void CheckAnswer(string text);
}
