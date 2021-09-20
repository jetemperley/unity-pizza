using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public Drive drive;

    Quaternion restRot;

    // Start is called before the first frame update
    void Start()
    {
        restRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = restRot * Quaternion.Euler(0, drive.steering, 0);
    }
}
