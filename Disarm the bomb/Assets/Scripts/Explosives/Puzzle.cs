using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    protected float allottedTime;

    protected abstract void CalculateAllottedTime();

    public float GetAllottedTime()
    {
        return allottedTime;
    }

    public abstract void PuzzleInit();
}
