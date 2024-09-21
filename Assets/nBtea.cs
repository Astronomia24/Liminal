using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nBtea : MonoBehaviour
{
    PickUpClass pick;
    public GameObject cup;
    public GameObject teaa;
    public GameObject teaa2;
    public GameObject teaa3;
    public GameObject teaa4;
    public GameObject cupTrigger;
    public Transform cupTransform;
    public GameObject split;
    public GameObject splash;
    public GameObject teaCanvas;
    public int BT;
    public int GT;
    public int MT;
    public int teaID;
    public int isSplashed;
    public AudioSource src;
    public AudioClip sfx;
    public AudioClip sfx2;
    public AudioClip sfx3;
    public AudioClip sfx4;
    public float RotationX;
    public float RotationZ;
    public int shake;
    public int shakable;
    public int Bml;
    public int Gml;
    public int Mml;
    public int sBml;
    public int sGml;
    public int sMml;
    public int endFill;
    public Text bText;
    public Text gText;
    public Text mText;
    public Material testMaterial;
    public int iceAmount;
    public int sugarAmount;
    public GameObject ps1;
    public GameObject ps2;
    public GameObject ps3;
    DrinkID drinkCS;
    public GameObject go;
    public int isSealed;
    public GameObject shaker;
    public GameObject shakerLid;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public GameObject boba;
    public GameObject boba2;
    public GameObject boba3;
    public int haveBB;
    shakerController sCS;
    public GameObject shakerTrigger;
    public int useShaker;
    public GameObject stainer;
    public GameObject cupMilk;
    public int haveCupMilk;
    public GameObject gsplash;
    public GameObject msplash;
    public GameObject milkSplash;
    public GameObject ice;
    public int isMilk;
    public GameObject fBoba;
    public GameObject newTea;
    public float newM;
    shaderControl sc;
    public int bobacount;
    public int waterML;
    public bool isFill;











    // Start is called before the first frame update
    void Start()
    {
        bobacount = 0;
        sc = FindObjectOfType<shaderControl>();
        newM = 0;
        haveCupMilk = 0;
        haveBB = 0;
        isSealed = 0;
        ps1.SetActive(false);
        ps2.SetActive(false);
        ps3.SetActive(false);
        pick = FindObjectOfType<PickUpClass>();
        sCS = FindObjectOfType<shakerController>();
        BT = 0;
        GT = 0;
        MT = 0;
        drinkCS = FindObjectOfType<DrinkID>();
        teaID = 0;
        isSplashed = 0;
        shake = 0;
        shakable = 0;
        endFill = 0;
        Bml = 0;
        Gml = 0;
        Mml = 0;
        sBml = 0;
        sGml = 0;
        sMml = 0;
        teaCanvas.SetActive(false);
        teaa.SetActive(false);
        testMaterial = teaa.GetComponent<Renderer>().sharedMaterial;
        useShaker = 0;
        cupMilk.SetActive(false);
        isMilk = 0;
        waterML = 0;
        isFill = false;




    }

    // Update is called once per frame
    void Update()
    {
        if (Bml > 0 || Gml > 0 || Mml > 0 || waterML >0 || isMilk != 0 || haveCupMilk != 0)
        {
            teaa.SetActive(true);
        }
        else
        {
            teaa.SetActive(false);

        }
        if (Bml == 0 && Gml == 0 && Mml == 0 && isMilk == 0 && waterML > 0)
        {
            sc.rend.material.SetColor("_liquidColor", sc.color7);
            sc.rend.material.SetColor("_surfaceColor", sc.scolor7);
        }
        if (Bml > Gml && Bml > Mml && isMilk == 0)
        {
            sc.rend2.material.SetColor("_liquidColor", sc.color1);
            sc.rend2.material.SetColor("_surfaceColor", sc.scolor1);
            teaID = 1;
        }
        if(Gml > Bml && Gml > Mml && isMilk == 0)
        {
            sc.rend2.material.SetColor("_liquidColor", sc.color2);
            sc.rend2.material.SetColor("_surfaceColor", sc.scolor2);
            teaID = 2;
        }
        if(Mml > Bml && Mml > Gml && isMilk == 0)
        {
            sc.rend2.material.SetColor("_liquidColor", sc.color3);
            sc.rend2.material.SetColor("_surfaceColor", sc.scolor3);
            teaID = 3;
        }
        if (teaID == 1 && haveCupMilk == 1)
        {
            isMilk = 1;
            sc.rend2.material.SetColor("_liquidColor", sc.color4);
            sc.rend2.material.SetColor("_surfaceColor", sc.scolor4);
            teaID = 5;
        }
        if (teaID == 2 && haveCupMilk == 1)
        {
            isMilk = 1;
            sc.rend2.material.SetColor("_liquidColor", sc.color5);
            sc.rend2.material.SetColor("_surfaceColor", sc.scolor5);
            teaID = 4;
        }
        if (teaID == 3 && haveCupMilk == 1)
        {
            isMilk = 1;
            sc.rend2.material.SetColor("_liquidColor", sc.color6);
            sc.rend2.material.SetColor("_surfaceColor", sc.scolor6);
            teaID = 6;
        }





        if (haveBB == 1)
        {
            if(bobacount == 1)
            {
                boba.SetActive(true);
                boba2.SetActive(false);
                boba3.SetActive(false);
            }
            if (bobacount == 2)
            {
                boba.SetActive(true);
                boba2.SetActive(true);
                boba3.SetActive(false);
            }
            if (bobacount == 3)
            {
                boba.SetActive(true);
                boba2.SetActive(true);
                boba3.SetActive(true);
            }

        }
        if(haveBB == 0)
        {
            boba.SetActive(false);
            boba2.SetActive(false);
            boba3.SetActive(false);

        }


        if (pick.colliderName == "nCup")
        {
            StopCoroutine(FillingB());

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




        if (RotationX >= 90 || RotationX <= -90 || RotationZ <= -90 || RotationZ >= 90)
        {
            if (isSealed == 0)
            {
                if(iceAmount > 0)
                {
                    Instantiate(ice, cup.transform.position, Quaternion.identity);
                }
                if (haveBB > 0)
                {
                    Instantiate(fBoba, cup.transform.position, Quaternion.identity);
                    bobacount = 0;
                }
                if (sugarAmount > 0)
                {
                    Instantiate(msplash, cup.transform.position, Quaternion.identity);
                    src.clip = sfx2;
                    src.Play();
                }

                iceAmount = 0;
                sugarAmount = 0;
                haveBB = 0;
            }


            if (teaID != 0 && isSealed == 0 || haveCupMilk != 0 && isSealed == 0 || waterML >0)
            {

                waterML = 0;
                teaa.SetActive(false);
                cupTrigger.SetActive(true);
                src.clip = sfx2;
                src.Play();
                cupMilk.SetActive(false);

                haveBB = 0;
                Bml = 0;
                Gml = 0;
                Mml = 0;
                shake = 0;
                iceAmount = 0;
                sugarAmount = 0;
                newM =0;
                waterML = 0;
                if (teaID == 1)
                {
                    Instantiate(stainer, cup.transform.position, Quaternion.identity);
                }
                if(teaID == 2)
                {
                    Instantiate(gsplash, cup.transform.position, Quaternion.identity);
                }
                if(teaID == 3)
                {
                    Instantiate(msplash, cup.transform.position, Quaternion.identity);
                }
                if(haveCupMilk == 1)
                {
                    Instantiate(milkSplash, cup.transform.position, Quaternion.identity);
                    isMilk = 0;

                }
                haveCupMilk = 0;


                isSplashed = 1;
                StartCoroutine(SplashGone());
                teaID = 0;
            }



        }
        else if (RotationZ <= 89 || RotationZ >= -89 || RotationX <= 89 || RotationX >= -89)
        {

            split.SetActive(false);
            isSplashed = 0;

        }
        if (RotationX <= - 10)
        {


            if (teaID != 0 )
            {
                if (shakable == 0)
                {
                    src.clip = sfx3;
                    src.Play();
                    shake += 1;
                    shakable = 1;
                    if(haveCupMilk == 1 && teaID != 0)
                    {
                        cupMilk.SetActive(false);

                        if (teaID == 1 && haveCupMilk == 1)
                        {
                            isMilk = 1;
                            sc.rend2.material.SetColor("_liquidColor", sc.color4);
                            sc.rend2.material.SetColor("_surfaceColor", sc.scolor4);
                            teaID = 5;
                        }
                        if (teaID == 2 && haveCupMilk == 1)
                        {
                            isMilk = 1;
                            sc.rend2.material.SetColor("_liquidColor", sc.color5);
                            sc.rend2.material.SetColor("_surfaceColor", sc.scolor5);
                            teaID = 4;
                        }
                        if (teaID == 3 && haveCupMilk == 1)
                        {
                            isMilk = 1;
                            sc.rend2.material.SetColor("_liquidColor", sc.color6);
                            sc.rend2.material.SetColor("_surfaceColor", sc.scolor6);
                            teaID = 6;
                        }

                    }
                }

            }




        }
        if (RotationX >= 10)
        {
            shakable = 0;
        }
    }
    public void FillWater()
    {
        if (waterML + Bml + Gml + Mml < 300 && isSealed == 0)
        {

            StartCoroutine(FillingW());
            src.clip = sfx3;
            src.Play();
            testMaterial.color = color7;
        }

    }
    IEnumerator FillingW()
    {
        Debug.Log("fffff");
        while (waterML + Bml + Gml + Mml < 300 && isFill == true)
        {
            teaa.SetActive(true);
            waterML += 2;
            newM += 0.0022f;





            yield return new WaitForSeconds(0.05f);
        }
    }
    public void FillB()
    {
        
        {

            if (drinkCS.bTeaLeft > 0 && isSealed == 0)
            {
                if (Bml + Gml + Mml + waterML < 300)
                {

                    testMaterial.color = color1;
                    teaa.SetActive(true);

                    pick.colliderName = null;
                    if (drinkCS.bTeaLeft > 0)
                    {
                        src.clip = sfx;
                        src.Play();
                    }
                    Debug.Log("BlackTea");

                    teaID = 1;

                    StartCoroutine(FillingB());
                }



            }
            if(pick.colliderName == "bTeaCan(Clone)")
            {
                GameObject go = GameObject.Find("bTeaCan(Clone)");
                Destroy(go.gameObject);
                drinkCS.bTeaLeft += 2000;

            }
            if (pick.colliderName == "shaker" && drinkCS.bTeaLeft > 0)
            {




            }
        }




    }
    IEnumerator FillingB()
    {
        while (Bml + Gml + Mml + waterML < 300 && pick.colliderName != "nCup" && isSplashed != 1 && drinkCS.bTeaLeft > 0 && Input.GetMouseButton(0) == true)
        {
            cupTrigger.SetActive(false);
            bText.text = "¬õ¯ù" + " " + Bml + "ml";
            gText.text = "ºñ¯ù" + " " + Gml + "ml";
            mText.text = "¥¤ºë¯ù" + " " + Mml + "ml";
            Bml += 2;
            drinkCS.bTeaLeft -= 2;
            newM += 0.0025f;

            yield return new WaitForSeconds(0.05f);
        }

        cupTrigger.SetActive(true);
        ps1.SetActive(false);





    }




    public void FillG()
    {
        
        {

            if ( drinkCS.gTeaLeft > 0 && isSealed == 0)
            {
                if (Bml + Gml + Mml + waterML < 300)
                {
  
                    testMaterial.color = color2;
                    teaa.SetActive(true);

                    pick.colliderName = null;
                    if (drinkCS.gTeaLeft > 0)
                    {
                        src.clip = sfx;
                        src.Play();
                    }
                    Debug.Log("GreenTea");

                    teaID = 2;
                    StartCoroutine(FillingG());
                }


            }
            if (pick.colliderName == "gTeaCan(Clone)")
            {
                GameObject go = GameObject.Find("gTeaCan(Clone)");
                Destroy(go.gameObject);
                drinkCS.gTeaLeft += 2000;

            }
        }
    }

    IEnumerator FillingG()
    {
        while (Bml + Gml + Mml + waterML < 300 && pick.colliderName != "nCup" && isSplashed != 1 && drinkCS.gTeaLeft > 0 && Input.GetMouseButton(0) == true)
        {
            cupTrigger.SetActive(false);
            bText.text = "¬õ¯ù" + " " + Bml + "ml";
            gText.text = "ºñ¯ù" + " " + Gml + "ml";
            mText.text = "¥¤ºë¯ù" + " " + Mml + "ml";
            Gml += 2;
            drinkCS.gTeaLeft -= 2;
            newM += 0.0025f;
            yield return new WaitForSeconds(0.05f);
        }

        cupTrigger.SetActive(true);
        ps2.SetActive(false);





    }
    public void FillM()
    {
        
        {

            if (drinkCS.mTeaLeft > 0 && isSealed == 0)
            {
                if (Bml + Gml + Mml + waterML < 300)
                {

                    testMaterial.color = color3;
                    teaa.SetActive(true);

                    pick.colliderName = null;
                    if (drinkCS.mTeaLeft > 0)
                    {
                        src.clip = sfx;
                        src.Play();
                    }
                    Debug.Log("MilkTea");

                    teaID = 3;
                    StartCoroutine(FillingM());
                }


            }
            if (pick.colliderName == "mTeaCan(Clone)")
            {
                GameObject go = GameObject.Find("mTeaCan(Clone)");
                Destroy(go.gameObject);
                drinkCS.mTeaLeft += 2000;

            }
        }
    }

    IEnumerator FillingM()
    {
        while (Bml + Gml + Mml + waterML < 300 && pick.colliderName != "nCup" && isSplashed != 1 && drinkCS.mTeaLeft >0 && Input.GetMouseButton(0) == true)
        {

            cupTrigger.SetActive(false);
            bText.text = "¬õ¯ù" + " " + Bml + "ml";
            gText.text = "ºñ¯ù" + " " + Gml + "ml";
            mText.text = "¥¤ºë¯ù" + " " + Mml + "ml";
            Mml += 2;
            drinkCS.mTeaLeft -= 2;
            newM += 0.0025f;
            yield return new WaitForSeconds(0.05f);
        }

        cupTrigger.SetActive(true);
        ps3.SetActive(false);





    }
    IEnumerator SplashGone()
    {
        yield return new WaitForSeconds(3);
        splash.SetActive(false);
    }
}
