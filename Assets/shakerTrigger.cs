using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shakerTrigger : MonoBehaviour
{
    public AudioSource src;
    public AudioSource src2;
    public AudioClip sfx;
    public AudioClip sfx2;
    public AudioClip sfx3;
    public AudioClip sfx4;
    public AudioClip sfx5;
    public AudioClip sfx6;
    newIce ics;
    public int sIceAmount;
    public int sSugarAmount;
    public GameObject scoopIce;
    CupTrigger cTrigger;
    public GameObject ice1;
    public GameObject ice2;
    public GameObject ice3;
    public GameObject ice4;
    public Transform cupTransform;
    public float RotationX;
    public float RotationZ;
    public int haveSugar;
    public int haveBoba;
    public int haveMilk;
    public int bb;
    public GameObject boba;
    public GameObject boba2;
    public GameObject boba3;
    PickUpClass pick;
    public GameObject shakerCup;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    Material teaMaterial;
    public GameObject teaa;
    public GameObject teaa2;
    public GameObject teaa3;
    public GameObject teaa4;
    public GameObject bubble1;
    public GameObject bubble2;
    public GameObject bubble3;
    public GameObject bubble4;
    public GameObject cupSugar;
    public GameObject sCanvas;
    public int Bml;
    public int Gml;
    public int Mml;
    public int milkML;
    DrinkID drinkCS;
    public Text bText;
    public Text gText;
    public Text mText;
    public Text iceText;
    public Text sugarText;
    public Text shakeText;
    public Text milkText;
    public nBtea nb;
    public int shake;
    public int shakable;
    public int teaID;
    public GameObject lid;
    public GameObject stainer;
    public GameObject gsplash;
    public GameObject msplash;
    public GameObject milkSplash;
    public GameObject wSplash;
    public int stained;
    checkice checky;
    public GameObject spoonSugar;
    public GameObject ice;
    public int isMilk;
    public GameObject floorBoba;
    public GameObject spoonBoba;
    public GameObject spawnPoint;
    public GameObject floorBoba2;
    public Transform teaHeight;
    public Vector3 teaaPos;
    public GameObject newTea;
    public float newML;
    public shaderControl sc;
    sliding slid;
    public int bobacount;
    cupSpawning cs;
    public int iceg;
    Rigidbody iceRB;
    public AudioClip[] sf;
    public AudioClip[] sh;
    public AudioClip[] sh2;
    public int ID;
    public Rigidbody shakerRB;
    public GameObject sht;
    public int waterML;
    facuetrigger ft;
    public bool isFill;
    public AudioClip sfx7;
    tutorControl tut;
    customerManager cm;
    public AudioSource sr3;
    public float mnml;
    public bool played;
    public int extra;
    public AudioClip sfx8;
    public GameObject currentCup;
    public cupStats cupstat;
    public orderStat oStat;
    public bool lidBool;
    public bool finished;
    public bool lidCD;
    public AudioSource closeLid;
    public bool transfered;
    stainList sList;
    public GameObject currentStain;
    public int[] amount;
    public GameObject[] obj;
    public GameObject[] stains;
    public GameObject matchaPart;
    public AudioSource powderSrc;
    public bool stirred;


    public void hidePart()
    {
        matchaPart.SetActive(false);
    }




    // Start is called before the first frame update
    void Start()
    {
        stirred = false;
        transfered = false;
        finished = true;
        lidBool = false;
        iceg = 0;
        newML = 0;
        extra = 0;
        mnml = 0;
        ics = FindObjectOfType<newIce>();
        sIceAmount = 0;
        cTrigger = FindObjectOfType<CupTrigger>();
        pick = FindObjectOfType<PickUpClass>();
        bb = 0;
        sIceAmount = 0;
        sSugarAmount = 0;
        boba.SetActive(false);
        teaMaterial = teaa.GetComponent<Renderer>().sharedMaterial;
        teaa.SetActive(false);
        sCanvas.SetActive(false);
        drinkCS = FindObjectOfType<DrinkID>();
        pick.isShaker = 0;
        nb = FindObjectOfType<nBtea>();
        checky = FindObjectOfType<checkice>();
        shake = 0;
        shakable = 0;
        teaID = 0;
        stained = 0;
        haveMilk = 0;
        isMilk = 0;
        sc = FindObjectOfType<shaderControl>();
        slid = FindObjectOfType<sliding>();
        bobacount = 0;
        cs = FindObjectOfType<cupSpawning>();
        ft = FindObjectOfType<facuetrigger>();
        waterML = 0;
        isFill = false;
        tut = FindObjectOfType<tutorControl>();
        cm = FindObjectOfType<customerManager>();
        played = false;
        sList = FindObjectOfType<stainList>();
        sc.milkRend.material.SetColor("_liquidColor", sc.color8);
        sc.milkRend.material.SetColor("_surfaceColor", sc.scolor8);




    }
    public void AddIce()
    {
        if (ics.haveIce == 1)
        {


            drinkCS.newIceAmount -= 10;
            ics.haveIce = 0;
            if (sIceAmount < 4)
            {
                iceg += 10;

            }
            else
            {
                sIceAmount = 4;
                Instantiate(ice, lid.transform.position, Quaternion.identity);
                src.clip = sfx6;
                src.Play();
            }
            cTrigger.StartCoroutine("pouring");
            pick.icePlayed = false;



        }
    }
    void lidFalse()
    {
        if (Input.GetKey(KeyCode.E) == false)
        {
            finished = true;
            shakerCup.SetActive(false);
            lidCD = false;
        }



    }


    // Update is called once per frame
    void Update()
    {
        if(pick.colliderName != "milk(Clone)")
        {
            played = false;
        }
        if(milkML > 0 && isMilk == 0)
        {
            checky.milky.SetActive(true);
        }
        if(milkML > 100)
        {
            haveMilk = 1;
        }


        if(Bml == 300 || Gml == 300|| Mml == 300)
        {
            if(tut.step == 3)
            {
                tut.step = 4;
                src.clip = sfx8;
                src.Play();
            }
        }
        if (oStat != null)
        {
            if (sIceAmount == oStat.iceAmount)
            {
                if (tut.step == 4)
                {
                    tut.step = 5;
                    src.clip = sfx8;
                    src.Play();
                }
            }
            if (sSugarAmount == oStat.sugarAmount)
            {
                if (tut.step == 5)
                {
                    tut.step = 6;
                    src.clip = sfx8;
                    src.Play();
                }
            }
        }
        if (pick.colliderName == "shaker")
        {
            sht.SetActive(true);
        }
        else
        {
            sht.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && pick.colliderName == "shaker"&& slid.isCup == false && lidCD == false && finished == true)
        {

            finished = false;
            lidBool = true;
            shakerCup.SetActive(true);
            closeLid = GameObject.Find("clidsrc").GetComponent<AudioSource>();
            closeLid.Play();
            shakerRB = cupTransform.GetComponent<Rigidbody>();
            shakerRB.mass = 1;
            lidCD = true;


        }
        if (Input.GetKeyUp(KeyCode.E) && pick.colliderName == "shaker")
        {

            lidBool = false;
            Invoke("lidFalse", 0.25f);

            shakerRB = cupTransform.GetComponent<Rigidbody>();
            shakerRB.mass = 2;


        }
        if (Input.GetMouseButtonUp(0))
        {
            shakerCup.SetActive(false);
            shakerRB = cupTransform.GetComponent<Rigidbody>();
            shakerRB.mass = 2;


        }
        if (Input.GetMouseButtonDown(1))
        {
            shakerCup.SetActive(false);
            shakerRB = cupTransform.GetComponent<Rigidbody>();
            shakerRB.mass = 2;

        }
        if (drinkCS.lanID == 0)
        {
            sugarText.text = "甜度 " + sSugarAmount * 5 + " g";
            iceText.text = "冰量 " + iceg + " g";
            shakeText.text = "搖動次數 " + shake + " 次";
            milkText.text = "牛奶 " + milkML + " ML";
        }
        if (drinkCS.lanID == 1)
        {
            sugarText.text = "Sweetness " + sSugarAmount * 5 + " g";
            iceText.text = "Ice Amount " + iceg + " g";
            shakeText.text = "Shakes  " + shake + " Times";
            milkText.text = "Milk " + milkML + " ML";
        }
        if (drinkCS.lanID == 2)
        {
            sugarText.text = "甘さ " + sSugarAmount * 5 + " g";
            iceText.text = "氷の量 " + iceg + " g";
            shakeText.text = "シェイクの回数  " + shake + " 回";
            milkText.text = "牛乳 " + milkML + " ML";
        }
        if (drinkCS.lanID == 3)
        {
            sugarText.text = "糖 " + sSugarAmount * 5 + " g";
            iceText.text = "冰 " + iceg + " g";
            shakeText.text = "摇动次数 " + shake + " 次";
            milkText.text = "牛奶 " + milkML + " ML";
        }
        if (drinkCS.lanID == 4)
        {
            sugarText.text = "Zucker " + sSugarAmount * 5 + " g";
            iceText.text = "Eis " + iceg + " g";
            shakeText.text = "Shakes " + shake + " Anzahl";
            milkText.text = "Milch " + milkML + " ML";
        }


        if (iceg > 0 && iceg <= 25)
        {
            sIceAmount = 1;
        }
        if (iceg > 25 && iceg < 50)
        {
            sIceAmount = 2;
        }
        if (iceg >= 50 && iceg < 75)
        {
            sIceAmount = 3;
        }
        if (iceg >= 75 && iceg <= 100)
        {
            sIceAmount = 4;
        }

        if (sSugarAmount > 0)
        {
            cupSugar.SetActive(true);
        }
        else
        {
            cupSugar.SetActive(false);
        }
        if (Bml ==0 &&  Gml ==0 && Mml == 0 && isMilk == 0 && waterML >0)
        {
            sc.rend.material.SetColor("_liquidColor", sc.color7);
            sc.rend.material.SetColor("_surfaceColor", sc.scolor7);
        }


        if (Bml > Gml && Bml > Mml && isMilk == 0)
        {
            sc.rend.material.SetColor("_liquidColor", sc.color1);
            sc.rend.material.SetColor("_surfaceColor", sc.scolor1);
            teaID = 1;
        }
        if (Gml > Bml && Gml > Mml && isMilk == 0)
        {
            sc.rend.material.SetColor("_liquidColor", sc.color2);
            sc.rend.material.SetColor("_surfaceColor", sc.scolor2);
            teaID = 2;
        }
        if (Mml > Bml && Mml > Gml && isMilk == 0)
        {
            sc.rend.material.SetColor("_liquidColor", sc.color3);
            sc.rend.material.SetColor("_surfaceColor", sc.scolor3);
            teaID = 3;
        }

        if (cupTransform.position.y >= 1.75f && Input.GetKey(KeyCode.E))
        {

            if(shakable != 1)
            {
                src2.clip = sh[ID];
                src2.Play();
            }
            shakable = 1;

        }
        if(cupTransform.position.y <= 1.7f && Input.GetKey(KeyCode.E))
        {
            if(shakable == 1 && Bml + Gml + Mml  + milkML > 0)
            {

                shakable = 0;
                shake += 1;
                ID = Random.Range(1, 5);
                sr3.clip = sh2[ID];
                sr3.Play();
                if (haveMilk == 1 && shake >= 5)
                {
                    if (Bml > 0 || Gml > 0 || Mml > 0)
                    {
                        checky.milky.SetActive(false);
                        if (teaID == 1 && haveMilk == 1)
                        {
                            isMilk = 1;
                            sc.rend.material.SetColor("_liquidColor", sc.color4);
                            sc.rend.material.SetColor("_surfaceColor", sc.scolor4);
                            teaID = 4;
                        }
                        if (teaID == 2 && haveMilk == 1)
                        {
                            isMilk = 1;
                            sc.rend.material.SetColor("_liquidColor", sc.color5);
                            sc.rend.material.SetColor("_surfaceColor", sc.scolor5);
                            teaID = 5;
                        }
                        if (teaID == 3 && haveMilk == 1)
                        {
                            isMilk = 1;
                            sc.rend.material.SetColor("_liquidColor", sc.color6);
                            sc.rend.material.SetColor("_surfaceColor", sc.scolor6);
                            teaID = 6;
                        }

                    }

                }


            }
        }
        if (Bml > 0 || Gml > 0 || Mml > 0 || waterML >0)
        {
            newTea.SetActive(true); 
        }

        else
        {
            newTea.SetActive(false);

        }






        if (bb == 1)
        {
            boba.SetActive(true);
        }
        if(bobacount == 1)
        {
            boba.SetActive(true);
        }
        if(bobacount == 2)
        {
            boba2.SetActive(true);
        }
        if(bobacount == 3)
        {
            boba3.SetActive(true);
        }
        if(bobacount == 0)
        {
            boba.SetActive(false);
            boba3.SetActive(false);
            boba2.SetActive(false);
        }
        if (sIceAmount == 0)
        {
            ice1.SetActive(false);
            ice2.SetActive(false);
            ice3.SetActive(false);
            ice4.SetActive(false);
        }
        if (sIceAmount == 1)
        {
            ice1.SetActive(true);
            ice2.SetActive(false);
            ice3.SetActive(false);
            ice4.SetActive(false);
        }
        if(sIceAmount == 2)
        {
            ice1.SetActive(true);
            ice2.SetActive(true);
            ice3.SetActive(false);
            ice4.SetActive(false);
        }
        if (sIceAmount == 3)
        {
            ice1.SetActive(true);
            ice2.SetActive(true);
            ice3.SetActive(true);
            ice4.SetActive(false);
        }
        if (sIceAmount == 4)
        {
            ice1.SetActive(true);
            ice2.SetActive(true);
            ice3.SetActive(true);
            ice4.SetActive(true);
        }
        if (cupTransform.eulerAngles.x <= 180f)
        {
            RotationX = cupTransform.eulerAngles.x;
        }
        else
        {
            RotationX = cupTransform.eulerAngles.x - 360f;
        }




        if (cupTransform.eulerAngles.z <= 180f)
        {
            RotationZ = cupTransform.eulerAngles.z;
        }
        else
        {
            RotationZ = cupTransform.eulerAngles.z - 360f;
        }

        if (RotationX > 0)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                if(i == 2 && amount[i] > 0)
                {
                    matchaPart.SetActive(true);
                    powderSrc.Play();
                    Invoke("hidePart", 2f);
                }
                if(amount[i] > 0)
                {
                    obj[i].SetActive(false);
                    amount[i] = 0;
                    currentStain = Instantiate(stains[i], lid.transform.position, stains[i].transform.rotation);
                    sList.stains.Add(currentStain);
                }


            }
            sc.milkRend.material.SetColor("_liquidColor", sc.color8);
            sc.milkRend.material.SetColor("_surfaceColor", sc.scolor8);


            if (iceg >= 10)
            {
                Instantiate(ice, lid.transform.position, Quaternion.identity);
            }
            if (sSugarAmount > 0)
            {
                currentStain = Instantiate(msplash, lid.transform.position, Quaternion.identity);
                sList.stains.Add(currentStain);
                src.clip = sfx5;
                src.Play();
            }
            if (bb > 0)
            {
                Instantiate(floorBoba, lid.transform.position, Quaternion.identity);

            }
            if (milkML > 0)
            {
                isMilk = 0;
                currentStain = Instantiate(milkSplash, lid.transform.position, Quaternion.identity);
                sList.stains.Add(currentStain);
                src.clip = sfx5;
                src.Play();
            }
            if(waterML > 0)
            {
                currentStain = Instantiate(wSplash, lid.transform.position, Quaternion.identity);
                sList.stains.Add(currentStain);
                if (Bml == 0 && Gml == 0 && Mml == 0)
                {
                    src.clip = sfx7;
                    src.Play();
                }
                else
                {
                    src.clip = sfx5;
                    src.Play();
                }

            }

            if (stained == 0)
            {




                if (Bml > 0 || Gml > 0 || Mml > 0 || haveMilk == 1)
                {
                    if (teaID == 1)
                    {

                        currentStain = Instantiate(stainer, lid.transform.position, Quaternion.identity);
                        sList.stains.Add(currentStain);
                    }
                    if(teaID == 2)
                    {
                        currentStain = Instantiate(gsplash, lid.transform.position, Quaternion.identity);
                        sList.stains.Add(currentStain);
                    }
                    if(teaID == 3)
                    {
                        currentStain = Instantiate(msplash, lid.transform.position, Quaternion.identity);
                        sList.stains.Add(currentStain);
                    }
                    if (haveMilk == 1)
                    {
                        isMilk = 0;
                        currentStain = Instantiate(milkSplash, lid.transform.position, Quaternion.identity);
                        sList.stains.Add(currentStain);
                    }



                    stained = 1;
                    if (teaID != 0)
                    {
                        src.clip = sfx5;
                        src.Play();
                        teaID = 0;
                    }
                }
            }
            sIceAmount = 0;
            sSugarAmount = 0;

            iceg = 0;
            bb = 0;
            bobacount = 0;
            teaa.SetActive(false);
 
            checky.milky.SetActive(false);
            haveMilk = 0;
            Bml = 0;
            Gml = 0;
            Mml = 0;
            newML = 0;
            waterML = 0;
            mnml = 0;
            milkML = 0;
            mnml = 0;
            shake = 0;
            stirred = false;

            if (tut.step < 7 && tut.step > 3 && nb.isSealed == 0)
            {
                tut.step = 3;
            }


        }
        else
        {
            stained = 0;
        }
    }
    public void StopFill()
    {
        isFill = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "sliva(Clone)")
        {
            Destroy(other.gameObject);
            isFill = true;
            FillWater();
            Invoke("StopFill",0.1f);
        }
 
        if (other.gameObject.name == "icepile" && iceg < 100)
        {
            Destroy(other);
            iceg += 2;
            ID = Random.Range(1, 5);
            src2.clip = sf[ID];
            src2.Play();


        }

        if (other.gameObject.name == "fallSugar(Clone)" && sSugarAmount < 4)
        {
            Destroy(other);
            sSugarAmount += 1;
            src.clip = sfx2;
            src.Play();



        }
        if (other.gameObject.name == "fallMilk(Clone)" && haveMilk == 0)
        {
            Destroy(other);
            src.clip = sfx2;
            src.Play();
            checky.AddMilk();



        }
        if (other.gameObject.name == "fallBoba(Clone)" && bobacount < 3)
        {
            Destroy(other);
            bobacount += 1;
            src.clip = sfx2;
            src.Play();

            bb = 1;



        }
        if (other.tag == "Scoop()")
        {

        }
        if(other.tag == "spoon")
        {




        }
    }
    public void FillMilk()
    {
        if (milkML < 300 - Bml - Gml - Mml)
        {
            milkML += 1;
            mnml += 0.001f;
            if(played == false)
            {
                src.clip = sfx3;
                src.Play();
                played = true;
            }

        }
    }
    public void FillWater()
    {
        if (waterML + Bml + Gml + Mml < 300)
        {
            sc.rend.material.SetColor("_liquidColor", sc.color7);
            sc.rend.material.SetColor("_surfaceColor", sc.scolor7);
            StartCoroutine(FillingW());
            teaMaterial.color = color7;
        }

    }
    IEnumerator FillingW()
    {
        Debug.Log("fffff");
        while (waterML + Bml + Gml + Mml < 300 && RotationX <= 0 && isFill == true)
        {
            teaa.SetActive(true);
            waterML += 2;
            newML += 0.0022f;





            yield return new WaitForSeconds(0.05f);
        }
    }

    public void FillB()
    {

            lid.SetActive(false);

            teaa.SetActive(true);
            if (drinkCS.bTeaLeft > 0)
            {
                src.clip = sfx3;
                src.Play();
            }
            if (Bml > 0 || Gml > 0 || Mml > 0)
            {


            }
            else
            {

            }
            teaMaterial.color = color1;
            pick.colliderName = null;
            StartCoroutine(FillingB());


    }
    IEnumerator FillingB()
    {
        while (Bml + Gml + Mml  + waterML + milkML <= 300 && drinkCS.bTeaLeft > 0 && pick.colliderName != "shaker" && RotationX <= 0 && Input.GetMouseButton(0) == true)
        {
            if(drinkCS. lanID == 0)
            {
                bText.text = "紅茶" + " " + Bml + "ml";
                gText.text = "綠茶" + " " + Gml + "ml";
                mText.text = "奶精茶" + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 1)
            {
                bText.text = "Black Tea " + " " + Bml + "ml";
                gText.text = "Green Tea " + " " + Gml + "ml";
                mText.text = "Milk Tea " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 2)
            {
                bText.text = "紅茶 " + " " + Bml + "ml";
                gText.text = "緑茶 " + " " + Gml + "ml";
                mText.text = "ミルクティー " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 3)
            {
                bText.text = "红茶 " + " " + Bml + "ml";
                gText.text = "绿茶 " + " " + Gml + "ml";
                mText.text = "奶茶 " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 4)
            {
                bText.text = "Schwarzer Tee " + " " + Bml + "ml";
                gText.text = "Grüner Tee " + " " + Gml + "ml";
                mText.text = "Milchtee " + " " + Mml + "ml";
            }

            Bml += 2;
            drinkCS.bTeaLeft -= 2;
            newML += 0.0022f;





            yield return new WaitForSeconds(0.05f);
        }

    }

    public void FillG()
    {

        {
            lid.SetActive(false);

            teaa.SetActive(true);
            if (drinkCS.gTeaLeft > 0)
            {
                src.clip = sfx3;
                src.Play();
            }

            teaMaterial.color = color2;
            pick.colliderName = null;
            StartCoroutine(FillingG());

        }

    }
    IEnumerator FillingG()
    {
        while (Bml + Gml + Mml + waterML + milkML <= 300 && drinkCS.gTeaLeft > 0 && pick.colliderName != "shaker" && RotationX <= 0 && Input.GetMouseButton(0) == true)
        {

            if (drinkCS.lanID == 0)
            {
                bText.text = "紅茶" + " " + Bml + "ml";
                gText.text = "綠茶" + " " + Gml + "ml";
                mText.text = "奶精茶" + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 1)
            {
                bText.text = "Black Tea " + " " + Bml + "ml";
                gText.text = "Green Tea " + " " + Gml + "ml";
                mText.text = "Milk Tea " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 2)
            {
                bText.text = "紅茶 " + " " + Bml + "ml";
                gText.text = "緑茶 " + " " + Gml + "ml";
                mText.text = "ミルクティー " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 3)
            {
                bText.text = "红茶 " + " " + Bml + "ml";
                gText.text = "绿茶 " + " " + Gml + "ml";
                mText.text = "奶茶 " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 4)
            {
                bText.text = "Schwarzer Tee " + " " + Bml + "ml";
                gText.text = "Grüner Tee " + " " + Gml + "ml";
                mText.text = "Milchtee " + " " + Mml + "ml";
            }
            Gml += 2;
            drinkCS.gTeaLeft -= 2;
            newML += 0.0022f;

            yield return new WaitForSeconds(0.05f);
        }

    }
    public void FillM()
    {

        {
            lid.SetActive(false);

            teaa.SetActive(true);
            if (drinkCS.mTeaLeft > 0)
            {
                src.clip = sfx3;
                src.Play();
            }

            teaMaterial.color = color3;
            pick.colliderName = null;
            StartCoroutine(FillingM());
        }

    }
    IEnumerator FillingM()
    {
        while (Bml + Gml + Mml + waterML + milkML <= 300 && drinkCS.mTeaLeft > 0 && pick.colliderName != "shaker" && RotationX <= 0 && Input.GetMouseButton(0) == true)
        {

            if (drinkCS.lanID == 0)
            {
                bText.text = "紅茶" + " " + Bml + "ml";
                gText.text = "綠茶" + " " + Gml + "ml";
                mText.text = "奶精茶" + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 1)
            {
                bText.text = "Black Tea " + " " + Bml + "ml";
                gText.text = "Green Tea " + " " + Gml + "ml";
                mText.text = "Milk Tea " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 2)
            {
                bText.text = "紅茶 " + " " + Bml + "ml";
                gText.text = "緑茶 " + " " + Gml + "ml";
                mText.text = "ミルクティー " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 3)
            {
                bText.text = "红茶 " + " " + Bml + "ml";
                gText.text = "绿茶 " + " " + Gml + "ml";
                mText.text = "奶茶 " + " " + Mml + "ml";
            }
            if (drinkCS.lanID == 4)
            {
                bText.text = "Schwarzer Tee " + " " + Bml + "ml";
                gText.text = "Grüner Tee " + " " + Gml + "ml";
                mText.text = "Milchtee " + " " + Mml + "ml";
            }
            Mml += 2;
            drinkCS.mTeaLeft -= 2;
            newML += 0.0022f;

            yield return new WaitForSeconds(0.05f);
        }

    }
    public void Transfer()
    {
        Debug.Log("Trans");
        cupstat = currentCup.GetComponent<cupStats>();
        if (cupstat.liquidAmount < 0.5f)
        {
            cupstat.liquidAmount = newML;
            cupstat.liquidAmount += mnml;
            cupstat.xwob = cupstat.liquidAmount;
        }
        else
        {
            cupstat.liquidAmount = 0.5f;
        }
        if(cupstat.Bml + cupstat.Gml + cupstat.Mml < 300)
        {
            cupstat.Bml = Bml;
            cupstat.Gml = Gml;
            cupstat.Mml = Mml;
            cupstat.milkML = milkML;
            if (cupstat.Bml > 300)
            {
                cupstat.Bml = 300;
            }
            if (cupstat.Gml > 300)
            {
                cupstat.Gml = 300;
            }
            if (cupstat.Mml > 300)
            {
                cupstat.Mml = 300;
            }


        }
        cupstat.teaID = teaID;
        if(cupstat.teaID == 1)
        {
            cupstat.rend.material.SetColor("_liquidColor", sc.color1);
            cupstat.rend.material.SetColor("_surfaceColor", sc.scolor1);
        }
        if (cupstat.teaID == 2)
        {
            cupstat.rend.material.SetColor("_liquidColor", sc.color2);
            cupstat.rend.material.SetColor("_surfaceColor", sc.scolor2);
        }
        if (cupstat.teaID == 3)
        {
            cupstat.rend.material.SetColor("_liquidColor", sc.color3);
            cupstat.rend.material.SetColor("_surfaceColor", sc.scolor3);
        }
        if (cupstat.teaID == 4)
        {
            cupstat.rend.material.SetColor("_liquidColor", sc.color4);
            cupstat.rend.material.SetColor("_surfaceColor", sc.scolor4);
        }
        if (cupstat.teaID == 5)
        {
            cupstat.rend.material.SetColor("_liquidColor", sc.color5);
            cupstat.rend.material.SetColor("_surfaceColor", sc.scolor5);
        }
        if (cupstat.teaID == 6)
        {
            cupstat.rend.material.SetColor("_liquidColor", sc.color6);
            cupstat.rend.material.SetColor("_surfaceColor", sc.scolor6);
        }
        if (cupstat.teaID == 7)
        {
            cupstat.rend.material.SetColor("_liquidColor", sc.color9);
            cupstat.rend.material.SetColor("_surfaceColor", sc.scolor9);
        }
        cupstat.iceAmount = sIceAmount;
        cupstat.haveBoba = bobacount;
        cupstat.haveMilk = haveMilk;
        cupstat.isMilk = isMilk;
        cupstat.shakes = shake;
        if(cupstat.haveBoba == 0)
        {
            cupstat.boba1.SetActive(false);
        }
        if (cupstat.haveBoba >= 1)
        {
            cupstat.boba1.SetActive(true);
        }
        if (cupstat.haveBoba >= 2)
        {
            cupstat.boba2.SetActive(true);
        }
        if (cupstat.haveBoba >= 3)
        {
            cupstat.boba3.SetActive(true);
        }
        if(cupstat.haveBoba > 0)
        {
            cupstat.haveBoba = 1;
        }
        if (cupstat.iceAmount >= 4)
        {
            cupstat.iceAmount = 4;
        }
        cupstat.sugarAmount = sSugarAmount;
        if (cupstat.sugarAmount >= 4)
        {
            cupstat.sugarAmount = 4;


        }
        if(cupstat.iceAmount == 0)
        {
            cupstat.ice1.SetActive(false);
        }
        if (cupstat.iceAmount >= 1)
        {
            cupstat.ice1.SetActive(true);
        }
        if (cupstat.iceAmount >= 2)
        {
            cupstat.ice2.SetActive(true);
        }
        if (cupstat.iceAmount >= 3)
        {
            cupstat.ice3.SetActive(true);
        }
        if (cupstat.iceAmount >= 4)
        {
            cupstat.ice4.SetActive(true);
        }


        if (Bml > 0 || Gml > 0 || Mml > 0 || milkML > 0)
        {
            cupstat.liquid.SetActive(true);
        }
        else
        {
            cupstat.liquid.SetActive(false);
        }

        slid.cd = true;
        if(transfered == false)
        {
            transfered = true;
        }
        Invoke("Restart", 0.1f);

    }

    public void Transfer1()
    {

        if (nb.isSealed != 1)
        {
            nb.newM = newML;
            nb.newM += mnml;
            Debug.Log("Transfer");
            if (isMilk == 1)
            {
                nb.Bml += Bml;
                nb.Gml += Gml;
                nb.Mml += Mml;

            }
            else
            {
                nb.Bml += Bml;
                nb.Gml += Gml;
                nb.Mml += Mml;
            }
            nb.waterML += waterML;
            src.clip = sfx3;
            src.Play();


            nb.iceAmount += sIceAmount;
            if (nb.iceAmount >= 4)
            {
                nb.iceAmount = 4;
            }
            nb.sugarAmount += sSugarAmount;
            if (nb.sugarAmount >= 4)
            {
                nb.sugarAmount = 4;
            }
            nb.isMilk = isMilk;
            nb.haveCupMilk = haveMilk;
            if(teaID == 5)
            {
                sc.rend2.material.SetColor("_liquidColor", sc.color4);
                sc.rend2.material.SetColor("_surfaceColor", sc.scolor4);
            }
            if (teaID == 4)
            {
                sc.rend2.material.SetColor("_liquidColor", sc.color5);
                sc.rend2.material.SetColor("_surfaceColor", sc.scolor5);
            }
            if (teaID == 6)
            {
                sc.rend2.material.SetColor("_liquidColor", sc.color6);
                sc.rend2.material.SetColor("_surfaceColor", sc.scolor6);
            }
            if(teaID == 0 && haveMilk == 1)
            {
                sc.rend2.material.SetColor("_liquidColor", sc.color7);
                sc.rend2.material.SetColor("_surfaceColor", sc.scolor7);
            }
            nb.haveBB = bb;
            nb.shake = shake;
            nb.teaID = teaID;
            nb.bobacount = bobacount;


            slid.cd = true;
            
            Invoke("Restart", 0.1f);



        }
        
    }
    public void Restart()
    {
        sc.milkRend.material.SetColor("_liquidColor", sc.color8);
        sc.milkRend.material.SetColor("_surfaceColor", sc.scolor8);
        iceg = 0;
        shake = 0;
        bb = 0;
        Bml = 0;
        Gml = 0;
        Mml = 0;
        sIceAmount = 0;
        sSugarAmount = 0;
        teaID = 0;
        nb.useShaker = 1;
        haveMilk = 0;
        isMilk = 0;
        newML = 0;
        shake = 0;
        bb = 0;
        Bml = 0;
        Gml = 0;
        Mml = 0;
        sIceAmount = 0;
        sSugarAmount = 0;
        teaID = 0;
        nb.useShaker = 1;
        haveMilk = 0;
        isMilk = 0;
        bobacount = 0;
        waterML = 0;
        milkML = 0;
        mnml = 0;
        extra = 0;
        stirred = false;
        for (int i = 0; i < amount.Length; i++)
        {
            amount[i] = 0;
            obj[i].SetActive(false);
        }
    }
    public void AddSugar()
    {
        if (haveSugar == 1)
        {

            haveSugar = 0;
            cTrigger.haveSugar = 0;
            spoonSugar.SetActive(false);
            src.clip = sfx2;
            src.Play();
            if (sSugarAmount < 4)
            {
                sSugarAmount += 1;


            }
            else
            {


            }
 
        }
    }
    public void AddBoba()
    {
        if (haveBoba == 1)
        {

            haveBoba = 0;
            cTrigger.haveBoba = 0;
            src.clip = sfx2;
            src.Play();
            spoonBoba.SetActive(false);
            bobacount += 1;
            if (bobacount > 3)
            {
                bobacount = 3;
                Instantiate(floorBoba, gameObject.transform.position, Quaternion.identity);
            }
            bb = 1;


        }
    }
}
