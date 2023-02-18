using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzlePlacer : MonoBehaviour
{
    // puzzle place candidate
    [SerializeField]
    private List<GameObject> chips;
    // puzzles
    [SerializeField]
    private List<GameObject> modules;

    private void Start()
    {
        PlacePuzzles();
    }

    public void PlacePuzzles()
    {
        List<GameObject> listForChip = new List<GameObject>();
        for (int i = 0 ; i < chips.Count ; i++)
        {
            listForChip.Add(chips[i]);
        }

        foreach(var randomModule in modules)
        {
            int randomIndex = Random.Range(0, listForChip.Count);
            GameObject.Instantiate(randomModule, listForChip[randomIndex].transform);
            listForChip.RemoveAt(randomIndex);

            // 문제 ! : Module 의 수가 Chip보다 많으면 오류 생김.
            if (listForChip.Count == 0)
                break;
        }
    }
}
