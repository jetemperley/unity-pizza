using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

    float x, y;
    public float sensitivity = 5;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        x = transform.localRotation.eulerAngles.y;
        y = transform.localRotation.eulerAngles.x;

    }

    void Update () {

            x += Input.GetAxis (Axis.MOUSE_X) * sensitivity;
            y += Input.GetAxis (Axis.MOUSE_Y) * sensitivity;



            Quaternion angles = Quaternion.Euler(0, x, 0) * Quaternion.Euler(-y, 0, 0);
            transform.localRotation = angles;

            
            // if (angles.x-y > 270 || angles.x-y < 90){
            //     camera.Rotate(-y, 0, 0, Space.Self);    
            // }


    }

}