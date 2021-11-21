using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryLocationManager : MonoBehaviour
{

    public DeliveryLocation[] locations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDelivery(Map m, GameObject g){
        locations[0].setDelivery(m, g);
    }
}
