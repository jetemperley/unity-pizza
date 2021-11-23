using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DeliveryLocation : MonoBehaviour
{

    Rigidbody delivery;
    Map fromMap;
    public float deliverTime = 2;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider c){
        if (c.attachedRigidbody == delivery){
            time += Time.deltaTime;
            if (time > deliverTime)
                completeDelivery(c.attachedRigidbody);
        }
    }

    void OnTriggerExit(Collider c){
        if (c.attachedRigidbody == delivery)
            time = 0;
    }

    void completeDelivery(Rigidbody r){
        fromMap.completeDelivery(r);
        Destroy(r.gameObject);
        delivery = null;
        fromMap = null;
        Scorekeeper.GetScorekeeper().AddMoney(10);
        gameObject.SetActive(false);
    }

    public void setDelivery(Map m, GameObject g){
        fromMap = m;
        delivery = g.GetComponent<Rigidbody>();
        gameObject.SetActive(true);
        time = 0;
    }
}
