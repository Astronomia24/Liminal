using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bTea : MonoBehaviour
{
    DrinkID drinkCS;
    public GameObject inHandBTea;
    public GameObject blackTea;


    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        blackTea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (drinkCS.haveBTea== 0)
        {
            inHandBTea.SetActive(false);
        }
        if (drinkCS.haveBTea == 1)
        {
            inHandBTea.SetActive(true);
        }
    }

    public void PickUpBTea()
    {
        blackTea.SetActive(false);
        inHandBTea.SetActive(true);
        drinkCS.haveBTea = 1;
    }

    public void BuyBTea()
    {
        if(drinkCS.money >= 200)
        {
            drinkCS.money -= 200;
            blackTea.SetActive(true);

        }
    }
}
