using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float cameraSize;
    private float px;
    private float pz;
    private float wheelSpeed = 2f;
    public float SmoothTime = 0.1f;

    private Vector3 velocity = Vector3.zero;
    private Transform m_transform;
    private Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        cameraSize = 6;
        m_transform = this.GetComponent<Transform>();
        m_transform.position = new Vector3(5,11,0);
        px = 5;
        pz = 0;
        m_camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraSize -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed;
        if (cameraSize < 1)
        {
            cameraSize = 1;
        }
        else if (cameraSize > 9) 
        {
            cameraSize = 9;
        }
        m_camera.orthographicSize = cameraSize;

        if (Input.GetMouseButton(1))
        {
            px += Input.GetAxis("Mouse X") * SmoothTime;
            pz += Input.GetAxis("Mouse Y") * SmoothTime;
            if (px > 15)
            {
                px = 15;
            }
            else if (px < -5)
            {
                px = -5;
            }
            if (pz > 5)
            {
                pz = 5;
            }
            else if (pz < -5)
            {
                pz = -5;
            }
            m_transform.position = Vector3.Lerp(m_transform.position, new Vector3(px,11,pz), SmoothTime);
        }
    }
}
