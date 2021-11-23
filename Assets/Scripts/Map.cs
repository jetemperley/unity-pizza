using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Image UIbox;
    public Manager hood;
    public int deliveryChance = 0;
    public GameObject deliveryObject;
    public Transform deliverySpawn;
    public Sprite newDeliveryIcon;
    public Sprite pickedDeliveryIcon;
    public Sprite houseIcon;

    Manager.TileStatus[,] tiles;
    int[,] arr;
    float boxSize = 0;
    Image[,] map;
    Image[,] overlay;
    Vector3[] corners;

    Addresses addresses;


    // Start is called before the first frame update
    void Start()
    {
        // get the deets for the map edges
        corners = new Vector3[4];
        ((RectTransform)transform).GetWorldCorners(corners);
        for (int i = 0; i < corners.Length; i++) {
            corners[i] = transform.worldToLocalMatrix*corners[i];
        }

        // make the map
        arr = hood.getInts();
        map = new Image[arr.GetUpperBound(0)+1,arr.GetUpperBound(1)+1];
        overlay = new Image[arr.GetUpperBound(0)+1,arr.GetUpperBound(1)+1];
        boxSize = 1/((float)arr.GetUpperBound(0)+1);

        for(int x = 0; x < arr.GetUpperBound(0)+1; x++) {
            for (int y = 0; y < arr.GetUpperBound(1)+1; y++) {
                Image g = createUISprite(x, y);
                map[x, y] = g;
                
                if (arr[x, y] > 253){
                   g.color = Color.white; 
                }else { 
                    g.color = Color.black;
                    g.sprite = houseIcon;
                }
               
                
            }
        }
        tiles = hood.getTiles();
        addresses = new Addresses(hood.getTiles());
    }

    // Update is called once per frame
    void Update()
    {
        int chance = Random.Range(0, 1000);
        if (chance < Time.deltaTime*1000 && addresses.hasHouses()) {
            // Debug.Log("new delivery! " + Time.deltaTime);
            Veci v = addresses.randomOrder();
            Image img = createUISprite(v.x, v.y);
            img.sprite = newDeliveryIcon;
            img.color = Color.red;
            overlay[v.x, v.y] = img;
            
        }
    }

    public void click(Vector3 pos) {
        
        Veci clicked = canvasPosition(transform.worldToLocalMatrix*pos);
        // Debug.Log($"{clicked.x} {clicked.y}");
        if (addresses.isAnOrder(clicked)) {
            
            overlay[clicked.x, clicked.y].sprite = pickedDeliveryIcon;
            GameObject g = spawnPizza(clicked.x, clicked.y);
            addresses.outForDelivery(clicked, g.GetComponent<Rigidbody>());
            hood.hood[clicked.x, clicked.y].GetComponent<DeliveryLocationManager>().addDelivery(this, g);

        }
        
    }

    Veci canvasPosition(Vector3 v){
        float xleft = corners[0].x;
        float ybot = corners[0].y;

        return new Veci((int)((v.x - xleft)*(arr.GetUpperBound(0)+1)), (int)((v.y - ybot)*(arr.GetUpperBound(1)+1)));
    }

    //adds a rectangular ui element on the grid at x, y (array coords)
    Image createUISprite(int x, int y){
        Image g = Instantiate(UIbox);
        g.transform.SetParent(transform, false);
        RectTransform t = (RectTransform)g.transform;
        t.anchoredPosition = (new Vector2(x * boxSize, y * boxSize));
        t.sizeDelta = new Vector2(boxSize, boxSize);
        return g;
    }

    GameObject spawnPizza(int delx, int dely){
        GameObject g = Instantiate(deliveryObject);
        deliveryObject.transform.position = deliverySpawn.position;
        deliveryObject.transform.rotation = deliverySpawn.rotation;
        deliveryObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*2, ForceMode.Impulse);
        g.GetComponentInChildren<Text>().text = $"{delx} {dely}";
        return g;
        
    }

    public void completeDelivery(Rigidbody r){
        addresses.deliveryComplete(r);
    }
}

class Addresses{
    List<Veci> houses;
    List<Veci> orders;

    List<Veci> delivery;
    List<Rigidbody> deliverObj;

    public Addresses(Manager.TileStatus[,] tiles){
        houses = new List<Veci>();
        orders = new List<Veci>();
        delivery = new List<Veci>();
        deliverObj = new List<Rigidbody>();
        for (int x  = 0; x < tiles.GetUpperBound(0); x++){
            for (int y = 0; y < tiles.GetUpperBound(1); y++){
                if(tiles[x,y] == Manager.TileStatus.House)
                    houses.Add(new Veci(x, y));
            }
        }
    }

    public Veci randomOrder(){
        int rand = Random.Range(0, houses.Count-1);
        Veci v = houses[rand];
        orders.Add(v);
        houses.RemoveAt(rand);
        return v;
    }

    public bool hasHouses(){
        return houses.Count > 0;
    }

    public bool isAnOrder(Veci v){
        return orders.Contains(v);
    }

    public void outForDelivery(Veci v, Rigidbody r){
        int i = orders.IndexOf(v);
        if (i != -1){
            delivery.Add(orders[i]);
            orders.RemoveAt(i);
            deliverObj.Add(r);
        }
    }

    public void deliveryComplete(Rigidbody r){
        int i = deliverObj.IndexOf(r);
        Veci v = delivery[i];
        deliverObj.RemoveAt(i);
        delivery.RemoveAt(i);
        houses.Add(v);
    }
    
}
