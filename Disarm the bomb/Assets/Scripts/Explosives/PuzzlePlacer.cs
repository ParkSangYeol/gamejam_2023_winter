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
    private List<GameObject> chipModules;
    [SerializeField]
    private List<GameObject> lineModules;
    private List<Puzzle> puzzles = new List<Puzzle>();

    private void Start()
    {
        PlacePuzzles();
    }

    public void PlacePuzzles()
    {
        int randomIndex;
        // Chip Placement
        List<GameObject> listForChip = new List<GameObject>();
        for (int i = 0 ; i < chips.Count ; i++)
        {
            listForChip.Add(chips[i]);
        }

        foreach(var randomModule in chipModules)
        {
            randomIndex = Random.Range(0, listForChip.Count);
            GameObject newModule = GameObject.Instantiate(randomModule, listForChip[randomIndex].transform);
            listForChip.RemoveAt(randomIndex);

            ExtractPuzzleComponent(newModule);

            // 문제 ! : Module 의 수가 Chip보다 많으면 오류 생김.
            if (listForChip.Count == 0)
                break;
        }

        // Line Placement
        randomIndex = Random.Range(0, lineModules.Count);
        lineModules[randomIndex].SetActive(true);
        
        ExtractPuzzleComponent(lineModules[randomIndex]);

        // Puzzle Init
        foreach(var puzzle in puzzles)
        {
            puzzle.PuzzleInit();
        }
    }

    private void ExtractPuzzleComponent(GameObject obj)
    {
        if(obj.TryGetComponent<Puzzle>(out Puzzle puzzle))
        {
            puzzles.Add(puzzle);
        }
        else
        {
            Debug.LogError("No Puzzle Component");
        }
    }
}
