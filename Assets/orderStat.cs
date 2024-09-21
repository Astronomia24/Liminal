using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderStat : MonoBehaviour
{
    public int teaID;
    public int iceAmount;
    public int sugarAmount;
    public int haveBoba;
    public GameObject owner;
    PickUpClass pick;
    orderCheck oCheck;
    quener q;
    DrinkID drinkCS;
    customerManager cManager;


    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        pick = FindObjectOfType<PickUpClass>();
        oCheck = GameObject.Find("checker").GetComponent<orderCheck>();
        cManager = FindObjectOfType<customerManager>();
        oCheck.teaType.gameObject.SetActive(false);
        oCheck.iceType.gameObject.SetActive(false);
        oCheck.sugarType.gameObject.SetActive(false);
        if (gameObject.name == "orderPaper(Clone)")
        {
            q = owner.GetComponent<quener>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pick.currentObj == gameObject)
        {
            oCheck.teaType.gameObject.SetActive(true);
            oCheck.iceType.gameObject.SetActive(true);
            oCheck.sugarType.gameObject.SetActive(true);
            if(drinkCS.lanID == 0)
            {
                if (haveBoba == 1)
                {
                    oCheck.teaType.text = "珍珠" + cManager.teaString[teaID];
                }
                else
                {
                    oCheck.teaType.text = cManager.teaString[teaID];

                }
                oCheck.iceType.text = cManager.iceString[iceAmount];
                oCheck.sugarType.text = cManager.sugarString[sugarAmount];
            }
            if (drinkCS.lanID == 1)
            {
                if (haveBoba == 1)
                {
                    oCheck.teaType.text = "Boba " + cManager.teaString1[teaID];
                }
                else
                {
                    oCheck.teaType.text = cManager.teaString1[teaID];

                }
                oCheck.iceType.text = cManager.iceString1[iceAmount];
                oCheck.sugarType.text = cManager.sugarString1[sugarAmount];
            }
            if (drinkCS.lanID == 2)
            {
                if (haveBoba == 1)
                {
                    oCheck.teaType.text = "タピオカ" + cManager.teaString2[teaID];
                }
                else
                {
                    oCheck.teaType.text = cManager.teaString2[teaID];

                }
                oCheck.iceType.text = cManager.iceString2[iceAmount];
                oCheck.sugarType.text = cManager.sugarString2[sugarAmount];
            }
            if (drinkCS.lanID == 3)
            {
                if (haveBoba == 1)
                {
                    oCheck.teaType.text = "珍珠" + cManager.teaString3[teaID];
                }
                else
                {
                    oCheck.teaType.text = cManager.teaString3[teaID];

                }
                oCheck.iceType.text = cManager.iceString3[iceAmount];
                oCheck.sugarType.text = cManager.sugarString3[sugarAmount];
            }
            if (drinkCS.lanID == 4)
            {
                if (haveBoba == 1)
                {
                    oCheck.teaType.text = "Perlen-" + cManager.teaString4[teaID];
                }
                else
                {
                    oCheck.teaType.text = cManager.teaString4[teaID];

                }
                oCheck.iceType.text = cManager.iceString4[iceAmount];
                oCheck.sugarType.text = cManager.sugarString4[sugarAmount];
            }

            //if (haveBoba == 1)
            {
               // oCheck.teaType.text = "type: " + "Boba " + oCheck.teas[teaID];
            }
            //else
            {
                //oCheck.teaType.text = "type: " + oCheck.teas[teaID];

            }
            //oCheck.iceType.text = "ice: " + oCheck.ices[iceAmount];
            //oCheck.sugarType.text = "sugar: " + oCheck.sugars[sugarAmount];



        }
        if(q!= null && q.timeLeft <= 0)
        {
            Destroy(gameObject);
        }



    }
}
