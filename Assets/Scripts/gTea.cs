using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gTea : MonoBehaviour
{
    DrinkID drinkCS;
    public GameObject inHandGTea;
    public GameObject greenTea;

    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        greenTea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (drinkCS.haveGTea == 0)
        {
            inHandGTea.SetActive(false);
        }
        if (drinkCS.haveGTea == 1)
        {
            inHandGTea.SetActive(true);
        }
    }

    public void PickUpGTea()
    {
        greenTea.SetActive(false);
        inHandGTea.SetActive(true);
        drinkCS.haveGTea = 1;
    }

    public void BuyGTea()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            greenTea.SetActive(true);

        }
    }
}
