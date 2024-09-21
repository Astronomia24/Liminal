using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectTrigger : MonoBehaviour
{
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
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ped")
        {
            drinkCS.credit += 1;


        }






    }
}
