using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIntoCar : MonoBehaviour, Usable
{
    public GameObject carCamera;
    public Transform exitPos;

    public Drive drive;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void use(GameObject user)
    {
        if (player != null)
        {
            player.transform.position = exitPos.position;
            carCamera.SetActive(false);
            drive.enabled = false;
            player.SetActive(true);
            player = null;

        
        }
        else
        {
            carCamera.SetActive(true);
            drive.enabled = true;
            user.SetActive(false);
            player = user;

        }
    }
}
