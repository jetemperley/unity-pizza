using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    float x, y;
    public Transform yRot, xRot;
    public float sensitivity = 5;

    void Start()
    {
        // xlow = 360-xhigh;
        // ylow = 360-yhigh;
        Cursor.lockState = CursorLockMode.Locked;
        x = yRot.localRotation.eulerAngles.y;
        y = xRot.localRotation.eulerAngles.x;
    }

    void Update()
    {
        
        x += Input.GetAxis(Axis.MOUSE_X) * sensitivity;
        y += Input.GetAxis(Axis.MOUSE_Y) * sensitivity;


        if (y < -90)
            y = -90;
        else if (y > 90) y = 90;

        yRot.rotation = Quaternion.Euler(0, x, 0); 
        // xRot.rotation = yRot.rotation*Quaternion.Euler(-y, 0, 0);
        xRot.localRotation = Quaternion.Euler(-y, 0, 0);
        
    }

}
