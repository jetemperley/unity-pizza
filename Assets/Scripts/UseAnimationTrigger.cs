using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UseAnimationTrigger : MonoBehaviour, Usable
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void use(GameObject user)
    {
        anim.SetTrigger("Used");
    }
}
