using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour
{

    public Text moneyText;
    public FadeOut moneyIn;

    int money = 0;
    static Scorekeeper score;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = $"${money}";
        score = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int dollas){
        money += dollas;
        moneyText.text = $"${money}";
        FadeOut f= Instantiate(moneyIn);
        f.transform.SetParent(transform);
        RectTransform r = (RectTransform)f.transform;
        r.anchoredPosition = Vector3.zero;
        f.target = moneyText.transform;
        f.gameObject.GetComponent<Text>().text = $"+${dollas}";
    }

    public static Scorekeeper GetScorekeeper(){
        return score;
    }
}
