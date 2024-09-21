using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnim : MonoBehaviour
{

    public int time;
    DrinkID drinkCS;
    
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();

    }

    IEnumerator WaitCustomer()
    {
        yield return new WaitForSeconds(time);

    }

    void Update()
    {
        if(drinkCS.customerAppear == 0)
        {
            drinkCS.customerAppear = 1;
            time = Random.Range(10, 20);

            StartCoroutine(WaitCustomer());
        }
        if(drinkCS.customerAppear == 2)
        {

        }
    }
}
