using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this does the neighborhood management, spawning, and laying out
public class Manager : MonoBehaviour
{
    public List<GameObject> houses;
    public List<GameObject> roads;
    public GameObject pizzaStore;
    public int size = 60;

    int cellSize = 15;
    
    [HideInInspector]
    public GameObject[,] hood;
    RoadDiv map;
    TileStatus[,] arr;

    static Manager inst;

    public enum TileStatus {
        Road,
        House,
        Delivery,
        Waiting,
        Shop

    }


    void Awake(){
        if (inst == null) {
            inst = this;
        } else {
            Destroy(gameObject);
        }

        map = new RoadDiv(size);
        map.arr[0, 1] = 10;
    }

    void Start(){

        hood = new GameObject[size,size];
        
        for (int x = 0; x < size; x++){
            for (int z = 0; z < size; z++){

                GameObject g;

                if (map.arr[x, z] < 4){
                    int r = Random.Range(0, houses.Count);
                    g = Instantiate(houses[r]);
                    g.transform.rotation = Quaternion.Euler(0, 90*map.arr[x, z], 0);
                    g.transform.position = new Vector3(
                        x*cellSize, g.transform.position.y, z*cellSize
                    );
                    g.GetComponent<DeliveryLocationManager>().SetAddressLabel($"{x} {z}");
                } else if (map.arr[x, z] > 253){
                    g = Instantiate(roads[0]);
                    if (map.arr[x, z] == 254){
                        g.transform.rotation = Quaternion.Euler(0, 90 ,0);
                    }
                    g.transform.position = new Vector3(
                        x*cellSize, g.transform.position.y, z*cellSize
                    );
                    
                } else if (map.arr[x, z] == 11) {
                    g = Instantiate(pizzaStore);
                    
                    g.transform.rotation = Quaternion.Euler(0, 90 ,0);
                    
                    g.transform.position = new Vector3(
                        x*cellSize, g.transform.position.y, z*cellSize
                    );
                } else {
                    g = null;
                }
                hood[x, z] = g;
            }
        }

    }

    void Update(){

    }

    public TileStatus[,] getTiles(){
        TileStatus[,] t = new TileStatus[map.arr.GetUpperBound(0)+1,map.arr.GetUpperBound(1)+1];
        for (int x = 0; x < map.arr.GetUpperBound(0)+1; x++){
            for (int y = 0; y < map.arr.GetUpperBound(1)+1; y++){
                if (map.arr[x,y] < 4)
                    t[x,y] = TileStatus.House;
                else if (map.arr[x,y] > 253)
                    t[x,y] = TileStatus.Road;
                else if (map.arr[x,y] == 10)
                    t[x,y] = TileStatus.Shop;
            }
        }
        return t;
    }

    public int[,] getInts(){
        return map.arr;
    }
}

class RoadDiv{
    
    // 0-3 are houses with n rotation
    // 255 is a vertical road, 254 is horizontal road
    public int[,] arr;

    // Start is called before the first frame update
    public RoadDiv(int size)
    {
        arr = new int[size, size];
        divVert(1, 1, size - 2, size - 2);
    }

    void divVert(int x1, int y1, int x2, int y2)
    {
        int num = numPositions(x1, x2);
        if (num == 0) return;

        int r = (int) Random.Range(0, num);
        num = getPosition(r, x1, x2);

        for (int i = y1; i <= y2; i++)
        {
            arr[num-1,i] = 1;
            arr[num,i] = 254;
            arr[num+1,i] = 3;
        }
        divHorz(x1, y1, num - 1, y2);
        divHorz(num + 1, y1, x2, y2);
    }

    void divHorz(int x1, int y1, int x2, int y2)
    {
        int num = numPositions(y1, y2);
        if (num == 0) return;

        int r = (int) Random.Range(0, num);
        num = getPosition(r, y1, y2);

        for (int i = x1; i <= x2; i++)
        {
            arr[i,num-1] = 0;
            arr[i,num] = 255;
            arr[i,num+1] = 2;
        }
        divVert(x1, y1, x2, num - 1);
        divVert(x1, num + 1, x2, y2);
    }

    int numPositions(int a, int b)
    {
        int num = 0;
        for (int i = a; i <= b; i++)
        {
            if ((i - 1) % 3 == 0) num++;
        }
        return num;
    }


    int getPosition(int num, int a, int b)
    {
        int n = -1;
        for (int i = a; i <= b; i++)
        {
            if ((i - 1) % 3 == 0) n++;
            if (n == num) return i;
        }
        return -1;
    }
}
