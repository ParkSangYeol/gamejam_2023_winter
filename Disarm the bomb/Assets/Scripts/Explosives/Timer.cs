using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time;
    private float fastFactor;
    private string timeText;
    private TMP_Text m_text;
    private GameObject effectObject;
    private bool isCountDown = false;
    private bool isExplode = false;
    private void Start()
    {
        time = GameObject.Find("PuzzlePlacer").GetComponent<PuzzlePlacer>().getTimerTime();
        m_text = GameObject.Find("Rectangle0/Canvas/Text (TMP)").GetComponent<TMP_Text>();
        effectObject = GameObject.Find("ExplosionImpact");
        fastFactor = 1f;
    }
    private void Update()
    {
        if (!isExplode)
        {
            time -= Time.deltaTime * fastFactor;
            string min = ((int)time / 60).ToString();
            string sec = ((int)time % 60).ToString();
            if (sec.Length == 1)
            {
                sec = '0' + sec;
            }
            timeText = min + ":" + sec;
            m_text.text = timeText;
            if (!isCountDown && timeText == "0:01")
            {
                isCountDown = true;
                EffectSoundManager.instance.playBombCountdownAudioClip();
                Debug.Log("Bomb Explosion");
            }
            else if (!isExplode && timeText == "0:00")
            {
                ExplodeBomb();
            }
        }
    }

    public string getTime()
    {
        return timeText;
    }

    public void ExplodeBomb()
    {
        isExplode = true;
        EffectSoundManager.instance.playBombExplosionAudioClip();
        ParticleSystem[] particles = effectObject.GetComponentsInChildren<ParticleSystem>();
        foreach (var particle in particles)
        {
            particle.Play();
        }
        GameObject.Find("Directional Light").GetComponent<Light>().enabled = false;
        SoundManagerScript.instance.stopMusic();
    }
    public void makeTimerFast()
    {
        fastFactor = 1.5f;
    }
}
