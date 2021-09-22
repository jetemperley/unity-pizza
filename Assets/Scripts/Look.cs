using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    float x, y;

    public float sensitivity = 5;

    void Start()
    {
        // xlow = 360-xhigh;
        // ylow = 360-yhigh;
        Cursor.lockState = CursorLockMode.Locked;
        x = transform.localRotation.eulerAngles.y;
        y = transform.localRotation.eulerAngles.x;
    }

    void Update()
    {
        
        x += Input.GetAxis(Axis.MOUSE_X) * sensitivity;
        y += Input.GetAxis(Axis.MOUSE_Y) * sensitivity;

        if (x < -120)
            x = -120;
        else if (x > 120) x = 120;

        if (y < -90)
            y = -90;
        else if (y > 90) y = 90;

        Quaternion angles =
            Quaternion.Euler(0, x, 0) * Quaternion.Euler(-y, 0, 0);
        transform.localRotation = angles;
        
        // rb.MoveRotation(angles);
        
    }

    void FixedUpdate(){
    }


    // void Update2(){
    //     x = Input.GetAxis(Axis.MOUSE_X) * sensitivity;
    //     y = Input.GetAxis(Axis.MOUSE_Y) * sensitivity;
    //     Vector3 rot = rb.rotation.eulerAngles;
    //     Debug.Log($"{rot.x} {rot.y} {rot.z}");

    //     if (rot.y + x < xlow && rot.y + x > 180)
    //         x = -(rot.y + x - xlow);
    //     else if (rot.y + x > xhigh && rot.y + x <= 180) 
    //         x = (rot.y + x) - xhigh;

    //     if (rot.x + y < 360 - 90 && rot.x + y > 180)
    //         x = rot.x + y + 90;
    //     else if (rot.x + y > 90 && rot.x + y <= 180) 
    //         x = rot.x + y - 90;

    //     Quaternion angles = 
    //         Quaternion.Euler(0, rot.y + x, 0) 
    //             * Quaternion.Euler(rot.x - y, 0, 0);
    //     rb.MoveRotation(angles);
    // }
}
