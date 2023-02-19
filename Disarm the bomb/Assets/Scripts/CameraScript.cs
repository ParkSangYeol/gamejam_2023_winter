using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float cameraSize;
    private float px;
    private float pz;
    private float wheelSpeed = 1f;
    private Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        cameraSize = 6;
        this.GetComponent<Transform>().position = new Vector3(5,11,0);
        px = 5;
        pz = 0;
        m_camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraSize -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed;
        if (cameraSize < 2)
        {
            cameraSize = 2;
        }
        else if (cameraSize > 9) 
        {
            cameraSize = 9;
        }
        m_camera.orthographicSize = cameraSize;

        if (Input.GetMouseButton(2))
        {
            px += Input.GetAxis("Mouse X");
            pz -= Input.GetAxis("Mouse Y");
            transform.rotation = Quaternion.Euler(ymove, xmove, 0);
        }
    }
}
