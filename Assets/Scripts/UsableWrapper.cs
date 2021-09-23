using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableWrapper : MonoBehaviour
{
    public MonoBehaviour wrapped;

    public Usable target = null;

    // Start is called before the first frame update
    void Start()
    {
        if (wrapped is Usable) target = (Usable) wrapped;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
