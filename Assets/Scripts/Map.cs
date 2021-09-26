using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Image UIbox;
    public GenerateHood hood;
    int[,] arr;
    float boxSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        arr = hood.getInts();
        boxSize = 1/(float)arr.GetUpperBound(0);
        for(int x = 0; x < arr.GetUpperBound(0)+1; x++) {
            for (int y = 0; y < arr.GetUpperBound(1)+1; y++) {
                Image g = Instantiate(UIbox);
                if (arr[x, y] < 4)
                    g.color = Color.black;
                else 
                    g.color = Color.white;
                g.transform.position = transform.position;
                RectTransform t = (RectTransform)g.transform;
                g.transform.parent = transform;
                t.anchoredPosition = (new Vector2(x*boxSize, y*boxSize));
                t.sizeDelta = new Vector2(boxSize, boxSize);
                
            }
        }
        // Debug.Log(((RectTransform)transform).sizeDelta);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
