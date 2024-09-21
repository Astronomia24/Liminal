using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class licenseControl : MonoBehaviour
{
    DrinkID drinkCS;
    public GameObject[] packs;
    shelfStat sStat;






    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        sStat = FindObjectOfType<shelfStat>();
        for (int i = 0; i < packs.Length; i++)
        {
            //packs[i].SetActive(false);
        }
    }


    public void Level1()
    {
        if(drinkCS.money > 5 && drinkCS.credit > 50)
        {
            drinkCS.money -= 5;
            drinkCS.lv = 1;
            //packs[0].SetActive(true);
            sStat.CheckStock();
            

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
