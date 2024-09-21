using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Laptop : MonoBehaviour
{
    public GameObject Player;
    public GameObject LaptopCam;
    public GameObject deco;
    public GameObject deco2;
    public GameObject deco3;
    public GameObject refillWindow;
    public GameObject decoWindow;
    public TextMeshProUGUI iceText;
    public TextMeshProUGUI blackTeaText;
    public TextMeshProUGUI greenTeaText;
    public TextMeshProUGUI milkTeaText;
    public Transform spawner;
    DrinkID drinkCS;
    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        deco.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        iceText.text = drinkCS.iceLeft + " ice remaining";
        blackTeaText.text = drinkCS.bTeaLeft + " black tea remaining";
        greenTeaText.text =  drinkCS.gTeaLeft + " green tea remaining";
        milkTeaText.text =  drinkCS.mTeaLeft  + " milk tea remaining";

    }

    public void ExitLaptop()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player.SetActive(true);
        LaptopCam.SetActive(false);
    }
    public void BuyDeco()
    {
        if (drinkCS.money >= 200)
        {
            drinkCS.money -= 200;
            deco.SetActive(true);
            Instantiate(deco, spawner.transform.position, Quaternion.identity);
        }
    }
    public void BuyDeco2()
    {
        if (drinkCS.money >= 300)
        {
            drinkCS.money -= 300;
            deco2.SetActive(true);
            Instantiate(deco2, spawner.transform.position, Quaternion.identity);
        }
    }
    public void BuyDeco3()
    {
        if (drinkCS.money >= 500)
        {
            drinkCS.money -= 500;
            deco3.SetActive(true);
            Instantiate(deco3, spawner.transform.position, Quaternion.identity);
        }
    }


    public void Refill()
    {
        refillWindow.SetActive(true);
        decoWindow.SetActive(false);
    }
    public void Deco()
    {
        decoWindow.SetActive(true);
        refillWindow.SetActive(false);
    }
}
