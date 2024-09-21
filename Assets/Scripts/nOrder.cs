using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nOrder : MonoBehaviour
{

    public int timer;
    public GameObject oText;
    public GameObject ratingCanvas;
    public Text orderText;
    public int teaID;
    public int iceID;
    public int sugarID;
    public string tea;
    public string ice;
    public string sugar;
    public int ordered;
    public Text teaText;
    public Text flavorText;
    public Text timeText;
    public Text timerText;
    public Text totalText;
    public int teaRating;
    public int flavorRating;
    public int timeRating;
    public int totalRating;
    public int isTiming;
    public int timered;
    public int i;
    DrinkID drinkCS;
    public AudioSource src;
    public AudioClip sfx2;
    public AudioClip sfx3;
    public AudioClip sfx4;
    public int bobaID;
    public GameObject mood1;
    public GameObject mood2;
    public GameObject mood3;
    public int mood;

    public int stars;
    public GameObject star1;
    public GameObject star15;
    public GameObject star2;
    public GameObject star25;
    public GameObject star3;
    public GameObject star35;
    public GameObject star4;
    public GameObject star45;
    public GameObject star5;
    public GameObject mideye;
    public GameObject madeye;
    public int israted;


    nCustomer n;
    nBtea nb;
    nCheckServe nc;
    // Start is called before the first frame update
    void Start()
    {
        israted = 0;
        n = FindObjectOfType<nCustomer>();
        nb = FindObjectOfType<nBtea>();
        nc = FindObjectOfType<nCheckServe>();
        drinkCS = FindObjectOfType<DrinkID>();
        mood1.SetActive(false);
        mood2.SetActive(false);
        mood3.SetActive(false);

        teaRating = 0;
        flavorRating = 0;
        timeRating = 0;
        totalRating = 0;
        timer = 0;
        timered = 0;
        mood = 0;


        ordered = 0;
        ratingCanvas.SetActive(false);
        star5.SetActive(false);
        star45.SetActive(false);
        star4.SetActive(false);
        star35.SetActive(false);
        star3.SetActive(false);
        star25.SetActive(false);
        star2.SetActive(false);
        star15.SetActive(false);
        star1.SetActive(false);
        mideye.SetActive(false);
        madeye.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (n.orderable == 0)
        {
            oText.SetActive(false);
        }




    }
    public void StartOrder()
    {
        if (n.orderable == 1 && n.isgood == 1)
        {

            mood = 1;
            isTiming = 1;

            StartCoroutine(Timing());
            StartCoroutine(Talk());
            teaRating = 0;
            flavorRating = 0;
            timeRating = 0;
            totalRating = 0;

        }
            if (n.orderable == 1 && n.isgood == 1)
            {
                mood = 1;
                isTiming = 1;
                if (ordered == 0)
                {
                    if (drinkCS.credit < 150)
                    {
                        teaID = Random.Range(1, 4);
                    }
                    else if (drinkCS.credit > 150)
                    {
                        teaID = Random.Range(1, 7);
                    }
                    iceID = Random.Range(0, 5);
                    sugarID = Random.Range(0, 5);
                    bobaID = Random.Range(0, 2);
                    if (teaID == 1)
                    {
                        tea = "紅茶";
                    }
                    if (teaID == 2)
                    {
                        tea = "綠茶";
                    }
                    if (teaID == 3)
                    {
                        tea = "奶茶";
                    }
                    if (teaID == 4)
                    {
                        tea = "紅茶拿鐵";
                    }
                    if (teaID == 5)
                    {
                        tea = "奶綠";
                    }
                    if (teaID == 6)
                    {
                        tea = "重乳奶茶";
                    }

                    if (iceID == 0)
                    {
                        ice = "去冰";
                    }
                    if (iceID == 1)
                    {
                        ice = "微冰";
                    }
                    if (iceID == 2)
                    {
                        ice = "五分冰";
                    }
                    if (iceID == 3)
                    {
                        ice = "少冰";
                    }
                    if (iceID == 4)
                    {
                        ice = "正常冰";
                    }
                    if (sugarID == 0)
                    {
                        sugar = "無糖";
                    }
                    if (sugarID == 1)
                    {
                        sugar = "微糖";
                    }
                    if (sugarID == 2)
                    {
                        sugar = "半糖";
                    }
                    if (sugarID == 3)
                    {
                        sugar = "少糖";
                    }
                    if (sugarID == 4)
                    {
                        sugar = "正常糖";
                    }
                }
                ordered = 1;
                oText.SetActive(true);
                if (bobaID == 0)
                {
                    orderText.text = "我想要"  + tea + " " + " ，" + " " + ice + " " + " " + " " + sugar;
                }
                if (bobaID == 1)
                {
                    orderText.text = "我想要" + " " + "一杯" + " " + "珍珠 " + tea + " " + " " + " " + ice + " " + " " + " " + sugar;
                }


            }
        






    }
    public void Check()
    {
        isTiming = 0;
        timered = 0;
        if(timer <= 45)
        {
            timeRating += 10;
        }
        else if(timer <= 60)
        {

            timeRating += 5;


        }
        else if(timer <= 100)
        {

            timeRating -= 5;


        }
        else
        {
            timeRating -= 20;
        }




        if(nb.Bml + nb.Gml + nb.Mml <= 200)
        {
            teaRating -= 30;



        }
        else
        {
            teaRating += 10;


        }

        ordered = 0;
        Debug.Log("Gya");
        if (teaID == 1)
        {
            if (nb.Bml >= 250)
            {
                drinkCS.money += 75;
                if(bobaID == 1)
                {
                    drinkCS.money += 10;
                }
                flavorRating += 10;
                if(nb.useShaker == 1)
                {
                    flavorRating += 5;
                }
            }
            else
            {
                flavorRating -= 10;
                orderText.text = "我點紅茶欸，這是怎樣?";
                israted = 1;
            }
        }
        if (teaID == 2)
        {
            if (nb.Gml >= 250)
            {
                drinkCS.money += 50;
                flavorRating += 10;
                if (nb.useShaker == 1)
                {
                    flavorRating += 5;
                }
                if (bobaID == 1)
                {
                    drinkCS.money += 10;
                }
            }
            else
            {
                flavorRating -= 10;
                orderText.text = "在幹嘛，我的綠茶呢?";
                israted = 1;
            }
        }
        if (teaID == 3)
        {
            if (nb.Mml >= 250)
            {
                drinkCS.money += 100;
                flavorRating += 10;
                if (nb.useShaker == 1)
                {
                    flavorRating += 5;
                }
                if (bobaID == 1)
                {
                    drinkCS.money += 10;
                }
            }
            else
            {
                flavorRating -= 10;
                orderText.text = "我要的是奶茶。";
                israted = 1;
            }
        }
        if (teaID == 4)
        {
            if (nb.Bml >= 150 && nb.haveCupMilk == 1)
            {
                drinkCS.money += 150;
                flavorRating += 10;
                if (nb.useShaker == 1)
                {
                    flavorRating += 5;
                }
                if (bobaID == 1)
                {
                    drinkCS.money += 10;
                }
            }
            else
            {
                flavorRating -= 15;
                orderText.text = "我點紅茶拿鐵欸" + "這啥?";
                israted = 1;
            }
        }
        if (teaID == 5)
        {
            if (nb.Gml >= 150 && nb.haveCupMilk == 1)
            {
                drinkCS.money += 120;
                flavorRating += 10;
                if (nb.useShaker == 1)
                {
                    flavorRating += 5;
                }
                if (bobaID == 1)
                {
                    drinkCS.money += 10;
                }
            }
            else
            {
                flavorRating -= 15;
                orderText.text = "我點奶綠" + "送這甚麼鬼。";
                israted = 1;
            }
        }
        if (teaID == 6)
        {
            if (nb.Mml >= 150 && nb.haveCupMilk == 1)
            {
                drinkCS.money += 180;
                flavorRating += 10;
                if (nb.useShaker == 1)
                {
                    flavorRating += 5;
                }
                if (bobaID == 1)
                {
                    drinkCS.money += 10;
                }
            }
            else
            {
                flavorRating -= 15;
                orderText.text = "我的重乳奶茶勒?";
                israted = 1;
            }
        }
        if (nb.shake >= 10)
        {
            flavorRating += 2;
        }
        if (nb.iceAmount == iceID)
        {
            orderText.text = "這家飲料店挺好。";
            flavorRating += 5;

        }
        else if (nb.iceAmount != iceID)
        {
            flavorRating -= 5;
            if (nb.iceAmount != iceID && israted == 0)
            {
                orderText.text = "我明明要" + ice + "。";
                israted = 1;
            }


        }
        if (nb.sugarAmount == sugarID)
        {
            flavorRating += 5;
            orderText.text = "這家飲料店不錯。";





        }
        else if (nb.sugarAmount != sugarID)
        {
            flavorRating -= 5;
            if(nb.sugarAmount != sugarID && israted == 0)
            {
                orderText.text = "我不是要" + sugar + "嗎?";
                israted = 1;
            }






        }
        if (nb.haveBB == bobaID)
        {
            flavorRating += 5;




        }
        else 
        {
            orderText.text = "我的珍珠呢?";
            flavorRating -= 5;
            israted = 1;





        }
        if(israted == 0)
        {
            orderText.text = "這家店做得不錯。";
            israted = 1;
        }

        n.leave();

        Reset();



    }



        
    
    public void Ratings()
    {
        src.clip = sfx4;
        src.Play();
        ratingCanvas.SetActive(true);
        teaText.text = "Filling Rating" + ":" + teaRating;
        flavorText.text = "Flavor Accuracy" + ":" + flavorRating;
        timeText.text = "Time Bonus" + ":" + timeRating;
        totalRating = teaRating + timeRating + flavorRating;
        totalText.text = "Total" + ":" + " " + totalRating;
        if (timer >= 150)
        {
            totalText.text = "Total" + ":" + " " + -70;
            totalRating = -70;
        }
        else
        {

            totalText.text = "Total" + ":" + " " + totalRating;
        }
        timer = 0;

        if (totalRating >= 52)
        {
            stars = 50;
            star5.SetActive(true);
            star45.SetActive(false);
            star4.SetActive(false);
            star35.SetActive(false);
            star3.SetActive(false);
            star25.SetActive(false);
            star2.SetActive(false);
            star15.SetActive(false);
            star1.SetActive(false);
        }
        if(totalRating >= 45 && totalRating< 52)
        {
            stars = 45;
            star5.SetActive(false);
            star45.SetActive(true);
            star4.SetActive(false);
            star35.SetActive(false);
            star3.SetActive(false);
            star25.SetActive(false);
            star2.SetActive(false);
            star15.SetActive(false);
            star1.SetActive(false);
        }
        if(totalRating >= 31 && totalRating < 45)
        {
            stars = 40;
            star5.SetActive(false);
            star45.SetActive(false);
            star4.SetActive(true);
            star35.SetActive(false);
            star3.SetActive(false);
            star25.SetActive(false);
            star2.SetActive(false);
            star15.SetActive(false);
            star1.SetActive(false);
        }
        if (totalRating >= 20 && totalRating < 31)
        {
            stars = 35;
            star5.SetActive(false);
            star45.SetActive(false);
            star4.SetActive(false);
            star35.SetActive(true);
            star3.SetActive(false);
            star25.SetActive(false);
            star2.SetActive(false);
            star15.SetActive(false);
            star1.SetActive(false);
        }
        if (totalRating >= 10 && totalRating < 20)
        {
            stars = 30;
            star5.SetActive(false);
            star45.SetActive(false);
            star4.SetActive(false);
            star35.SetActive(false);
            star3.SetActive(true);
            star25.SetActive(false);
            star2.SetActive(false);
            star15.SetActive(false);
            star1.SetActive(false);
        }
        if (totalRating >= 0 && totalRating < 10)
        {
            stars = 25;
            star5.SetActive(false);
            star45.SetActive(false);
            star4.SetActive(false);
            star35.SetActive(false);
            star3.SetActive(false);
            star25.SetActive(true);
            star2.SetActive(false);
            star15.SetActive(false);
            star1.SetActive(false);
        }
        if (totalRating >= -10 && totalRating < 0)
        {
            stars = 20;
            star5.SetActive(false);
            star45.SetActive(false);
            star4.SetActive(false);
            star35.SetActive(false);
            star3.SetActive(false);
            star25.SetActive(false);
            star2.SetActive(true);
            star15.SetActive(false);
            star1.SetActive(false);
        }
        if (totalRating >= -20 && totalRating < -10)
        {
            stars = 15;
            star5.SetActive(false);
            star45.SetActive(false);
            star4.SetActive(false);
            star35.SetActive(false);
            star3.SetActive(false);
            star25.SetActive(false);
            star2.SetActive(false);
            star15.SetActive(true);
            star1.SetActive(false);
        }
        if (totalRating <= -20)
        {
            stars = 10;
            star5.SetActive(false);
            star45.SetActive(false);
            star4.SetActive(false);
            star35.SetActive(false);
            star3.SetActive(false);
            star25.SetActive(false);
            star2.SetActive(false);
            star15.SetActive(false);
            star1.SetActive(true);
        }
        isTiming = 0;
        ordered = 0;
        timered = 0;
        timerText.text = "Time : " + timer;
        StartCoroutine(transfer());
        



    }
    public void Reset()
    {
        nc.Cup.SetActive(false);
        nc.Cup.transform.position = new Vector3(2.09f, 1.2f, 1.2f);
        nc.Cup.transform.localRotation = Quaternion.Euler(0, 0, 0);
        nc.Cup.SetActive(true);
        nb.teaa.SetActive(false);
        nb.cupTrigger.SetActive(true);
        mood1.SetActive(false);
        mood2.SetActive(false);
        mood3.SetActive(false);



        nb.Bml = 0;
        nb.Gml = 0;
        nb.Mml = 0;
        nb.shake = 0;
        nb.iceAmount = 0;
        nb.sugarAmount = 0;
        nb.teaID = 0;
        nb.isSealed = 0;
        nb.haveBB = 0;
        Ratings();
    }



    IEnumerator Timing()
    {
        if (timered == 0)
        {

            timered = 1;
            mood1.SetActive(true);
            while (isTiming == 1)
            {

                timerText.text = "Time : " + timer;
                yield return new WaitForSeconds(1);
                timer++;

                if (timer >= 45)
                {

                    mood1.SetActive(false);
                    mood2.SetActive(true);
                    mideye.SetActive(true);

                }
                if(timer >= 100)
                {
                    mideye.SetActive(false);
                    madeye.SetActive(true);
                    mood2.SetActive(false);
                    mood3.SetActive(true);
                }
                if(timer > 150)
                {
                    mood3.SetActive(false);
                    mideye.SetActive(false);
                    madeye.SetActive(false);

                    Reset();
                    n.leave();
                }
                if(timer == 45 || timer == 100)
                {
                    src.clip = sfx3;
                    src.Play();
                }


            }
        }



    }
    IEnumerator transfer()
    {

        yield return new WaitForSeconds(5);
        israted = 0;

        drinkCS.credit += totalRating;
        drinkCS.exp += totalRating;
        ratingCanvas.SetActive(false);
        totalRating = 0;
        teaRating = 0;
        flavorRating = 0;
        timeRating = 0;
        timer = 0;
        star5.SetActive(false);
        star45.SetActive(false);
        star4.SetActive(false);
        star35.SetActive(false);
        star3.SetActive(false);
        star25.SetActive(false);
        star2.SetActive(false);
        star15.SetActive(false);
        star1.SetActive(false);
        mideye.SetActive(false);
        madeye.SetActive(false);





    }
    IEnumerator Talk()
    {
        for (i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.1f);
            src.clip = sfx2;
            src.Play();
        }
    }

}

