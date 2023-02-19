using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            // GameObject.Find("TNT/circuitboard/timer display").GetComponent<Timer>().stopTimer();
            GameObject.Find("EndingCanvas").GetComponent<EndingPanelSwitcher>().TurnClearPanelOn();
        }
    }

    public void PuzzleFailed()
    {
        LEDs[LEDs.Count - 1].transform.GetChild(2).GetComponent<MeshRenderer>().material = redLEDMaterial;
        GameObject.Find("TNT/circuitboard/timer display").GetComponent<Timer>().makeTimerFast();
        if(LEDs[LEDs.Count - 1].name == "LED7")
        {
            // bomb
            GameObject.Find("TNT/circuitboard/timer display").GetComponent<Timer>().ExplodeBomb();
            GameObject.Find("EndingCanvas").GetComponent<EndingPanelSwitcher>().TurnFailPanelOn();
        }
        LEDs.RemoveAt(LEDs.Count - 1);
    }

    private void OnDestroy() {
        // Debug.LogError("LED PROGRESSOR DESTROYED");
        instance = null;
    }
}
