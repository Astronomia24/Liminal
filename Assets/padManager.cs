using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class padManager : MonoBehaviour
{
    public GameObject padCanvas;
    public Text[] nameText;
    public Text[] teaLeftText;
    public string[] teaNames;
    public int[] teaLeft;
    DrinkID drinkCS;
    nLaptop nl;
    colorControl cc;
    public AudioSource padSrc;
    public AudioClip ding1;
    public AudioClip ding2;
    public string[] teaTitles;
    public Text[] titleTexts;
    public string[] ingredients;
    public Text[] ingreText;
    public int currentPage;
    public GameObject[] pages;
    shelfStat sStat;


    
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        sStat = FindObjectOfType<shelfStat>();
        cc = FindObjectOfType<colorControl>();
        nl = FindObjectOfType<nLaptop>();
        cc.ColorUp();
        isOpen = false;
        padCanvas.SetActive(false);

    }
    public void Page0()
    {
        currentPage = 0;
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[currentPage].SetActive(true);
    }
    public void Page1()
    {
        currentPage = 1;
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[currentPage].SetActive(true);
    }
    public void Page2()
    {
        currentPage = 2;
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[currentPage].SetActive(true);
        for (int i = 0; i < titleTexts.Length; i++)
        {
            titleTexts[i].text = teaTitles[i];
        }
        for (int i = 0; i < ingreText.Length; i++)
        {
            ingreText[i].text = ingredients[i];
        }

        for (int i = 0; i < teaNames.Length; i++)
        {
            teaLeft[0] = drinkCS.bTeaLeft;
            teaLeft[1] = drinkCS.gTeaLeft;
            teaLeft[2] = drinkCS.mTeaLeft;
            teaLeft[3] = drinkCS.newIceAmount;
            nameText[i].text = teaNames[i];
            if (i == 4)
            {
                teaLeftText[i].text = teaLeft[i] + " g";
            }
            else
            {
                teaLeftText[i].text = teaLeft[i] + " ml";
            }

        }
    }
    public void Page3()
    {
        currentPage = 3;
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[currentPage].SetActive(true);
    }
    public void Page4()
    {
        currentPage = 4;
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[currentPage].SetActive(true);
    }

    public void Level1()
    {
        if(drinkCS.money >= 500 && drinkCS.credit > 300)
        {
            drinkCS.money -= 500;
            drinkCS.lv = 1;
            sStat.CheckStock();

            
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && nl.isPause == false)
        {
            currentPage = 0;
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].SetActive(false);
            }
            pages[currentPage].SetActive(true);

            if(isOpen == false)
            {
                { 

                padSrc.clip = ding1;
                padSrc.Play();
                padCanvas.SetActive(true);
                isOpen = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                }

            }
            else
            {
                padSrc.clip = ding2;
                padSrc.Play();
                padCanvas.SetActive(false);
                isOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

}
