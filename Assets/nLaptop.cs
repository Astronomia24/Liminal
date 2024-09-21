using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class nLaptop : MonoBehaviour
{
    public GameObject laptopCam;
    public GameObject laptopCanvas;
    public int laptopPage;
    public Text blackTeaText;
    public Text greenTeaText;
    public Text milkTeaText;
    public Text iceText;

    public GameObject deco;
    public GameObject deco2;
    public GameObject deco3;
    public GameObject deco4;
    public GameObject deco5;
    public GameObject deco6;

    public GameObject BTcan;
    public GameObject GTcan;
    public GameObject MTcan;
    public Transform spawner;
    DrinkID drinkCS;
    public GameObject refillWindow;
    public GameObject decoWindow;
    public GameObject infoWindow;
    public GameObject deco7;
    public GameObject deco8;
    public GameObject deco9;
    public GameObject milkbox;
    public GameObject sugarefill;
    public GameObject bobaBag;
    missionControl mc;
    tutorControl tut;
    public bool islaptop;
    public GameObject pause;
    public bool isPause;
    public GameObject mainCam;
    public GameObject floor1;
    public GameObject floor2;
    public Camera maic;
    public GameObject but1;
    public GameObject but2;
    public GameObject but3;
    public GameObject but4;
    public GameObject but5;






    // Start is called before the first frame update
    void Start()
    {

        laptopCam.SetActive(false);
        laptopCanvas.SetActive(false);
        drinkCS = FindObjectOfType<DrinkID>();
        deco.SetActive(false);
        deco2.SetActive(false);
        deco3.SetActive(false);
        deco4.SetActive(false);
        deco5.SetActive(false);
        deco6.SetActive(false);
        mc = FindObjectOfType<missionControl>();
        tut = FindObjectOfType<tutorControl>();
        islaptop = false;
        pause.SetActive(false);
        isPause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        floor1.SetActive(true);
        floor2.SetActive(false);
        maic = mainCam.GetComponent<Camera>();


    }

    // Update is called once per frame
    void Update()
    {

        iceText.text = drinkCS.iceLeft + " ice remaining";
        if(drinkCS.lanID == 0)
        {
            blackTeaText.text = drinkCS.bTeaLeft + " ml 紅茶剩餘";
            greenTeaText.text = drinkCS.gTeaLeft + " ml 綠茶剩餘";
            milkTeaText.text = drinkCS.mTeaLeft + " ml 奶茶剩餘";
            iceText.text = drinkCS.newIceAmount + " 克冰塊剩餘";
        }
        if (drinkCS.lanID == 1)
        {
            blackTeaText.text = drinkCS.bTeaLeft + " ml Black Tea Left";
            greenTeaText.text = drinkCS.gTeaLeft + " ml Green Tea Left";
            milkTeaText.text = drinkCS.mTeaLeft + " ml Mlik Tea Left";
            iceText.text = drinkCS.newIceAmount + " g ice Left";
        }
        if (drinkCS.lanID == 2)
        {
            blackTeaText.text = drinkCS.bTeaLeft + " ml 紅茶剩餘";
            greenTeaText.text = drinkCS.gTeaLeft + " ml 綠茶剩餘";
            milkTeaText.text = drinkCS.mTeaLeft + " ml ミルクティー 剩餘";
            iceText.text = drinkCS.newIceAmount + " g 氷剩餘";
        }
        if (drinkCS.lanID == 3)
        {
            blackTeaText.text = drinkCS.bTeaLeft + " ml 红茶 剩餘";
            greenTeaText.text = drinkCS.gTeaLeft + " ml 绿茶剩餘";
            milkTeaText.text = drinkCS.mTeaLeft + " ml 奶茶剩餘";
            iceText.text = drinkCS.newIceAmount + " g 冰剩餘";
        }
        if (drinkCS.lanID == 4)
        {
            blackTeaText.text = drinkCS.bTeaLeft + " ml Schwarzer Tee übrig";
            greenTeaText.text = drinkCS.gTeaLeft + " ml Grüner Tee übrig";
            milkTeaText.text = drinkCS.mTeaLeft + " ml Milchtee übrig";
            iceText.text = drinkCS.newIceAmount + " g Eis übrig";
        }
        if (Input.GetKeyDown(KeyCode.Escape) && islaptop == true)
        {
            ExitLaptop();
            pause.SetActive(false);


        }
        if (Input.GetKeyDown("escape") && islaptop == false && isPause == false)
        {
            pause.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPause = true;

        }


    }

    public void StartLaptop()
    {
        if (isPause == false)
        {
            laptopCam.SetActive(true);
            maic.enabled = false;
            laptopCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            islaptop = true;
        }

    }
    public void ExitLaptop()
    {

        maic.enabled = true;
        laptopCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        islaptop = false;
        laptopCam.SetActive(false);

    }
    public void BuyDeco1()
    {
        if (drinkCS.money >= 200)
        {
            drinkCS.money -= 200;
            deco.SetActive(true);
            Instantiate(deco, spawner.transform.position, Quaternion.identity);
            mc.Mission2();
            ExitLaptop();
        }
    }
    public void BuyDeco2()
    {
        if (drinkCS.money >= 300)
        {
            drinkCS.money -= 300;
            deco2.SetActive(true);
            Instantiate(deco2, spawner.transform.position, Quaternion.identity);
            mc.Mission2();
            ExitLaptop();
        }
    }
    public void BuyDeco3()
    {
        if (drinkCS.money >= 500)
        {
            drinkCS.money -= 500;
            deco3.SetActive(true);
            floor1.SetActive(false);
            floor2.SetActive(true);


            mc.Mission2();
            ExitLaptop();
        }
    }
    public void BuyDeco4()
    {
        if (drinkCS.money >= 350)
        {
            drinkCS.money -= 350;
            deco4.SetActive(true);
            Instantiate(deco4, spawner.transform.position, Quaternion.identity);
            mc.Mission2();
            ExitLaptop();
        }
    }
    public void BuyDeco5()
    {
        if (drinkCS.money >= 250)
        {
            drinkCS.money -= 250;
            deco5.SetActive(true);
            Instantiate(deco5, spawner.transform.position, Quaternion.identity);
            mc.Mission2();
            ExitLaptop();
        }
    }
    public void BuyDeco6()
    {
        if (drinkCS.money >= 200)
        {
            drinkCS.money -= 200;
            deco6.SetActive(true);
            Instantiate(deco6, spawner.transform.position, Quaternion.identity);
            mc.Mission2();
            ExitLaptop();
        }
    }
    public void BuyDeco7()
    {
        if (drinkCS.money >= 1000)
        {
            drinkCS.money -= 1000;
            deco7.SetActive(true);
            Instantiate(deco7, spawner.transform.position, Quaternion.identity);
            mc.Mission2();
            ExitLaptop();
        }
    }
    public void BuyDeco8()
    {
        if (drinkCS.money >= 200)
        {
            drinkCS.money -= 200;
            deco8.SetActive(true);
            Instantiate(deco8, spawner.transform.position, Quaternion.identity);
            mc.Mission2();
            ExitLaptop();
        }
    }
    public void BuyDeco9()
    {
        if (drinkCS.money >= 200)
        {
            drinkCS.money -= 200;
            deco9.SetActive(true);
            Instantiate(deco9, spawner.transform.position, Quaternion.identity);
            mc.Mission2();
            ExitLaptop();
        }
    }



    public void Refill()
    {
        refillWindow.SetActive(true);
        if(drinkCS.lanID == 0)
        {
            but1.SetActive(true);
            but2.SetActive(false);
            but3.SetActive(false);
            but4.SetActive(false);
            but5.SetActive(false);
        }
        if (drinkCS.lanID == 1)
        {
            but2.SetActive(true);
            but1.SetActive(false);
            but3.SetActive(false);
            but4.SetActive(false);
            but5.SetActive(false);
        }
        if (drinkCS.lanID == 2)
        {
            but2.SetActive(false);
            but1.SetActive(false);
            but3.SetActive(true);
            but4.SetActive(false);
            but5.SetActive(false);
        }
        if (drinkCS.lanID == 3)
        {
            but2.SetActive(false);
            but1.SetActive(false);
            but3.SetActive(false);
            but4.SetActive(true);
            but5.SetActive(false);
        }
        if (drinkCS.lanID == 4)
        {
            but2.SetActive(false);
            but1.SetActive(false);
            but3.SetActive(false);
            but4.SetActive(false);
            but5.SetActive(true);
        }
        decoWindow.SetActive(false);
        infoWindow.SetActive(false);
    }
    public void Deco()
    {
        decoWindow.SetActive(true);
        refillWindow.SetActive(false);
        infoWindow.SetActive(false);

    }
    public void Info()
    {
        decoWindow.SetActive(false);
        refillWindow.SetActive(false);
        infoWindow.SetActive(true);
    }
    public void RefillBT()
    {
        if (drinkCS.money >= 200)
        {
            drinkCS.money -= 200;
            BTcan.SetActive(true);
            Instantiate(BTcan, spawner.transform.position, Quaternion.identity);
            ExitLaptop();
            if (tut.step == 9)
            {
                tut.step = 10;
            }
        }


    }

    public void RefillMT()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            MTcan.SetActive(true);
            Instantiate(MTcan, spawner.transform.position, Quaternion.identity);
            ExitLaptop();
            if (tut.step == 9)
            {
                tut.step = 10;
            }
        }


    }
    public void RefillGT()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            GTcan.SetActive(true);
            Instantiate(GTcan, spawner.transform.position, Quaternion.identity);
            ExitLaptop();
            if(tut.step == 9)
            {
                tut.step = 10;
            }
        }


    }
    public void BuyMilk()
    {
        if (drinkCS.money >= 20)
        {
            drinkCS.money -= 20;
            Instantiate(milkbox, spawner.transform.position, Quaternion.identity);
            ExitLaptop();
        }


    }
    public void BuySugar()
    {
        if (drinkCS.money >= 20)
        {
            drinkCS.money -= 20;
            Instantiate(sugarefill, spawner.transform.position, Quaternion.identity);
            ExitLaptop();
        }


    }
    public void BuyBoba()
    {
        if (drinkCS.money >= 50)
        {
            drinkCS.money -= 50;
            Instantiate(bobaBag, spawner.transform.position, Quaternion.identity);
            ExitLaptop();
        }
    }
}
