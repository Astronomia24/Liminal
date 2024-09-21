using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mTea : MonoBehaviour
{
    DrinkID drinkCS;
    public GameObject inHandMTea;
    public GameObject mlikTea;


    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        mlikTea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (drinkCS.haveMTea == 0)
        {
            inHandMTea.SetActive(false);
        }
        if (drinkCS.haveMTea == 1)
        {
            inHandMTea.SetActive(true);
        }
    }
    public void PickUpMTea()
    {
        mlikTea.SetActive(false);
        inHandMTea.SetActive(true);
        drinkCS.haveMTea = 1;
    }

    public void BuyMTea()
    {
        if (drinkCS.money >= 300)
        {
            drinkCS.money -= 300;
            mlikTea.SetActive(true);

        }
    }
}
