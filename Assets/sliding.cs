using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliding : MonoBehaviour
{
    public GameObject sliderObj;
    public Slider slider;
    public float fill;
    shakerTrigger scs;
    nBtea nb;
    PickUpClass pick;
    checkice ck;
    public bool isShaker;
    public bool isCup;
    public bool cd;
    tutorControl tut;
    checkTrigger cTrigger;
    cupSpawning cs;
    ragAnim ranim;
    scoopAnim sanim;
    aniSpoon suanim;
    stirAnim stiranim;
    Controller player;
    newIce ics;
    sCupTrigger sct;
    bobaTrigger bbt;
    sugarScript ss;
    BOBAflip bf;
    sugarFlip sf;
    CupTrigger ccs;
    objControl obj;
    public GameObject styro;
    public GameObject iceP;
    public newIce nice;
    TutorialManager tManager;
    spoonStat spStat;

       
    // Start is called before the first frame update
    void Start()
    {
        sliderObj.SetActive(false);
        fill = 0f;
        scs = FindObjectOfType<shakerTrigger>();
        nb = FindObjectOfType<nBtea>();
        pick = FindObjectOfType<PickUpClass>();
        ck = FindObjectOfType<checkice>();
        tut = FindObjectOfType<tutorControl>();
        cTrigger = FindObjectOfType<checkTrigger>();
        cs = FindObjectOfType<cupSpawning>();
        ranim = FindObjectOfType<ragAnim>();
        player = FindObjectOfType<Controller>();
        sanim = FindObjectOfType<scoopAnim>();
        suanim = FindObjectOfType<aniSpoon>();
        ics = FindObjectOfType<newIce>();
        sct = FindObjectOfType<sCupTrigger>();
        bbt = FindObjectOfType<bobaTrigger>();
        ss = FindObjectOfType<sugarScript>();
        bf = FindObjectOfType<BOBAflip>();
        sf = FindObjectOfType<sugarFlip>();
        ccs = FindObjectOfType<CupTrigger>();
        obj = FindObjectOfType<objControl>();
        nice = FindObjectOfType<newIce>();
        tManager = FindObjectOfType<TutorialManager>();
        spStat = FindObjectOfType<spoonStat>();
        stiranim = FindObjectOfType<stirAnim>();

    }

    // Update is called once per frame
    void Update()
    {
        if(pick.colliderName != "scooper (1)")
        {
            sanim.isScoop = false;
        }
        if(pick.colliderName != "spoon")
        {
            suanim.isSpoon = false;

        }
        slider.value = fill;
        if(slider.value == 1f)
        {
            if (pick.colliderName == "stir")
            {
                if(scs.amount[2] > 0 && scs.haveMilk == 1)
                {
                    scs.stirred = true;
                    if (scs.haveMilk == 1 && scs.stirred == true)
                    {
                        if (scs.haveMilk == 1 && scs.amount[2] > 0)
                        {
                            scs.isMilk = 1;
                            scs.teaID = 7;
                            scs.amount[2] = 0;
                            scs.obj[2].SetActive(false);
                            scs.sc.milkRend.material.SetColor("_liquidColor", scs.sc.color9);
                            scs.sc.milkRend.material.SetColor("_surfaceColor", scs.sc.scolor9);
                        }
                    }
                }
                fill = 0;

            }

            if (pick.colliderName == "rag")
            {
                Destroy(pick.targetStain);
                tManager.stainCount += 1;
                player.walkSpeed = 5;
                fill = 0;
            }
            if (pick.colliderName == "shaker" )
            {
                nb.newM = scs.newML;

                scs.Transfer();

                slider.value = 0;
                if(tut.step == 6)
                {
                    tut.step = 7;
                }
                fill = 0;

            }
            if(pick.colliderName == "scooper (1)")
            {
                if(nice.isIce == false)
                {
                    scs.AddIce();
                    sanim.played = false;
                    fill = 0;
                }
                else if(nice.isIce == true)
                {
                    if(nice.drinkCS.newIceAmount > 0 && nice.cc.open == true && nice.haveIce == 0)
                    {
                        sanim.played = false;
                        nice.Scoop();
                        fill = 0;
                    }
                }


            }
            if(pick.colliderName == "spoon")
            {
                for (int i = 0; i < spStat.stats.Length; i++)
                {
                    if(spStat.current[i] == true)
                    {
                        if(spStat.amounts[i] > 0)
                        {
                            spStat.amounts[i] -= 1;
                            spStat.stats[i] = true;
                            spStat.current[i] = false;
                            spStat.objs[i].SetActive(true);
                        }

                    }
                }
                if(isShaker == true)
                {
                    scs.AddSugar();
                    scs.AddBoba();
                    suanim.played = false;
                    suanim.isSpoon = false;
                    slider.value = 0;
                    fill = 0;
                    for (int i = 0; i < spStat.stats.Length; i++)
                    {
                        {
                            if(spStat.stats[i] == true)
                            {
                                spStat.stats[i] = false;
                                spStat.objs[i].SetActive(false);
                                scs.amount[i] += 1;
                            }
                            if(scs.amount[i] > 0)
                            {
                                scs.obj[i].SetActive(true);
                            }
                        }
                    }

                }
                if(isCup == true)
                {
                    ccs.AddSugar();
                    ccs.AddBoba();
                    suanim.played = false;
                    suanim.isSpoon = false;
                    slider.value = 0;
                    fill = 0;
                }
            }

            if (pick.colliderName == "milk(Clone)")
            {
                if(isShaker == true)
                {
                    ck.AddMilk();
                    pick.colliderName = null;

                }
                if(isCup == true)
                {
                    nb.haveCupMilk = 1;
                    nb.cupMilk.SetActive(true);
                    scs.src.clip = scs.sfx3;
                    scs.src.Play();
                    ck.destroyice = GameObject.Find("milk(Clone)");
                    Debug.Log("addedmilk");
                    Destroy(ck.destroyice);
                    slider.value = 0;
                    pick.colliderName = null;
                }
            }
            if(pick.colliderName == "matchaBag(Clone)")
            {
                ck.AddMatcha();
                slider.value = 0;
                pick.colliderName = null;
            }
            if(pick.colliderName == "sugarefill(Clone)")
            {
                ck.AddSugar();
                slider.value = 0;
                pick.colliderName = null;
            }
            if (pick.colliderName == "teaBucket" && cTrigger.cookBB ==true && cTrigger.haveBB == true) 
            {
                ck.AddBoba();
                slider.value = 0;
                
            }
            if (pick.colliderName == "nbag(Clone)")
            {
                ck.AddIce();
                if (slider.value > 0)
                {
                    Instantiate(styro, pick.startRot.position, Quaternion.identity);
                    Instantiate(iceP, pick.startRot.position, Quaternion.identity);
                }
                slider.value = 0;
                pick.colliderName = null;
            }
            if (pick.colliderName == "teaBucket" && cTrigger.cookBB == false && cTrigger.haveBB == false)
            {
                if(pick.teatype == "milk")
                {
                    pick.colliderName = null;
                    ck.Milk();
                    pick.bucketPour = false;
                    slider.value = 0;


                }
                if (pick.teatype == "green")
                {
                    pick.colliderName = null;
                    ck.Green();
                    pick.bucketPour = false;
                    slider.value = 0;


                }
                if (pick.teatype == "black")
                {
                    pick.colliderName = null;
                    ck.Black();
                    pick.bucketPour = false;
                    slider.value = 0;


                }



            }





        }

        RaycastHit hit;
        Ray PickUpray2 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(PickUpray2, out hit,2f))
        {
            if(hit.transform.name == "nCup")
            {

            }
            if(hit.transform.name != "cup" && Input.GetMouseButtonUp(0) == true)
            {
                
                cd = false;
            }
            if (hit.transform.name == "shaker")
            {
                if (pick.colliderName == "scooper (1)")
                {
                    sliderObj.SetActive(true);
                    if (Input.GetKey(KeyCode.E) && ics.haveIce == 1)
                    {
                        sanim.isScoop = true;
                    }
                    else
                    {
                        sanim.isScoop = false;
                    }

                }
                if(pick.colliderName == "spoon")
                {
                    sliderObj.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        if(scs.haveSugar == 1 || scs.haveBoba == 1 || ccs.haveBoba == 1 || ccs.haveSugar == 1 || spStat.stats[2] == true)
                        suanim.isSpoon = true;
                    }
                    else
                    {
                        suanim.isSpoon = false;
                    }
                }
                if(pick.colliderName == "stir")
                {
                    sliderObj.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                            stiranim.isStir = true;
                    }
                    else
                    {
                        stiranim.isStir = false;
                    }
                }
                else
                {
                    stiranim.isStir = false;
                }
            }
            if(hit.transform.name == "sugarCup")
            {
                if(pick.colliderName == "spoon")
                {
                    sliderObj.SetActive(true);

                    if(slider.value == 1 && sct.scs.haveSugar == 0 && ss.sugarCount > 0)
                    {
                        if (Mathf.Abs(sf.RotationX)< 90 && Mathf.Abs(sf.RotationZ)<90)
                        {
                            sct.FillSugar();
                            slider.value = 0;
                            fill = 0;
                        }
                    }
                    if (Input.GetKey(KeyCode.E) && sct.scs.haveSugar == 0 && ss.sugarCount > 0)
                    {
                        if(Mathf.Abs(sf.RotationX) < 90 && Mathf.Abs(sf.RotationZ) < 90)
                        {
                            suanim.isSpoon = true;

                        }
                    }
                    else
                    {
                        suanim.isSpoon = false;
                    }
                }
            }


            if (hit.transform.name == "nCup")
            {
                isCup = true;
                if (pick.colliderName == "shaker")
                {
                    sliderObj.SetActive(true);
                }
                if (pick.colliderName == "spoon")
                {
                    sliderObj.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        if (scs.haveSugar == 1 || scs.haveBoba == 1 || ccs.haveBoba == 1 || ccs.haveSugar == 1)
                            suanim.isSpoon = true;
                    }
                    else
                    {
                        suanim.isSpoon = false;
                    }
                }


            }

            else if (hit.transform.name == "cup(Clone)")
            {
                if (pick.colliderName == "shaker")
                {
                    isCup = true;
                    sliderObj.SetActive(true);
                }
            }
            else if (hit.transform.name == "shaker")
            {
                isShaker = true;


            }
            else if (hit.transform.name == "ice")
            {
                isShaker = false;
                isCup = false;
                if (pick.colliderName == "scooper (1)")
                {
                    sliderObj.SetActive(true);
                    if (Input.GetKey(KeyCode.E) && ics.haveIce == 0)
                    {
                        sanim.isScoop = true;
                    }
                    else
                    {
                        sanim.isScoop = false;
                    }
                }
                if (pick.colliderName == "nbag(Clone)")
                {
                    sliderObj.SetActive(true);

                }
            }
            else if (hit.transform.name == "sugarCup")
            {
                isShaker = false;
                isCup = false;
                if (pick.colliderName == "sugarefill(Clone)")
                {
                    sliderObj.SetActive(true);
                }
            }
            else if (hit.transform.name == "matchaCup")
            {
                isShaker = false;
                isCup = false;
                if (pick.colliderName == "spoon")
                {
                    sliderObj.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        if (spStat.current[2] == true)
                            suanim.isSpoon = true;
                    }
                    else
                    {
                        suanim.isSpoon = false;
                    }
                }
                if (pick.colliderName == "matchaBag(Clone)")
                {
                    sliderObj.SetActive(true);
                }
            }
            else if (hit.transform.name == "bobaCup")
            {
                isShaker = false;
                isCup = false;
                if (pick.colliderName == "teaBucket")
                {
                    sliderObj.SetActive(true);
                }
                if (pick.colliderName == "spoon")
                {
                    sliderObj.SetActive(true);
                    if (slider.value == 1 && sct.scs.haveBoba == 0)
                    {
                        if (Mathf.Abs(sf.RotationX) < 90 && Mathf.Abs(sf.RotationZ) < 90)
                        {
                            bbt.FillBoba();
                            slider.value = 0;
                            fill = 0;
                        }
                    }
                    if (Input.GetKey(KeyCode.E) && sct.scs.haveBoba == 0 && bf.bbAmount > 0)
                    {
                        if (Mathf.Abs(sf.RotationX) < 90 && Mathf.Abs(sf.RotationZ) < 90)
                        {
                            suanim.isSpoon = true;
                        }

                    }
                    else
                    {
                        suanim.isSpoon = false;
                    }
                }


            }
            else if (hit.transform.name == "ice")
            {
                isShaker = false;
                isCup = false;
                if (pick.colliderName == "nbag(Clone)")
                {
                    sliderObj.SetActive(true);
                    
                }
            }
            else if (hit.transform.name == "BlackTea" || hit.transform.name == "GreenTea" || hit.transform.name == "MilkTea")
            {
                if (pick.colliderName == "teaBucket")
                {
                    isShaker = false;
                    isCup = false;
                    sliderObj.SetActive(true);
                    pick.refillText.SetActive(true);

                }
            }
            else if(hit.transform.gameObject.tag == "stain")
            {
                if(pick.colliderName == "rag")
                {
                    sliderObj.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        ranim.isRubbing = true;
                    }
                    else
                    {
                        ranim.isRubbing = false;
                    }

                }
            }


            else
            {
                sliderObj.SetActive(false);
                isShaker = false;
                isCup = false;
                ranim.isRubbing = false;
                sanim.isScoop = false;
                stiranim.isStir = false;


            }
        }
    }
}
