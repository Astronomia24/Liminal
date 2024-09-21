using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pedestrian : MonoBehaviour
{
    public GameObject convotext;
    public int conum;
    public Text convot;
    PickUpClass pick;
    DrinkID drinkCS;
    flyer fly;
    public int isFlyer;
    public int isPackage;
    public GameObject testFlyer;
    public AudioSource src;
    public AudioClip sfx2;
    public int i;
    sideQuest sd;


    // Start is called before the first frame update
    void Start()
    {
        conum = 1;
        convotext.SetActive(false);
        drinkCS = FindObjectOfType<DrinkID>();
        fly = FindObjectOfType<flyer>();
        pick = FindObjectOfType<PickUpClass>();
        sd = FindObjectOfType<sideQuest>();
        isFlyer = 0;
        isPackage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pick.colliderName == "flyer")
        {
            isFlyer = 1;
        }
        else
        {
            isFlyer = 0;
        }

        if (pick.colliderName == "package")
        {
            isPackage = 1;
        }
        else
        {
            isPackage = 0;
        }
        if (conum == 1)
        {
            convot.text = "您好。";
        }
        if (conum == 2)
        {
            convot.text = "怎麼了嗎?";
        }
        if (conum == 3)
        {
            convot.text = "我在找飲料喝。";
        }
        if (conum == 4)
        {
            convot.text = "請問你是...?";
        }
        if (conum == 5)
        {
            convot.text = "哪一家比較好喝呢。";
        }
        if (conum == 6)
        {
            convot.text = "sup, my man.";
        }
        if(conum == 7)
        {
            convot.text = "A new store?";


            testFlyer.SetActive(false); 
            
        }
        if(conum == 8)
        {
            convot.text = "The sign belongs to a shop owner who made a bad investment.";
        }
        if(conum == 9)
        {
            convot.text = "Thanks!";
            sd.package.SetActive(false);
            sd.isDelivered = 1;
        }
    }
    public void Conversations()
    {
        StopCoroutine(Conv());
        if (isFlyer == 0 && isPackage == 0)
        {
            conum = Random.Range(1, 6);

            StartCoroutine(Conv());


        }
        if(isFlyer == 1)
        {
            conum = 7;
            StartCoroutine(Conv());
        }



    }
    IEnumerator Conv()
    {

        convotext.SetActive(true);
        for (i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            src.clip = sfx2;
            src.Play();


        }
        yield return new WaitForSeconds(1f);

        convotext.SetActive(false);
        if(conum == 7)
        {
            drinkCS.credit += 10;
            conum = 0;
        }
    }
    public void Owner()
    {
        if (isPackage == 1)
        {
            conum = 9;
            StartCoroutine(OwnerConvo());

        }
        else
        {
           Conversations();
        }


    }
    IEnumerator OwnerConvo()
    {
        convotext.SetActive(true);

        yield return new WaitForSeconds(3);
        convotext.SetActive(false);
    }
}
