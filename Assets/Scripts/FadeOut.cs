using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Transform target;
    public float initialWait = 1;
    public float timeToFade = 1;
    float fadeTime;
    Text t;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        // dist = (target.position - transform.position).magnitude;
        fadeTime = timeToFade;
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (initialWait > 0) {
            initialWait -= Time.deltaTime;
        } else {
            fadeTime -= Time.deltaTime;

            if (fadeTime < 0){
                Destroy(gameObject);
                return;
            }

            transform.position = transform.position + (target.position - transform.position)*Time.deltaTime;
            Color c= t.color;
            c.a = fadeTime/timeToFade;
            t.color = c;

        }
    }
}
