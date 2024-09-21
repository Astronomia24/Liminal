using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelfStat : MonoBehaviour
{
    public bool[] stock;
    public Transform[] spawn;
    public GameObject[] objects;
    public int[] price;
    shelfTrigger sTrigger;
    DrinkID drinkCS;
    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        CheckStock();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckStock()
    {
        for(int i = 0; i <7 + drinkCS.lv; i++)
        {
            if(stock[i] == false)
            {
                sTrigger = spawn[i].GetComponent<shelfTrigger>();
                sTrigger.shelfObj = Instantiate(objects[i], spawn[i].position, Quaternion.identity);
                sTrigger.shelfNumber = i;
                stock[i] = true;
            }
        }
    }
}
