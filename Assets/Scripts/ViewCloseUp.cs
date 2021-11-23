using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCloseUp : MonoBehaviour, Usable
{
    bool currentlyUsing = false;
    Transform oldParent;
    Vector3 oldPosition;
    Quaternion oldRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void use(GameObject user){
        if (currentlyUsing){
            // drop
            transform.SetParent(oldParent);
            transform.localPosition = oldPosition;
            transform.localRotation = oldRotation;

            oldParent = null;
            oldPosition = Vector3.zero;
            currentlyUsing = false;

        } else {
            // view
            oldParent = transform.parent;
            oldPosition = transform.localPosition;
            oldRotation = transform.localRotation;

            transform.SetParent(user.transform);
            transform.localPosition = (Vector3.forward/2) + (Vector3.up/4);
            transform.localRotation = Quaternion.identity;
            currentlyUsing = true;
        }
    }
}
