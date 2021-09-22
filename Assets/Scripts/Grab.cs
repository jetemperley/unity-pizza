using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    
    Rigidbody grab;
    GameObject target;
    Vector3 grabPos;
    public Rigidbody parent;

    // Start is called before the first frame update
    void Start()
    {
        target = new GameObject();
        target.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position, transform.forward*5, Color.green);
        if (Input.GetButtonDown("Fire1")){
            
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5) && hit.rigidbody != null){
                
                
                target.transform.position = hit.point;
                grab = hit.rigidbody;
                grab.useGravity = false;
                grabPos = grab.position - hit.point;
                
            }
        } else if (Input.GetButton("Fire1") && grab != null) {

            grab.velocity = parent.velocity + (target.transform.position - grab.position + grabPos)*10;

        } else if (Input.GetButtonUp("Fire1") && grab != null) {
            grab.useGravity = true;
        }

        // if (grab != null)
        //     Debug.Log($"{grab.currentForce}");
    }
}
