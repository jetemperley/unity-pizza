using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    
    FixedJoint grab;
    Camera cam;
    Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        v = new Vector3(0.5f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            
            Ray ray = cam.ViewportPointToRay(v);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5)){
                Debug.Log("hit");
                grab = gameObject.AddComponent<FixedJoint>();
                grab.connectedBody = hit.rigidbody;
            }
        } else if (Input.GetButtonUp("Fire1") && grab != null) {
           Destroy(grab);
        }
    }
}
