using System.Collections;
using System.Collections.Generic;
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
    private List<string> leftResisterList = new List<string> { "rrybs", "rybsg", "brygs", "rybgs", "srgby", "bgyrs", "ybsrg", "sbryg", "ysrgb", "rsybg", "brysg", "rygsb", "gybrs", "ybsgr", "rbysg" };
    private List<string> RightResisterList = new List<string> { "gbyrs", "sbygr", "gysrb", "bygrs", "gyrsb", "rsgby", "grysb", "rbygs", "bgysr", "ygrbs", "gsryb", "sbyrg", "rgbsy", "bgsyr", "ysbrg" };
    private List<int> correctIndex = new List<int> {4,3,5,1,2};
    private int currentIndex;
    private int answerIndex;
    protected override void CalculateAllottedTime()
    {

    }

    public override void PuzzleInit()
    {
        MeshRenderer leftResister = this.transform.GetChild(5).GetComponent<MeshRenderer>();
        MeshRenderer rightResister = this.transform.GetChild(6).GetComponent<MeshRenderer>();
        answerIndex = Random.Range(0, 15);
        Material[] materials = new Material[5];
        materials[0] = resisterBaseMaterial;
        for (int i = 0; i < 5; i++)
        {

        }
        leftResister.materials[1] = 

    }

    public override void CheckAnswer(string text)
    {

    }
}
