using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBag : MonoBehaviour
{
    DrinkID drinkCS;
    public GameObject icyBag;
    public GameObject inHandIceBag;
    public AudioSource src;
    public AudioClip sfx1;
    public GameObject nBag;
    public Transform spawner;
    // Start is called before the first frame update
    void Start()
    {
        nBag.SetActive(true);
        drinkCS = FindObjectOfType<DrinkID>();
        inHandIceBag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(drinkCS.haveIceBag == 0)
        {
            inHandIceBag.SetActive(false);
        }
        if(drinkCS.haveIceBag == 1)
        {
            inHandIceBag.SetActive(true);
        }
    }
    public void pickUpIceBag()
    {

        drinkCS.haveIceBag = 1;
        inHandIceBag.SetActive(true);
        icyBag.SetActive(false);
    }
    public void buyIceBag()
    {
        if (drinkCS.money >= 20)
        {
  
            drinkCS.money -= 20;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Instantiate(nBag, spawner.transform.position, Quaternion.identity);
        }
    }
    public void Scoop()
    {
        if (drinkCS.inHanded == 1)
        {
            src.clip = sfx1;
            src.Play();
        }
    }
}
