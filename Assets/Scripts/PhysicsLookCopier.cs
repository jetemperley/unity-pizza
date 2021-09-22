using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsLookCopier : MonoBehaviour
{
    public Transform looker;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        transform.position = looker.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.rotation = looker.rotation;
    }
}
