using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DeliveryLocation : MonoBehaviour
{

    Collider loc;
    GameObject delivery;

    // Start is called before the first frame update
    void Start()
    {
        loc = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c){
        
    }

    void completeDelivery(GameObject g){
        Destroy(g);
    }
}
