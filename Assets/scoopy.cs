using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoopy : MonoBehaviour
{

    public GameObject scooper;
    public int isScooping;

    Interactable interactable;
    DrinkID drinkCS;
 



    // Start is called before the first frame update
    void Start()
    {
        isScooping = 0;
        interactable = FindObjectOfType<Interactable>();
        drinkCS = FindObjectOfType<DrinkID>();
        scooper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Scooping()
    {
        isScooping = 1;
        scooper.SetActive(true);
        yield return new WaitForSeconds(1);
        drinkCS.iceAmount += 1;
        drinkCS.iceLeft -= 1;
        scooper.SetActive(false);
        isScooping = 0;

    }
}
