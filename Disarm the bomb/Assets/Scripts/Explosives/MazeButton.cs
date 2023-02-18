using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeButton : MonoBehaviour
{
    [SerializeField]
    private string key;

    private void OnMouseDown()
    {
        if(transform.parent.TryGetComponent<MazePuzzle>(out MazePuzzle puzzle))
        {
            puzzle.CheckAnswer(key);
        }
        else
        {
            Debug.LogError("Parent has no MazePuzzle Component!");
        }
    }
}
