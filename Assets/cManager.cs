using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cManager : MonoBehaviour
{
    DrinkID drinkCS;
    public Material cloth1;
    public Material cloth2;
    public GameObject player;

    





    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Buy1()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            player.GetComponent<MeshRenderer>().material = cloth1;
        }

    }
    public void Buy2()
    {
        if (drinkCS.money >= 200)
        {
            drinkCS.money -= 200;
            player.GetComponent<MeshRenderer>().material = cloth2;
        }

    }
}
