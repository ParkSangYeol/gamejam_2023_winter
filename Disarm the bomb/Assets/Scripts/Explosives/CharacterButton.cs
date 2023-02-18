using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public void PutText(string text)
    {
        this.text.text = text;
    }

    private void OnMouseDown()
    {
        if(transform.parent.TryGetComponent<CharacterButtonPuzzle>(out CharacterButtonPuzzle puzzle))
        {
            puzzle.CheckAnswer(text.text);
        }
        else
        {
            Debug.LogError("Parent has no SymbolButtonPuzzle Component!");
        }
    }
}
