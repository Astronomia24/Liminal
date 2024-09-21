using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrinkID : MonoBehaviour
{
    public GameObject drink1;
    public GameObject drink2;
    public GameObject drink3;
    public int drinkID;
    public int orderID;
    public int iceID;
    public int lanID;

    public int inHanded;
    public int isSealed;
    public int money;
    public Text moneyText;
    public Text timeText;
    public Text dayText;
    public Text hourText;
    public Text levelText;
    public int iceAmount;
    public int sugarAmount;
    public GameObject [] ice = new GameObject[4];
    public GameObject seal;
    public int isOrdered;
    public int time;
    public int isCounting;
    public int credit;
    public int shake;
    public int customerAppear;
    public GameObject sugar;
    public Text creditScore;

    public int iceLeft;
    public int bTeaLeft;
    public int gTeaLeft;
    public int mTeaLeft;

    public GameObject icy;
    public int haveIceBag;
    public int haveBTea;
    public int haveGTea;
    public int haveMTea;
    public int day;
    public int isOrdering;
    public int playS;
    public AudioSource src;
    public AudioClip sfx2;
    public int sugarID;
    public int newIceAmount;


    inHandCupShake shakey;
    public int hour;
    public int minute;
    public int level;
    public int exp;
    public int expNeed;
    public GameObject Upanel;
    public Text upgradeText;
    public static int revenue;
    public GameObject ice1;
    public GameObject ice2;
    public GameObject ice3;
    public GameObject warning;
    public int bank;
    dayNightController dn;
    tutorControl tut;
    public static int language;
    public Text bankText;
    public int lv;



    // Start is called before the first frame update
    void Start()
    {
        lv = 0;
        lanID = DrinkID.language;
        bank = 0;
        Upanel.SetActive(false);
        level = 1;
        if (lanID == 0)
        {
            levelText.text = "单 " + level;
        }
        if (lanID == 1)
        {
            levelText.text = "Level  " + level;
        }
        if (lanID == 2)
        {
            levelText.text = "单 " + level;
        }
        if (lanID == 3)
        {
            levelText.text = "单 " + level;
        }
        if (lanID == 4)
        {
            levelText.text = "Level  " + level;
        }
        Invoke("Clock", 1f);
        sugar.SetActive(false);
        shakey = FindObjectOfType<inHandCupShake>();
        dn = FindObjectOfType<dayNightController>();
        tut = FindObjectOfType<tutorControl>();
        customerAppear = 0;
        time = 20;
        isOrdered = 0;
        isOrdering = 0;
        isSealed = 0;
        iceID = 0;
        inHanded = 0;
        money = 500;
        newIceAmount = 200;
        iceAmount = 0;
        sugarAmount = 0;
        credit = 100;
        shake = 0;
        iceLeft = 20;
        bTeaLeft = 900;
        gTeaLeft = 900;
        mTeaLeft = 900;
        haveIceBag = 0;
        haveBTea = 0;
        haveGTea = 0;
        haveMTea = 0;
        day = 1;
        playS = 0;
        sugarID = 0;
        hour = 6;
        minute = 0;
        exp = 0;
        expNeed = 100;
        revenue = 0;


        ice[0].SetActive(false);
        ice[1].SetActive(false);
        ice[2].SetActive(false);
        ice[3].SetActive(false);

        StartCoroutine(StartDay());

        warning.SetActive(false);


    }
    public void HidePanel()
    {
        Upanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Dissaper()
    {
        Upanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bankText.text = bank + " $";

        dayText.text = "Day" + " " + day;
        revenue = money;
        if (iceLeft <= 0)
        {
            ice1.SetActive(false);
            ice2.SetActive(false);
            ice3.SetActive(false);
            icy.SetActive(false);
        }
        else if(newIceAmount > 0 && newIceAmount < 30)
        {
            ice1.SetActive(true);
            ice2.SetActive(false);
            ice3.SetActive(false);
            icy.SetActive(true);
        }
        else if (newIceAmount > 30 && newIceAmount < 50)
        {
            ice1.SetActive(true);
            ice2.SetActive(true);
            ice3.SetActive(false);
            icy.SetActive(true);
        }
        else if (newIceAmount > 50 && newIceAmount < 100)
        {
            ice1.SetActive(true);
            ice2.SetActive(true);
            ice3.SetActive(true);
            icy.SetActive(true);
        }






        if(exp >= expNeed)
        {

            level += 1;
            exp = 0;
            expNeed += 1000;
            if(lanID == 0)
            {
                levelText.text = "单 " + level;
            }
            if(lanID == 1)
            {
                levelText.text = "Level  " + level;
            }
            if (lanID == 2)
            {
                levelText.text = "单 " + level;
            }
            if (lanID == 3)
            {
                levelText.text = "单 " + level;
            }
            if (lanID == 4)
            {
                levelText.text = "Level  " + level;
            }
            Upanel.SetActive(true);
            if (lanID == 0)
            {
                upgradeText.text = "笷单" + level;
            }
            if (lanID == 1)
            {
                upgradeText.text = "Level " + level;
            }
            if (lanID == 2)
            {
                upgradeText.text = "Level " + level;
            }
            if (lanID == 3)
            {
                upgradeText.text = "Level " + level;
            }
            if (lanID == 4)
            {
                upgradeText.text = "Level  " + level;
            }
            Invoke("HidePanel", 3f);
        }




        if(iceAmount == 0)
        {
            ice[0].SetActive(false);
            ice[1].SetActive(false);
            ice[2].SetActive(false);
            ice[3].SetActive(false);
        }
        if (iceAmount == 1)
        {
            ice[0].SetActive(true);
            ice[1].SetActive(false);
            ice[2].SetActive(false);
            ice[3].SetActive(false);
        }
        if (iceAmount == 2)
        {
            ice[0].SetActive(true);
            ice[1].SetActive(true);
            ice[2].SetActive(false);
            ice[3].SetActive(false);
        }
        if (iceAmount == 3)
        {
            ice[0].SetActive(true);
            ice[1].SetActive(true);
            ice[2].SetActive(true);
            ice[3].SetActive(false);
        }
        if (iceAmount >= 4)
        {
            ice[0].SetActive(true);
            ice[1].SetActive(true);
            ice[2].SetActive(true);
            ice[3].SetActive(true);
        }
        if(isSealed == 1)
        {
            seal.SetActive(true);
        }
        else
        {
            seal.SetActive(false);
        }


        if(playS == 1)
        {
            src.clip = sfx2;
            src.Play();
            playS = 0;
        }






            moneyText.text = money + " " + "$";

            timeText.text = "丁" + time;
        if (lanID == 0)
        {
            creditScore.text = " " + credit;
        }
        if (lanID == 1)
        {
            creditScore.text = "Popularity " + credit;
        }
        if (lanID == 2)
        {
            creditScore.text = " " + credit;
        }
        if (lanID == 3)
        {
            creditScore.text = "蒩 " + credit;
        }
        if (lanID == 4)
        {
            creditScore.text = "Bekanntheit " + credit;
        }




    }
    public IEnumerator StartDay()
    {
        yield return new WaitForSeconds(2);
        customerAppear = 2;
        if(day >= 3)
        {
            SceneManager.LoadScene("endemo");
        }




    }
    public void Clock()
    {
        minute += 1;
        if(minute >= 60)
        {
            minute = 0;
            hour += 1;
        }
        if(minute < 10)
        {
            hourText.text = hour + ":0" + minute;
        }
        else
        {
            hourText.text = hour + ":" + minute;
        }
        Invoke("Clock", 1f);
        if(hour > 24)
        {
            hour = 1;
            minute = 0;
            day += 1;
            dayText.text = "Day" + " " + day;
            StartCoroutine(StartDay());
            customerAppear = 2;


        }

        if(day == 2 && hour >= 18)
        {
            warning.SetActive(true);
        }

    }
    public void NextDay()
    {

        StartCoroutine(StartDay());
        customerAppear = 0;

    }


}
