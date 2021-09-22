using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    
    ConfigurableJoint grab;
    public Rigidbody connectTo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")){
            
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5)){
                
                grab = hit.rigidbody.gameObject.AddComponent<ConfigurableJoint>();
                grab.xMotion = ConfigurableJointMotion.Locked;
                grab.yMotion = ConfigurableJointMotion.Locked;
                grab.zMotion = ConfigurableJointMotion.Locked;
                grab.connectedBody = connectTo;
                grab.breakForce = 1000;
            }
        } else if (Input.GetButtonUp("Fire1") && grab != null) {
           Destroy(grab);
        }

        if (grab != null)
            Debug.Log($"{grab.currentForce}");
    }
}
