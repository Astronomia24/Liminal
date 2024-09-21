using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serveTrigger : MonoBehaviour
{
    customerManager customer;
    tutorControl tut;
    PickUpClass pick;
    // Start is called before the first frame update
    void Start()
    {
        customer = FindObjectOfType<customerManager>();
        tut = FindObjectOfType<tutorControl>();
        pick = FindObjectOfType<PickUpClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "cup(Clone)" && Input.GetMouseButton(0) == false && pick.colliderName != "cup(Clone)")
        {
            customer.targetCup = other.gameObject.GetComponent<cupStats>();
            customer.CheckDrink();
            if (tut.step < 9)
            {
                tut.step = 9;
            }

        }
    }
}
