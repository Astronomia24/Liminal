using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milkManage : MonoBehaviour
{

    public GameObject milk;
    public GameObject spawner;
    DrinkID drinkCS;





    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyMilk()
    {
        if (drinkCS.money >= 15)
        {
            Instantiate(milk, spawner.transform.position, Quaternion.identity);
            drinkCS.money -= 15;
        }
    }
}
