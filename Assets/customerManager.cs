using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customerManager : MonoBehaviour
{
    public GameObject orderTextObj;
    public GameObject timeTextObj;
    public GameObject scoreTextObj;
    nBtea nb;
    public Text ordertext;
    public Text timeText;
    public Text scoreText;
    public int teaID;
    public int iceID;
    public int sugarID;
    public string[] teaString;
    public string[] iceString;
    public string[] sugarString;
    public string[] response;
    public string[] teaString1;
    public string[] teaString2;
    public string[] teaString3;
    public string[] teaString4;
    public string[] iceString1;
    public string[] iceString2;
    public string[] iceString3;
    public string[] iceString4;
    public string[] sugarString1;
    public string[] sugarString2;
    public string[] sugarString3;
    public string[] sugarString4;
    public string[] response1;
    public float timer;
    public int time;
    public int score;
    public GameObject[] stars;
    public GameObject[] customers;
    public int i;
    public int haveBoba;
    public bool ordered;
    public GameObject drinkCheck;
    public AudioSource src;
    public AudioClip sfx;
    public AudioClip timeee;
    public AudioClip ding;
    DrinkID drinkCS;
    public int[] price;
    public int totalPrice;
    public GameObject Cup;
    comeScript come;
    missionControl mc;
    PickUpClass pick;
    public Transform spawning;
    public bool ring;
    tutorControl tut;
    public Rigidbody cupRb;
    public GameObject moneyAnim;
    emoteControl emote;
    public Text montxt;
    public cupStats targetCup;


    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
        come = FindObjectOfType<comeScript>();
        drinkCS = FindObjectOfType<DrinkID>();
        mc = FindObjectOfType<missionControl>();
        emote = FindObjectOfType<emoteControl>();
        orderTextObj.SetActive(false);
        timeTextObj.SetActive(false);
        scoreTextObj.SetActive(false);
        drinkCheck.SetActive(false);
        ordered = false;
        nb = FindObjectOfType<nBtea>(); 
        tut = FindObjectOfType<tutorControl>();
        for (i = 0; i < 10; i++)
        {
            stars[i].SetActive(false);
        }
        customers[0].name = "ped";
        Invoke("CustomerAppear", 5f);
        ring = false;
        moneyAnim.SetActive(false);
    }
    public void HideMoney()
    {
        moneyAnim.SetActive(false);
        drinkCS.bank += totalPrice;
        totalPrice = 0;

    }
    public void HideMone2()
    {
        moneyAnim.SetActive(false);
        totalPrice = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            if(tut.step < 10)
            {
                if(drinkCS.lanID == 0 || drinkCS.lanID == 3)
                {
                    timeText.text = "剩餘時間" + "∞";
                }
                if(drinkCS.lanID == 1)
                {
                    timeText.text = "Time Left: " + "∞";
                }
                if (drinkCS.lanID == 2)
                {
                    timeText.text = "残り時間: " + "∞";
                }
                if (drinkCS.lanID == 4)
                {
                    timeText.text = "Verbleibende Zeit: " + "∞";
                }

            }

            else
            {
                timer -= Time.deltaTime;
                time = (int)timer;
                if (drinkCS.lanID == 0 || drinkCS.lanID == 3)
                {
                    timeText.text = "剩餘時間" + time;
                }
                if (drinkCS.lanID == 1)
                {
                    timeText.text = "Time Left: " + time;
                }
                if (drinkCS.lanID == 2)
                {
                    timeText.text = "残り時間: " + time;
                }
                if (drinkCS.lanID == 4)
                {
                    timeText.text = "Verbleibende Zeit: " + time;
                }
            }

        }
        if(timer >= 30 && timer < 100)
        {
            emote.emote.SetActive(false);
            emote.emote2.SetActive(true);
            emote.emote3.SetActive(false);
        }
        if(timer < 30 && ring == false && timer > 0)
        {
            emote.emote.SetActive(false);
            emote.emote2.SetActive(false);
            emote.emote3.SetActive(true);
            src.clip = timeee;
            src.Play();
            ring = true;
        }
        if(timer < 0)
        {
            timeTextObj.SetActive(false);
            if (drinkCS.lanID == 0 || drinkCS.lanID == 3)
            {
                ordertext.text = "等不下去了...";
            }
            if (drinkCS.lanID == 1)
            {
                ordertext.text = "Took way too long... I'm leaving";
            }
            if (drinkCS.lanID == 2)
            {
                ordertext.text = "長すぎる、もう帰るよ";
            }
            if (drinkCS.lanID == 4)
            {
                ordertext.text = "Hat viel zu lange gedauert... Ich gehe";
            }
            timer = 0;
            customers[0].name = "ped";
            drinkCheck.SetActive(false);
            score = -70;
            drinkCS.creditScore.text = "Popularity " + drinkCS.credit;
            stars[1].SetActive(true);
            if (drinkCS.lanID == 0 || drinkCS.lanID == 3)
            {
                scoreText.text = "訂單評分: " + score;
            }
            if (drinkCS.lanID == 1)
            {
                scoreText.text = "Ratings:  " + score;
            }
            if (drinkCS.lanID == 2)
            {
                scoreText.text = "評価:  " + score;
            }
            if (drinkCS.lanID == 4)
            {
                scoreText.text = "Bewertungen:  " + score;
            }
            ordered = false;
            src.clip = sfx;
            src.Play();


            Cup.SetActive(false);

            Cup.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Cup.SetActive(true);
            nb.teaa.SetActive(false);
            nb.cupTrigger.SetActive(true);








            Invoke("UIGone", 5f);
            Invoke("CustomerAppear", 5f);

        }
    }
    public void CustomerAppear()
    {


    }
    public void StartOrder()
    {
        src.clip = ding;
        src.Play();
        ring = false;
        totalPrice = 0;
        drinkCheck.SetActive(true);
        for (i = 0; i<10; i++)
        {
            stars[i].SetActive(false);
        }
        score = 0;
        timeTextObj.SetActive(true);
        scoreTextObj.SetActive(false);
        emote.emote.SetActive(true);
        emote.emote2.SetActive(false);
        emote.emote3.SetActive(false);

        timer = 150;
        if(drinkCS.level >= 2)
        {
            teaID = Random.Range(1, 7);
        }
        else
        {

            teaID = Random.Range(1, 4);
        }
        if (tut.step < 9)
        {
            iceID = Random.Range(1, 5);
            sugarID = Random.Range(1, 5);
        }
        else
        {
            iceID = Random.Range(0, 5);
            sugarID = Random.Range(0, 5);
        }
        haveBoba = Random.Range(0, 2);
        orderTextObj.SetActive(true);
        totalPrice = price[teaID];

        if (haveBoba == 1)
        {
            if (drinkCS.lanID == 0)
            {
                ordertext.text = "我要一杯" + "珍珠" + teaString[teaID] + ",  " + iceString[iceID] + ",  " + sugarString[sugarID];
            }
            if (drinkCS.lanID == 1)
            {
                ordertext.text = "I want a " + "boba " + teaString1[teaID] + ",  " + iceString1[iceID] + ",  " + sugarString1[sugarID];
            }
            if (drinkCS.lanID == 2)
            {
                ordertext.text = "タピオカ " + teaString2[teaID] + "を一杯ください,  " + iceString2[iceID] + ",  " + sugarString2[sugarID];
            }
            if (drinkCS.lanID == 3)
            {
                ordertext.text = "我要一杯" + "珍珠" + teaString3[teaID] + ",  " + iceString3[iceID] + ",  " + sugarString3[sugarID];
            }
            if (drinkCS.lanID == 4)
            {
                ordertext.text = "Ich möchte einen" + "Perlen-" + teaString4[teaID] + ",  " + iceString4[iceID] + ",  " + sugarString4[sugarID];
            }
            totalPrice += 10;
        }
        else
        {
            if (drinkCS.lanID == 0)
            {
                ordertext.text = "我要一杯" + teaString[teaID] + ",  " + iceString[iceID] + ",  " + sugarString[sugarID];
            }
            if (drinkCS.lanID == 1)
            {
                ordertext.text = "I want a " + teaString1[teaID] + ",  " + iceString1[iceID] + ",  " + sugarString1[sugarID];
            }
            if (drinkCS.lanID == 2)
            {
                ordertext.text = teaString2[teaID] + "を一杯ください,  " + iceString2[iceID] + ",  " + sugarString2[sugarID];
            }
            if (drinkCS.lanID == 3)
            {
                ordertext.text = "我要一杯" + teaString3[teaID] + ",  " + iceString3[iceID] + ",  " + sugarString3[sugarID];
            }
            if (drinkCS.lanID == 4)
            {
                ordertext.text = "Ich möchte einen" + teaString4[teaID] + ",  " + iceString4[iceID] + ",  " + sugarString4[sugarID];
            }
        }
    }
    public void CheckDrink()
    {
        
        if (pick.CurrentObjRigidbody)
        {
            pick.src.clip = sfx;
            pick.src.Play();
            pick.shakerText.SetActive(false);
            pick.isShaker = 0;
            pick.shakerLid.SetActive(false);
            pick.src.clip = sfx;
            pick.src.Play();
            pick.CurrentObjRigidbody.isKinematic = false;
            pick.CurrentObjCollider.enabled = true;
            pick.CurrentObjRigidbody = null;
            pick.CurrentObjCollider = null;
            pick.colliderName = null;

        }
        cupRb = Cup.GetComponent<Rigidbody>();
        cupRb.velocity = Vector3.zero;

        Cup.SetActive(true);
        scoreTextObj.SetActive(true);
        if (iceID != targetCup.iceAmount)
        {
            if(iceID < targetCup.iceAmount)
            {
                if (drinkCS.lanID == 0)
                {
                    ordertext.text = "冰裝那麼多是要我吃冰塊?";
                }
                if (drinkCS.lanID == 1)
                {
                    ordertext.text = "Bro got me a tea flavored ice pack.";
                }
                if (drinkCS.lanID == 2)
                {
                    ordertext.text = "氷が多すぎる...";
                }
                if (drinkCS.lanID == 3)
                {
                    ordertext.text = "冰塊太多了...";
                }
                if (drinkCS.lanID == 4)
                {
                    ordertext.text = "Zu viel Eis...";
                }

            }
            if (iceID > targetCup.iceAmount)
            {
                if (drinkCS.lanID == 0)
                {
                    ordertext.text = "冰也給的太少了...";
                }
                if (drinkCS.lanID == 1)
                {
                    ordertext.text = "Where did the ice go?";
                }
                if (drinkCS.lanID == 2)
                {
                    ordertext.text = "氷が少なすぎる...";
                }
                if (drinkCS.lanID == 3)
                {
                    ordertext.text = "冰也給的太少了...";
                }
                if (drinkCS.lanID == 4)
                {
                    ordertext.text = "Zu wenig Eis";
                }
            }

            score -= 10;
        }
        else
        {
            score += 10;
        }
        if(sugarID != targetCup.sugarAmount)
        {
            if(sugarID < targetCup.sugarAmount)
            {
                if (drinkCS.lanID == 0)
                {
                    ordertext.text = "這飲料是台南買來的?";
                }
                if (drinkCS.lanID == 1)
                {
                    ordertext.text = "Very Sweet, The ants gonna love this drink.";
                }
                if (drinkCS.lanID == 2)
                {
                    ordertext.text = "この飲み物は甘すぎる";
                }
                if (drinkCS.lanID == 3)
                {
                    ordertext.text = "這飲料太甜了...";
                }
                if (drinkCS.lanID == 4)
                {
                    ordertext.text = "Dieses Getränk ist zu süß";
                }

            }
            if (sugarID > targetCup.sugarAmount)
            {
                if (drinkCS.lanID == 0)
                {
                    ordertext.text = "完全沒有甜味...回去快篩一下好了";
                }
                if (drinkCS.lanID == 1)
                {
                    ordertext.text = "Tastes like water.";
                }
                if (drinkCS.lanID == 2)
                {
                    ordertext.text = "この飲み物は全く甘くない";
                }
                if (drinkCS.lanID == 3)
                {
                    ordertext.text = "這飲料完全沒味道!";
                }
                if (drinkCS.lanID == 4)
                {
                    ordertext.text = "Dieses Getränk hat keinen Geschmack";
                }

            }

            score -= 10;
        }
        else
        {
            score += 10;
        }
        if(haveBoba != targetCup.haveBoba)
        {
            if(haveBoba == 1)
            {
                if (drinkCS.lanID == 0)
                {
                    ordertext.text = "我要的珍珠呢?";
                }
                if (drinkCS.lanID == 1)
                {
                    ordertext.text = "Where's my boba?";
                }
                if (drinkCS.lanID == 2)
                {
                    ordertext.text = "タピオカ?";
                }
                if (drinkCS.lanID == 3)
                {
                    ordertext.text = "珍珠呢?";
                }
                if (drinkCS.lanID == 4)
                {
                    ordertext.text = "Wo sind meine Perlen?";
                }
            }
            else
            {
                if (drinkCS.lanID == 0)
                {
                    ordertext.text = "你還免費幫我加料...?";
                }
                if (drinkCS.lanID == 1)
                {
                    ordertext.text = "Extra boba for free? ...Thanks a lot.";
                }
                if (drinkCS.lanID == 2)
                {
                    ordertext.text = "私の飲み物に無料でトッピングを追加してくれましたか？";
                }
                if (drinkCS.lanID == 3)
                {
                    ordertext.text = "你還順便加料?";
                }
                if (drinkCS.lanID == 4)
                {
                    ordertext.text = "Warum haben Sie mir kostenlos Perlen hinzugefügt?";
                }
            }
            score -= 10;
        }
        else
        {
            score += 10;
        }
        if (targetCup.teaID != teaID)
        {
            if (drinkCS.lanID == 0)
            {
                ordertext.text = "連茶都裝錯還開甚麼飲料店...";
            }
            if (drinkCS.lanID == 1)
            {
                ordertext.text = "You should get other jobs then this one.";
            }
            if (drinkCS.lanID == 2)
            {
                ordertext.text = "飲み物さえ間違っている...";
            }
            if (drinkCS.lanID == 3)
            {
                ordertext.text = "茶都裝錯，開什麼奶茶店...";
            }
            if (drinkCS.lanID == 4)
            {
                ordertext.text = "Wie kann man einen Teeladen führen, wenn man nicht einmal den Tee richtig einfüllt?";
            }

            score -= 20;
        }
        else
        {
            score += 20;
        }
        if (targetCup.haveMilk == 1)
        {
            if (targetCup.Bml + targetCup.Gml + targetCup.Mml < 100)
            {
                if (drinkCS.lanID == 0)
                {
                    ordertext.text = "飲料裝這麼少是要給誰喝?";
                }
                if (drinkCS.lanID == 1)
                {
                    ordertext.text = "Did you drink it all or something? Where did all the tea go?";
                }
                if (drinkCS.lanID == 2)
                {
                    ordertext.text = "飲み物が少なすぎる";
                }
                if (drinkCS.lanID == 3)
                {
                    ordertext.text = "飲料給這麼少?";
                }
                if (drinkCS.lanID == 4)
                {
                    ordertext.text = "So wenig Getränk?";
                }
                score -= 20;
            }
            else
            {
                score += 20;
            }
        }
        else
        {
            if (targetCup.Bml + targetCup.Gml + targetCup.Mml < 250)
            {
                if (drinkCS.lanID == 0)
                {
                    ordertext.text = "飲料裝這麼少是要給誰喝?";
                }
                if (drinkCS.lanID == 1)
                {
                    ordertext.text = "Did you drink it all or something? Where did all the tea go?";
                }
                if (drinkCS.lanID == 2)
                {
                    ordertext.text = "飲み物が少なすぎる";
                }
                if (drinkCS.lanID == 3)
                {
                    ordertext.text = "飲料給這麼少?";
                }
                if (drinkCS.lanID == 4)
                {
                    ordertext.text = "So wenig Getränk?";
                }
                score -= 20;
            }
            else
            {
                score += 20;
            }
        }
        if (iceID != targetCup.iceAmount && sugarID != targetCup.sugarAmount && targetCup.teaID != teaID + 1 && targetCup.Bml + targetCup.Gml + targetCup.Mml < 250 && haveBoba != targetCup.haveBoba) 
        {
            if (drinkCS.lanID == 0)
            {
                ordertext.text = "這絕對撐不過試營運";
            }
            if (drinkCS.lanID == 1)
            {
                ordertext.text = "You guys aren't making out the soft opening with this one.";
            }
            if (drinkCS.lanID == 2)
            {
                ordertext.text = "この店は潰れるかもしれない";
            }
            if (drinkCS.lanID == 3)
            {
                ordertext.text = "這家差不多倒了";
            }
            if (drinkCS.lanID == 4)
            {
                ordertext.text = " Dieser Laden wird bald schließen";
            }

            score -= 10;
        }
        if (iceID == targetCup.iceAmount && sugarID == targetCup.sugarAmount && targetCup.teaID == teaID + 1 && targetCup.Bml + targetCup.Gml + targetCup.Mml >= 250 && haveBoba == targetCup.haveBoba)
        {
            if (drinkCS.lanID == 0)
            {
                ordertext.text = "這家挺不錯喝的，有前途";
            }
            if (drinkCS.lanID == 1)
            {
                ordertext.text = "Looking decent.";
            }
            if (drinkCS.lanID == 2)
            {
                ordertext.text = "Looking decent.";
            }
            if (drinkCS.lanID == 3)
            {
                ordertext.text = "Looking decent.";
            }
            if (drinkCS.lanID == 4)
            {
                ordertext.text = "Looking decent.";
            }

            score += 10;

        }
        if (timer >= 60)
        {
            score += 0;
        }
        if(timer < 60 && timer >= 30)
        {
            score -= 10;
        }
        if (timer < 30)
        {
            score -= 20;
            if (drinkCS.lanID == 0)
            {
                ordertext.text = "我等到對面那家都要開了";
            }
            if (drinkCS.lanID == 1)
            {
                ordertext.text = "Took you long enough.";
            }
            if (drinkCS.lanID == 2)
            {
                ordertext.text = "待ち時間が長すぎる";
            }
            if (drinkCS.lanID == 3)
            {
                ordertext.text = "做的可真快";
            }
            if (drinkCS.lanID == 4)
            {
                ordertext.text = "Hat viel zu lange gedauert";
            }

        }
        if (drinkCS.lanID == 0)
        {
            scoreText.text = "訂單評分: " + score;
        }
        if (drinkCS.lanID == 1)
        {
            scoreText.text = "Ratings:  " + score;
        }
        if (drinkCS.lanID == 2)
        {
            scoreText.text = "評価:  " + score;
        }
        if (drinkCS.lanID == 3)
        {
            scoreText.text = "評価:  " + score;
        }
        if (drinkCS.lanID == 4)
        {
            scoreText.text = "Bewertung:";
        }

        if (score == 80)
        {
            for (i = 0; i < 10; i++)
            {
                stars[i].SetActive(true);
                mc.Mission1();
            }
        }
        if (score < 80 && score >= 70)
        {
            for (i = 0; i < 9; i++)
            {
                stars[i].SetActive(true);
                mc.Mission1();
            }
        }
        if (score < 70 && score >= 50)
        {
            for (i = 0; i < 8; i++)
            {
                stars[i].SetActive(true);
                mc.Mission1();
            }
        }
        if (score < 50 && score >= 30)
        {
            for (i = 0; i < 7; i++)
            {
                stars[i].SetActive(true);
                mc.Mission1();
            }
        }
        if (score < 30 && score >= 10)
        {
            for (i = 0; i < 6; i++)
            {
                stars[i].SetActive(true);
                mc.Mission1();
            }
        }
        if (score < 10 && score >= -10)
        {
            for (i = 0; i < 5; i++)
            {
                stars[i].SetActive(true);
            }
        }
        if (score < -10 && score >= -30)
        {
            for (i = 0; i < 4; i++)
            {
                stars[i].SetActive(true);
            }
        }
        if (score < -30 && score >= -40)
        {
            for (i = 0; i < 3; i++)
            {
                stars[i].SetActive(true);
            }
        }
        if (score < -40 && score >= -55)
        {
            for (i = 0; i < 2; i++)
            {
                stars[i].SetActive(true);
            }
        }
        if (score < -55 && score >= -80)
        {
            for (i = 0; i < 1; i++)
            {
                stars[i].SetActive(true);
            }
        }
        drinkCS.credit += score;
        drinkCS.exp += score;
        drinkCS.creditScore.text = "Popularity " + drinkCS.credit;

        customers[0].name = "ped";
        timer = 0;
        timeTextObj.SetActive(false);
        drinkCheck.SetActive(false);
        montxt = moneyAnim.GetComponent<Text>();
        if (teaID <= 3)
        {
            if (targetCup.Bml + targetCup.Gml + targetCup.Mml >= 250)
            {
                montxt.text = "+ " + totalPrice + " $";
                moneyAnim.SetActive(true);
                nb.Bml = 0;
                nb.Gml = 0;
                nb.Mml = 0;
                Invoke("HideMoney", 1f);


            }
            else
            {
                montxt.text = "+ " + "0 " + " $";
                moneyAnim.SetActive(true);
                nb.Bml = 0;
                nb.Gml = 0;
                nb.Mml = 0;
                Invoke("HideMone2", 1f);
            }
        }
        else
        {
            if (nb.Bml + nb.Gml + nb.Mml >= 100)
            {
                montxt.text = "+ " + totalPrice + " $";
                moneyAnim.SetActive(true);
                nb.Bml = 0;
                nb.Gml = 0;
                nb.Mml = 0;
                Invoke("HideMoney", 1f);


            }
            else
            {
                montxt.text = "+ " + "0 " + " $";
                moneyAnim.SetActive(true);
                nb.Bml = 0;
                nb.Gml = 0;
                nb.Mml = 0;
                Invoke("HideMone2", 1f);
            }
        }
        src.clip = sfx;
        src.Play();


        nb.teaa.SetActive(false);
        nb.cupTrigger.SetActive(true);
        ordered = false;



        targetCup.Bml = 0;
        targetCup.Gml = 0;
        targetCup.Mml = 0;
        targetCup.iceAmount = 0;
        targetCup.sugarAmount = 0;
        targetCup.teaID = 0;
        targetCup.isSealed = 0;
        targetCup.haveBoba = 0;
        targetCup.haveMilk = 0;
        Destroy(targetCup.gameObject);
        emote.emote.SetActive(false);
        emote.emote2.SetActive(false);
        emote.emote3.SetActive(false);


        nb.newM = 0;



        Invoke("UIGone", 5f);
        Invoke("CustomerAppear", 5f);
        come.Leave();

    }
    public void UIGone()
    {
        for (i = 0; i < 10; i++)
        {
            stars[i].SetActive(false);
        }
        orderTextObj.SetActive(false);
        scoreTextObj.SetActive(false);

    }


}
