using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButton : PuzzleButton
{
    [SerializeField]
    Timer timer;
    
    protected new void PlayEffectSound()
    {
        EffectSoundManager.instance.playRedButtonAudioClip();
    }

    protected void ButtonDown()
    {
        transform.localPosition -= new Vector3(0f, 0.04f, 0f);
    }

    private void OnMouseDown() 
    {
        if(isPuzzleUnavailable<SingleButtonPuzzle>()) return;

        ButtonDown();
        PlayEffectSound();
        RequestCheckAnswer<SingleButtonPuzzle>("");
    }
}
