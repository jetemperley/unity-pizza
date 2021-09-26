using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Transform foot; 
    float jumpSpeed = 5;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Space") 
            && Physics.Raycast(new Ray(foot.position, Vector3.down), out hit, 0.125f)){
                rb.AddForce(transform.up*jumpSpeed, ForceMode.VelocityChange);
        }
    }
}
