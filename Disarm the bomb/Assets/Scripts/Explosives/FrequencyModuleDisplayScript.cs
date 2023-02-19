using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrequencyModuleDisplayScript : Puzzle
{
    [SerializeField]
    private Material resisterBaseMaterial;
    [SerializeField]
    private Material redMaterial;
    [SerializeField]
    private Material yellowMaterial;
    [SerializeField]
    private Material greenMaterial;
    [SerializeField]
    private Material blueMaterial;
    [SerializeField]
    private Material silverMaterial;

    private List<float> FrequencyList = new List<float> { 88.9f, 90.1f, 91.3f, 91.5f, 91.9f, 94.5f, 95.3f, 97.5f, 98.3f, 98.7f, 98.9f, 99.1f, 99.7f, 100.5f, 102.3f };
    private List<string> leftResisterList = new List<string> { "GYBS", "YGBS", "RYGS", "BYRS", "GYRS", "BRYG", "YRGS", "RGYS", "BSYR", "RBYG", "YBRS", "GYSR", "RYBG", "BGYS", "SYRG" };
    private List<string> RightResisterList = new List<string> { "YRBS", "RSGY", "SBRY", "BYGS", "GRYB", "YRSG", "RGSY", "BGYR", "YSRG", "RSGB", "BSGY", "YGBR", "GSRB", "RSBY", "SYBR" };
    private List<int> correctIndex = new List<int> {3,4,1,2};
    private TMP_Text tmpText;
    private int currentIndex;
    private int answerIndex;
    protected override void CalculateAllottedTime()
    {
        allottedTime = 60f;
    }

    public override void PuzzleInit()
    {
        MeshRenderer leftResister = this.transform.GetChild(5).GetComponent<MeshRenderer>();
        MeshRenderer rightResister = this.transform.GetChild(6).GetComponent<MeshRenderer>();
        tmpText = GameObject.Find("timer display (1)/Rectangle0/Canvas/Text (TMP)").GetComponent<TMP_Text>();
        answerIndex = Random.Range(0, 15);

        Material[] materials = new Material[6];
        materials[0] = resisterBaseMaterial;
        materials[5] = silverMaterial;
        for (int i = 0; i < 4; i++)
        {
            if (leftResisterList[answerIndex][i] == 'R')
            {
                materials[correctIndex[i]] = redMaterial;
            }
            else if (leftResisterList[answerIndex][i] == 'Y')
            {
                materials[correctIndex[i]] = yellowMaterial;
            }
            else if (leftResisterList[answerIndex][i] == 'G')
            { 
                materials[correctIndex[i]] = greenMaterial;
            }
            else if (leftResisterList[answerIndex][i] == 'B')
            {
                materials[correctIndex[i]] = blueMaterial;
            }
            else if (leftResisterList[answerIndex][i] == 'S')
            {
                materials[correctIndex[i]] = silverMaterial;
            }
        }
       
        leftResister.materials = materials;
   
        for (int i = 0; i < 4; i++)
        {
            if (RightResisterList[answerIndex][i] == 'R')
            {
                materials[correctIndex[i]] = redMaterial;
            }
            else if (RightResisterList[answerIndex][i] == 'Y')
            {
                materials[correctIndex[i]] = yellowMaterial;
            }
            else if (RightResisterList[answerIndex][i] == 'G')
            {
                materials[correctIndex[i]] = greenMaterial;
            }
            else if (RightResisterList[answerIndex][i] == 'B')
            {
                materials[correctIndex[i]] = blueMaterial;
            }
            else if (RightResisterList[answerIndex][i] == 'S')
            {
                materials[correctIndex[i]] = silverMaterial;
            }
        }
        
        rightResister.materials = materials;

        currentIndex = 0;
        tmpText.text = FrequencyList[currentIndex].ToString();

        CalculateAllottedTime();
    }

    public void changeText(int change)
    {
        if (currentIndex + change == -1 || currentIndex + change == 15)
        {
            return;
        }
        currentIndex += change;
        tmpText.text = FrequencyList[currentIndex].ToString();
    }
    public override void CheckAnswer(string text)
    {
        if (currentIndex == answerIndex)
        {
            print("Clear");
            checkUnavailable = true;

            solvedPuzzleCount++;
            
            LEDProgressor.instance.PuzzleSolved();
            EffectSoundManager.instance.playBeepAudioClip();
        }
        else
        {
            //fail
            print("Fail");
            checkUnavailable = true;
            
            LEDProgressor.instance.PuzzleFailed();

            EffectSoundManager.instance.playWarningAudioClip();
        }
    }
}
