using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SymbolButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    private void OnMouseDown() 
    {
        if(transform.parent.TryGetComponent<SymbolButtonPuzzle>(out SymbolButtonPuzzle puzzle))
        {
            puzzle.CheckAnswer(text.text);
        }
        else
        {
            Debug.LogError("Parent has no SymbolButtonPuzzle Component!");
        }
    }
}
