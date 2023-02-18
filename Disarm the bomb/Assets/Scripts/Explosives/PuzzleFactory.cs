using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleFactory : MonoBehaviour
{
    float allottedTime;

    public float GetAllottedTime()
    {
        return allottedTime;
    }

    public abstract void DeployExplosive();
}
