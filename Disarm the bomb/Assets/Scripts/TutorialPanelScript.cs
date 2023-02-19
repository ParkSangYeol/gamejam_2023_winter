using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject image1;
    [SerializeField]
    private GameObject image2;
    // Start is called before the first frame update
    void Start()
    {
        image1.SetActive(true);
        image2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(image1.activeSelf)
            {
                image1.SetActive(false);
                image2.SetActive(true);
            }
            else if (image2.activeSelf)
            {
                image1.SetActive(true);
                image2.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
}
