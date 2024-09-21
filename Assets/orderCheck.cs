using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderCheck : MonoBehaviour
{
    servingDetect sDetect;
    cupStats cStat;
    public Text teaType;
    public Text sugarType;
    public Text iceType;
    public Text montxt;
    public Text ratingText;
    public GameObject moneyAnim;
    public AudioSource cashOut;
    public int[] prices;
    public string[] teas;
    public string[] sugars;
    public string[] ices;
  

    public int totalPrice;
    DrinkID drinkCS;
    public int score;
    public GameObject ratingObj;
    public GameObject[] stars;
    public int starNum;

    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        sDetect = GameObject.Find("serving").GetComponent<servingDetect>();
        teaType = GameObject.Find("teaType").GetComponent<Text>();
        iceType = GameObject.Find("iceType").GetComponent<Text>();
        sugarType = GameObject.Find("sugarType").GetComponent<Text>();
        drinkCS = FindObjectOfType<DrinkID>();
        ratingText = ratingObj.GetComponent<Text>();
        ratingObj.SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            stars[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckDrink()
    {
        cStat = sDetect.currentCup.GetComponent<cupStats>();
        if (sDetect.oStat.teaID == cStat.teaID)
        {
            if (sDetect.oStat.teaID <= 3)
            {

                if (cStat.Bml + cStat.Gml + cStat.Mml >= 250)
                {
                    totalPrice = prices[sDetect.oStat.teaID];
                    cashOut.Play();
                    MoneyAnim();
                }
            }
            else
            {
                if (cStat.Bml + cStat.Gml + cStat.Mml >= 100)
                {
                    totalPrice = prices[sDetect.oStat.teaID];
                    cashOut.Play();
                    MoneyAnim();
                }
            }

        }


        Rate();


        Destroy(sDetect.currentPaper);
        Destroy(sDetect.currentCup);
    }
    void MoneyAnim()
    {
        montxt = moneyAnim.GetComponent<Text>();
        montxt.text = "+ " +  totalPrice + " $";
        moneyAnim.SetActive(true);
        Invoke("HideMoney", 1f);
    }
    public void HideMoney()
    {
        moneyAnim.SetActive(false);
        drinkCS.bank += totalPrice;
        drinkCS.credit += score;

        totalPrice = 0;

    }
    public void HideRating()
    {
        ratingObj.SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            stars[i].SetActive(false);
        }
    }
    public void Rate()
    {
        ratingObj.SetActive(true);
        score = 0;
        if(sDetect.oStat.teaID == cStat.teaID)
        {
            score += 30;
        }
        else
        {
            score -= 30;
        }
        if(sDetect.oStat.iceAmount == cStat.iceAmount)
        {
            score += 20;
        }
        else
        {
            score -= 20;
        }
        if (sDetect.oStat.sugarAmount == cStat.sugarAmount)
        {
            score += 20;
        }
        else
        {
            score -= 20;
        }
        if(sDetect.oStat.haveBoba == cStat.haveBoba)
        {
            score += 10;
        }
        else
        {
            score -= 10;
        }
        if(cStat.shakes > 10)
        {
            score += 10;
        }
        else
        {
            score -= 10;
        }
        ratingText.text = "Rating: " + score;
        starNum = (score + 100) / 20;
        for(int i = 0; i < Mathf.Round(starNum); i++)
        {
            stars[i].SetActive(true);
        }
        Invoke("HideRating", 3f);
    }

}
