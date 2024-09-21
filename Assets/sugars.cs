using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sugars : MonoBehaviour
{
    public GameObject sugarCup;
    public GameObject inHandSugarCup;
    DrinkID drinkCS;



    // Start is called before the first frame update
    void Start()
    {
        inHandSugarCup.SetActive(false);
        drinkCS = FindObjectOfType<DrinkID>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddSugar()
    {
        if (drinkCS.inHanded == 1)
        {
            if (drinkCS.isSealed == 0)
            {

                sugarCup.SetActive(false);
                StartCoroutine(Adding());
            }
        }

    }
    IEnumerator Adding()
    {
        inHandSugarCup.SetActive(true);
        yield return new WaitForSeconds(2);
        inHandSugarCup.SetActive(false);
        sugarCup.SetActive(true);
        drinkCS.sugarAmount += 1;
    }
}
