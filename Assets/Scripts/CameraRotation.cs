using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    float mouseX, mouseY;

    void Start()
    {
        
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse Y");
        mouseY = Input.GetAxis("Mouse X");
        transform.Rotate(-mouseX, 0, 0);
        transform.Rotate(0, mouseY, 0, Space.World); ;
    }
}
