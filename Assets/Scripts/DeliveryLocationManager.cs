using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryLocationManager : MonoBehaviour
{
    public Text address; 
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

    public void SetAddressLabel(string s){
        address.text = s;
    }
}
