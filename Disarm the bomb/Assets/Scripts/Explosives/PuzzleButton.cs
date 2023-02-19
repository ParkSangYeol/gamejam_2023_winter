using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleButton : MonoBehaviour
{
    [SerializeField]
    private Material normalStateMaterials;
    [SerializeField]
    private Material pressedStateMaterials;

    protected T GetPuzzle<T>() where T : Puzzle
    {
        if(transform.parent.TryGetComponent<T>(out T puzzle))
        {
            return puzzle;
        }
        else
        {
            Debug.LogError("Parent has no SymbolButtonPuzzle Component!");
            return null;
        }
    }

    public bool isPuzzleUnavailable<T>() where T : Puzzle
    {
        return GetPuzzle<T>().checkUnavailable;
    }

    protected IEnumerator ButtonDown<T>() where T : Puzzle
    {
        if(gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
        {
            mesh.material = pressedStateMaterials;
        }
        else
        {
            Debug.LogError("No Mesh Renderer Component!");
        }

        yield return new WaitForSeconds(0.5f);

        ButtonUp();
    }

    private void ButtonUp()
    {
        if(gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
        {
            mesh.material = normalStateMaterials;
        }
        else
        {
            Debug.LogError("No Mesh Renderer Component!");
        }
    }

    protected void RequestCheckAnswer<T>(string value) where T : Puzzle
    {
        GetPuzzle<T>().CheckAnswer(value);
    }

    protected void PlayEffectSound()
    {
        EffectSoundManager.instance.playButtonAudioClip();
    }
}