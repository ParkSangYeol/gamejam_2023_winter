using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRandomizer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> batteries;
    public static int activeBatteryNumber;

    private void Start()
    {
        activeBatteryNumber = Random.Range(0, 5);
        for(int i = 4; i > activeBatteryNumber; i--)
        {
            batteries[i - 1].SetActive(false);
        }
    }
}
