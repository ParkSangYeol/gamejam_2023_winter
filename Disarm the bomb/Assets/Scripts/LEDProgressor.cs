using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDProgressor : MonoBehaviour
{
    public static LEDProgressor instance;
    [SerializeField]
    private List<GameObject> LEDs;
    [SerializeField]
    private Material greenLEDMaterial;
    [SerializeField]
    private Material redLEDMaterial;
    
    private void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void PuzzleSolved()
    {
        LEDs[0].transform.GetChild(2).GetComponent<MeshRenderer>().material = greenLEDMaterial;
        LEDs.RemoveAt(0);

        if(LEDs.Count == 0)
        {
            // Game Win
            print("Game Win!!!!");
        }
    }

    public void PuzzleFailed()
    {
        LEDs[LEDs.Count - 1].transform.GetChild(2).GetComponent<MeshRenderer>().material = redLEDMaterial;
        if(LEDs[LEDs.Count - 1].name == "LED7")
        {
            // bomb
            GameObject.Find("TNT/circuitboard/timer display").GetComponent<Timer>().ExplodeBomb();
        }
        LEDs.RemoveAt(LEDs.Count - 1);
    }

    ~LEDProgressor()
    {
        instance = null;
    }
}
