using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class PlayerLeftMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
 
            pointerData.position = Input.mousePosition;
 
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult r in results) {
                // Debug.Log(r.gameObject.name);
                if (r.gameObject.tag == "Clickable") {
                    
                    Map m = r.gameObject.GetComponent<Map>();
                    m.click(r.worldPosition);
                    break;
                }
            }

            // Ray ray = new Ray(transform.position, transform.forward);
            // RaycastHit hit;
            // if (Physics.Raycast(ray, out hit, 5))
            // {
            //     Debug.Log($"hit {hit.collider.gameObject.name}");
            //     if (hit.collider.gameObject.tag == "Clickable"){
            //         hit.collider.gameObject.GetComponent<MapCell>().click();
            //     }
            // }
        }
    }
}
