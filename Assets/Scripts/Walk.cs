using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Walk : MonoBehaviour
{

    float x, y;
    Rigidbody rb;


    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 y = transform.forward*Input.GetAxis(Axis.VERTICAL)*maxSpeed*Time.deltaTime;
        Vector3 x = transform.right*Input.GetAxis(Axis.HORIZONTAL)*maxSpeed*Time.deltaTime;

        // Vector3 v = new Vector3(x, 0, y);
        Vector3 v = x + y;
        if (v.magnitude > maxSpeed*Time.deltaTime)
            v = v.normalized*maxSpeed*Time.deltaTime;
        
        // rb.MovePosition(transform.position + v);
        rb.MovePosition(rb.position + v);
    }
}
