using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.position, cam.forward*2);
        if (Input.GetButtonDown("Use"))
        {
            Debug.Log("trying to use");
            UsableWrapper obj;
            Ray ray = new Ray(cam.position, cam.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5))
            {
                Debug.Log($"hit {hit.collider.gameObject.name}");
                if ((obj =hit.collider
                            .gameObject
                            .GetComponent<UsableWrapper>()) != null)
                {
                    Debug.Log($"using");
                    obj.target.use (gameObject);
                }
            }
        }
    }
}
