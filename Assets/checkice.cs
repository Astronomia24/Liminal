using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class checkice : MonoBehaviour
{
    PickUpClass pick;
    public GameObject destroyice;
    DrinkID drinkCS;
    public GameObject iceObj;
    public AudioSource src;
    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioClip sfx3;
    public AudioClip sfx4;
    public AudioClip sfx5;
    public GameObject milky;
    public GameObject sugartrigger;
    public GameObject light1;
    public GameObject light2;
    public int isOn;
    shakerTrigger st;
    nBtea nb;
    sugarScript ss;
    strawscript straw;
    public GameObject watersplash;
    opengate og;
    opengate2 og2;
    godtone gd;
    BOBAflip bf;
    sealerController sc;
    public GameObject bobaStraw;
    public Rigidbody rb;
    public GameObject bigbb;
    public Transform hand;
    public AudioClip pop;
    public AudioClip hose;
    businessController bc;
    public cook ck;
    public bucketTrigger bTrigger;
    public checkTrigger cTrigger;
    public GameObject icep;
    public GameObject ssplash;
    tutorControl tut;
    coverControl cc;
    public bool business;
    public GameObject endCanvas;
    conclude con;
    customerManager com;
    public GameObject lbutt;
    public GameObject dbutt;
    public GameObject faucet1;
    public GameObject faucet2;
    public bool f1;
    public bool f2;
    comeScript cu;
    dayNightController daynight;
    facuetrigger fct;
    nLaptop nl;
    pressAnim press;
    public GameObject cup;
    public Transform spawnPos;
    public GameObject[] customers;
    quener q;
    boxStat bStat;
    stainList sList;
    public GameObject currentStain;
    public GameObject block;
    spoonStat spStat;

    sleep sle;

    public void HidBlock()
    {
        block.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        lbutt.SetActive(false);
        dbutt.SetActive(true);
        endCanvas.SetActive(false);
        business = false;
        pick = FindObjectOfType<PickUpClass>();
        drinkCS = FindObjectOfType<DrinkID>();

        st = FindObjectOfType<shakerTrigger>();
        nb = FindObjectOfType<nBtea>();
        ss = FindObjectOfType<sugarScript>();
        straw = FindObjectOfType<strawscript>();
        StartCoroutine(CheckMelt());
        og = FindObjectOfType<opengate>();
        og2 = FindObjectOfType<opengate2>();
        gd = FindObjectOfType<godtone>();
        bf = FindObjectOfType<BOBAflip>();
        sc = FindObjectOfType<sealerController>();
        bc = FindObjectOfType<businessController>();
        ck = FindObjectOfType<cook>();
        bTrigger = FindObjectOfType<bucketTrigger>();
        cTrigger = FindObjectOfType<checkTrigger>();
        cc = FindObjectOfType<coverControl>();
        isOn = 0;
        light1.SetActive(false);
        light2.SetActive(false);
        tut = FindObjectOfType<tutorControl>();
        con = FindObjectOfType<conclude>();
        com = FindObjectOfType<customerManager>();
        sle = FindObjectOfType<sleep>();
        cu = FindObjectOfType<comeScript>();
        daynight = FindObjectOfType<dayNightController>();
        f1 = false;
        f2 = false;
        faucet1.SetActive(false);
        faucet2.SetActive(false);
        nl = FindObjectOfType<nLaptop>();
        press = FindObjectOfType<pressAnim>();
        bStat = FindObjectOfType<boxStat>();
        sList = FindObjectOfType<stainList>();
        spStat = FindObjectOfType<spoonStat>();



    }
    public void AddMilk()
    {
        Debug.Log("addedmilk");
        Destroy(destroyice);
        milky.SetActive(true);
        st.haveMilk = 1;
        st.src.clip = st.sfx3;
        st.src.Play();
        pick.colliderName = null;
    } 
    public void AddSugar()
    {
        destroyice = pick.currentObj;
        Debug.Log("addedsugar");
        Destroy(destroyice);
        ss.sugarTrigger.SetActive(true);
        nb.src.clip = nb.sfx;
        nb.src.Play();
        ss.sugarCount += 10;
        pick.colliderName = null;
    }
    public void AddMatcha()
    {
        destroyice = pick.currentObj;
        spStat.amounts[2] += 10;
        Debug.Log("addedmatcha");
        pick.powderSfx.Play();
        Destroy(destroyice);
        pick.colliderName = null;
    }
    public void AddBoba()
    {
        cTrigger.bobas2.SetActive(false);
        cTrigger.bobas.SetActive(false);
        cTrigger.haveBB = false;
        cTrigger.cookBB = false;

        Debug.Log("addedbbr");

        bf.bobaTrigger.SetActive(true);
        bf.trig = 1;
        bf.bbAmount += 10;
    }

    public void AddIce()
    {
        destroyice = pick.currentObj;
        Debug.Log("added");
        Destroy(destroyice);
        drinkCS.newIceAmount += 200;
        iceObj.SetActive(true);
        src.clip = sfx1;
        src.Play();
    }
    // Update is called once per frame
    public void Black()
    {
        if (cTrigger.bTea == true && ck.cookTimer == 100 && cTrigger.mTea != true && ck.isBurn == false)
        {
            src.clip = sfx5;
            src.Play();
            drinkCS.bTeaLeft += bTrigger.ml;
            bTrigger.updatePos = bTrigger.startPos;
            bTrigger.Water.SetActive(false);
            bTrigger.ml = 0;
            bTrigger.Reset();
            if (tut.step <= 13)
            {
                tut.step = 14;
            }

        }
    }
    public void Green()
    {
        if (cTrigger.gTea == true && ck.cookTimer == 100 && cTrigger.mTea != true && ck.isBurn == false)
        {
            src.clip = sfx5;
            src.Play();
            bTrigger.updatePos = bTrigger.startPos;
            bTrigger.Water.SetActive(false);
            drinkCS.gTeaLeft += bTrigger.ml;
            bTrigger.ml = 0;
            bTrigger.Reset();
            if (tut.step <= 13)
            {
                tut.step = 14;
            }
        }
    }
    public void Milk()
    {
        if (cTrigger.mTea == true && ck.cookTimer == 100 && cTrigger.bTea == true && ck.isBurn == false)
        {

            src.clip = sfx5;
            src.Play();
            bTrigger.updatePos = bTrigger.startPos;
            bTrigger.Water.SetActive(false);
            drinkCS.mTeaLeft += bTrigger.ml;
            bTrigger.ml = 0;
            bTrigger.Reset();
            if (tut.step <= 13)
            {
                tut.step = 14;
            }
        }
    }
    IEnumerator CheckMelt()
    {
        while (true)
        {
            yield return new WaitForSeconds(40);
            if(GameObject.Find("icepile(Clone)") == true)
            {
                destroyice = GameObject.Find("icepile(Clone)");
                currentStain = Instantiate(watersplash, destroyice.transform.position, Quaternion.identity);
                sList.stains.Add(currentStain);
                Destroy(destroyice);
                
            }
        }
    }
    public void SetFalse()
    {
        press.isPress = false;
        Invoke("endFalse", 3f);
    }
    public void endFalse()
    {
        endCanvas.SetActive(false);
    }
    IEnumerator LightOn()
    {

        yield return new WaitForSeconds(2f);
        src.clip = sfx2;
        src.Play();
        light1.SetActive(true);
        yield return new WaitForSeconds(1f);
        src.clip = sfx2;
        src.Play();
        light2.SetActive(true);
    }
    void Update()
    {




        if(pick.colliderName == "teaBucket")
        {
            ck.isCooking = false;

        }




        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;





            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if(hit.transform.name == "bed" && nl.isPause == false)
                {
                    if (drinkCS.hour >= 18 || drinkCS.hour < 6)
                    {
                        if(drinkCS.hour >= 18 && drinkCS.hour <= 24)
                        {
                            sle.Invoke("StartSleep", 0.1f);
                            drinkCS.day += 1;
                            drinkCS.dayText.text = "Day" + " " + drinkCS.day;
                            daynight.timeOfDay = 6f;
                            drinkCS.hour = 6;
                            drinkCS.minute = 0;
                            StartCoroutine(drinkCS.StartDay());
                            drinkCS.customerAppear = 2;
                        }
                        else
                        {
                            sle.Invoke("StartSleep", 0.1f);
                            drinkCS.dayText.text = "Day" + " " + drinkCS.day;
                            daynight.timeOfDay = 6f;
                            drinkCS.hour = 6;
                            drinkCS.minute = 0;
                            StartCoroutine(drinkCS.StartDay());
                            drinkCS.customerAppear = 2;
                        }

                    }
                }
                if (hit.transform.name == "v1")
                {
                    src.clip = hose;
                    src.Play();
                    if (f1 == false)
                    {
                        faucet1.SetActive(true);
                        f1 = true;

                    }
                    else
                    {
                        fct = FindObjectOfType<facuetrigger>();
                        fct.Stop();
                        faucet1.SetActive(false);
                        f1 = false;
                    }
                }
                if (hit.transform.name == "v2")
                {
                    src.clip = hose;
                    src.Play();
                    if (f2 == false)
                    {

                        faucet2.SetActive(true);
                        f2 = true;

                    }
                    else
                    {
                        fct = FindObjectOfType<facuetrigger>();
                        fct.Stop();
                        faucet2.SetActive(false);
                        f2 = false;
                    }
                }



                if (hit.transform.name == "businessmanm")
                {
                    if (bc.started == 0)
                    {
                        bc.StartBusiness();
                    }
                }
                if(hit.transform.name == "cupps")
                {
                    cup = GameObject.Find("cup");
                    Instantiate(cup, spawnPos.position, cup.transform.rotation);

                }
                if(hit.transform.name == "clerk" && bStat.started == false)
                {
                    bStat.Transfering = true;

                }
                if (hit.transform.name == "gate" && nl.isPause == false)
                {
                    press.isPress = true;

                    Invoke("SetFalse", 0.25f);
                    Invoke("HideBlock", 2f);
                    if (og.isOpen == 1)
                    {
                        press.isPress = true;
                        Invoke("SetFalse", 0.25f);
                        src.clip = sfx4;
                        src.Play();
                        og.src.clip = og.sfx;
                        og.src.Play();
                        business = false;
                        og.isOpen = 0; 
                        endCanvas.SetActive(true);

                        drinkCS.money += drinkCS.bank;
                        if(drinkCS.lanID == 0)
                        {
                            con.endText.text = "營收: " + drinkCS.bank + "$";
                        }
                        if (drinkCS.lanID == 1)
                        {
                            con.endText.text = "revenue: " + drinkCS.bank + "$";
                        }
                        if (drinkCS.lanID == 2)
                        {
                            con.endText.text = "売上: " + drinkCS.bank + "円";
                        }
                        if (drinkCS.lanID == 3)
                        {
                            con.endText.text = "收入: " + drinkCS.bank + "$";
                        }
                        endCanvas.SetActive(true);
                        drinkCS.bank = 0;
                        drinkCS.bankText.text = drinkCS.bank + " $";
                        con.closetxt.SetActive(true);
                        con.opentxt.SetActive(false);

                        con.end++;
                        con.OK();
                    }
                    else if (og.isOpen == 0)
                    {

                        press.isPress = true;
                        Invoke("HideBlock", 2f);
                        Invoke("SetFalse", 0.25f);
                        press.isPress = true;
                        Invoke("SetFalse", 0.25f);
                        src.clip = sfx4;
                        src.Play();
                        con.closetxt.SetActive(false);
                        con.opentxt.SetActive(true);
                        og.src.clip = og.sfx;
                        og.src.Play();
                        business = true;
                        og.isOpen = 1;
                        if (con.end == drinkCS.day)
                        {
                            //press.isPress = true;
                            //Invoke("SetFalse", 0.25f);
                            //src.clip = sfx4;
                            //src.Play();
                            //con.closetxt.SetActive(false);
                            //con.opentxt.SetActive(true);
                            //og.src.clip = og.sfx;
                            //og.src.Play();
                            //business = true;
                            //og.isOpen = 1;
                        }
                        else
                        {
                            //src.clip = sfx4;
                            //src.Play();
                            //endCanvas.SetActive(true);
                            //press.isPress = true;
                            //Invoke("SetFalse", 0.25f);
                            if (drinkCS.lanID == 0)
                            {
                                //con.endText.text = "一天只能進行一次開店!";

                            }
                            if (drinkCS.lanID == 1)
                            {
                                //con.endText.text = "You can only open the shop once a day!";

                            }
                           //con.OK();

                        }

                    }
                }
                if (hit.transform.name == "gate (1)")
                {
                    src.clip = sfx4;
                    src.Play();
                    press.isPress = true;
                    Invoke("SetFalse", 0.25f);
                    if (tut.step == 0)
                    {
                        tut.step = 1;
                    }
                    og2.src.clip = og2.sfx;
                    og2.src.Play();
                    if (og2.isOpen == 1)
                    {
                        og2.isOpen = 0;

                    }
                    else if (og2.isOpen == 0)
                    {
                        og2.isOpen = 1;
                    }
                    if (isOn == 0)
                    {

                        StartCoroutine(LightOn());
                        isOn = 1;
                    }
                }
                if (hit.transform.name == "cookButton")
                {
                    Debug.Log("ck");
                    if(ck.isCooking == false)
                    {
                        src.clip = sfx4;
                        src.Play();
                        ck.StartCook();
                        dbutt.SetActive(false);
                        lbutt.SetActive(true);
                    }
                    else
                    {
                        src.clip = sfx4;
                        src.Play();
                        ck.isCooking = false;
                        dbutt.SetActive(true);
                        lbutt.SetActive(false);
                    }

                }
                if (hit.transform.name == "cover")
                {
                    src.clip = sfx3;
                    src.Play();
                    Debug.Log("cov");
                    if(cc.open == false)
                    {
                        cc.open = true;
                    }
                    else if (cc.open == true)
                    {
                        cc.open = false;
                    }
                }



            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pick.colliderName == "bobaStraw(Clone)")
            {
                Instantiate(bigbb, hand.position, Quaternion.identity);
                destroyice = GameObject.Find("bigbb(Clone)");
                rb = destroyice.GetComponent<Rigidbody>();
                rb.AddForce(hand.forward * 10f, ForceMode.Impulse);
                destroyice.name = "used";
                src.clip = pop;
                src.Play();

            }
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.name == "ice")
                {

                    if (pick.colliderName == "nbag(Clone)")
                    {


                    }
                }
                if (hit.transform.name == "nCup")
                {
                    if (pick.colliderName == "nbag(Clone)")
                    {
                        destroyice = GameObject.Find("nbag(Clone)");
                        Instantiate(icep, hit.transform.position, Quaternion.identity);
                        Instantiate(icep, hit.transform.position, Quaternion.identity);
                        Instantiate(icep, hit.transform.position, Quaternion.identity);
                        Instantiate(icep, hit.transform.position, Quaternion.identity);
                        Destroy(destroyice);

                        src.clip = sfx1;
                        src.Play();

                    }
                }
                if (hit.transform.name == "shaker")
                {
                    if (pick.colliderName == "nbag(Clone)")
                    {
                        destroyice = GameObject.Find("nbag(Clone)");
                        Instantiate(icep, hit.transform.position, Quaternion.identity);
                        Instantiate(icep, hit.transform.position, Quaternion.identity);
                        Instantiate(icep, hit.transform.position, Quaternion.identity);
                        Instantiate(icep, hit.transform.position, Quaternion.identity);
                        Destroy(destroyice);

                        src.clip = sfx1;
                        src.Play();

                    }
                }


                if(hit.transform.name == "BlackTea")
                {

                    if (pick.colliderName == "teaBucket")
                    {

                    }

                }
                if (hit.transform.name == "GreenTea")
                {

                    if (pick.colliderName == "teaBucket")
                    {

                    }


                }
                if (hit.transform.name == "MilkTea")
                {

                    if (pick.colliderName == "teaBucket")
                    {

                    }

                }
                if(hit.transform.name == "Sealer")
                {
                    if (pick.colliderName == "nCup")
                    {

                        sc.StartSealing();
                    }
                }
                if (hit.transform.name == "bobaCup")
                {
                    if (pick.colliderName == "straw(Clone)")
                    {
                        destroyice = GameObject.Find("straw(Clone)");
                        Instantiate(bobaStraw, destroyice.transform.position, Quaternion.identity);
                        Destroy(destroyice);

     


                    }
                }







                if (hit.transform.name == "shaker")
                {
                    if (pick.colliderName == "milk(Clone)")
                    {




                    }
                }
                if (hit.transform.name == "nCup")
                {
                    if (pick.colliderName == "milk(Clone)")
                    {
 


                    }
                }
                if (hit.transform.name == "sugarCup")
                {
                    if (pick.colliderName == "sugarefill(Clone)")
                    {


                    }
                }
                if (hit.transform.name == "nCup")
                {
                    if (pick.colliderName == "sugarefill(Clone)")
                    {



                    }
                }
                if (hit.transform.name == "shaker")
                {
                    if (pick.colliderName == "sugarefill(Clone)")
                    {



                    }
                }

                if (hit.transform.name == "bobaCup")
                {
                    if (pick.colliderName == "bobabag(Clone)")
                    {




                    }
                }
                if (hit.transform.name == "strawcan")
                {
                    straw.GetStraw();
                }
                if (hit.transform.name == "shaker")
                {
                    if (pick.colliderName == "icepile(Clone)")
                    {
                        destroyice = GameObject.Find("icepile(Clone)");
                        Destroy(destroyice);
                        st.sIceAmount += 1;


                    }
                }
                if (hit.transform.name == "nCup")
                {
                    if (pick.colliderName == "icepile(Clone)")
                    {
                        destroyice = GameObject.Find("icepile(Clone)");
                        Destroy(destroyice);
                        nb.iceAmount += 1;


                    }
                }

                if(hit.transform.name == "newgoooddddd")
                {
                    gd.ad.Play();
                    if(gd.isD == 0)
                    {
                        gd.isD = 1;
                    }
                    else if(gd.isD == 1)
                    {
                        gd.isD = 0;
                    }

                }



            }
        }
    }
}
