using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyer : MonoBehaviour
{
    DrinkID drinkCS;
    public int flyerbool;
    public GameObject flyers;
    pedestrian ped;
    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        ped = FindObjectOfType<pedestrian>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ped")
        {
            flyerbool = 1;
            flyers.SetActive(false);
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "ped")
        {
            flyerbool = 0;
        }
    }
}
