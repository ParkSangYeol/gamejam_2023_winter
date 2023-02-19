using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButton : PuzzleButton
{
    protected new void PlayEffectSound()
    {
        EffectSoundManager.instance.playRedButtonAudioClip();
    }

    private void OnMouseDown() 
    {
        if(isPuzzleUnavailable<SingleButtonPuzzle>()) return;

        StartCoroutine(ButtonDown<SingleButtonPuzzle>());
        PlayEffectSound();
        RequestCheckAnswer<SingleButtonPuzzle>("");
    }
}
