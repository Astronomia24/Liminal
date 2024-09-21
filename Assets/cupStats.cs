using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupStats : MonoBehaviour
{
    public int Bml;
    public int Gml;
    public int Mml;
    public int milkML;
    public int sugarAmount;
    public int iceAmount;
    public int haveBoba;
    public int isMilk;
    public int haveMilk;
    public float liquidAmount;
    public int shakes;
    public Renderer rend;
    public float xwob;
    public GameObject liquid;
    public shaderControl colorControl;
    public int teaID;
    public Transform cupTransform;
    public float RotationX;
    public float RotationZ;
    public GameObject ice1;
    public GameObject ice2;
    public GameObject ice3;
    public GameObject ice4;
    public GameObject splash;
    public GameObject cupSrc;
    public GameObject boba1;
    public GameObject boba2;
    public GameObject boba3;
    public int isSealed;
    public GameObject seal;
    DrinkID drinkCS;
    PickUpClass pick;
    stainList sList;
    public GameObject currentStain;
    // Start is called before the first frame update
    void Start()
    {
        cupTransform = gameObject.transform;
        liquid = gameObject.transform.GetChild(0).gameObject;
        ice1 = gameObject.transform.GetChild(1).gameObject;
        ice2 = gameObject.transform.GetChild(2).gameObject;
        ice3 = gameObject.transform.GetChild(3).gameObject;
        ice4 = gameObject.transform.GetChild(4).gameObject;
        boba1 = gameObject.transform.GetChild(5).gameObject;
        boba2 = gameObject.transform.GetChild(6).gameObject;
        boba3 = gameObject.transform.GetChild(7).gameObject;
        seal = gameObject.transform.GetChild(8).gameObject;
        seal.SetActive(false);

        rend = liquid.GetComponent<Renderer>();
        liquid.SetActive(false);
        ice1.SetActive(false);
        ice2.SetActive(false);
        ice3.SetActive(false);
        ice4.SetActive(false);
        boba1.SetActive(false);
        boba2.SetActive(false);
        boba3.SetActive(false);
        isSealed = 0;
        drinkCS = FindObjectOfType<DrinkID>();
        pick = FindObjectOfType<PickUpClass>();
        sList = FindObjectOfType<stainList>();
    }


    // Update is called once per frame
    void Update()
    {
        rend.material.SetFloat("_fill", xwob);


        if(Bml + Gml + Mml > 0)
        {
            liquid.SetActive(true);
        }
        else if(haveMilk == 1 && isMilk == 0)
        {
            liquid.SetActive(true);
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
        if(RotationZ > 90f || RotationZ < -90f )
        {
            if (isSealed == 0)
            {
                if (Bml + Gml + Mml > 0 || haveBoba >0 || haveMilk > 0)
                {
                    if (teaID == 1)
                    {
                        splash = GameObject.Find("bsplash");
                    }
                    if (teaID == 2)
                    {
                        splash = GameObject.Find("gsplash");
                    }
                    if (teaID == 3)
                    {
                        splash = GameObject.Find("msplash");
                    }
                    if (teaID == 4)
                    {
                        splash = GameObject.Find("bsplash");
                    }
                    if (teaID == 5)
                    {
                        splash = GameObject.Find("gsplash");
                    }
                    if (teaID == 6)
                    {
                        splash = GameObject.Find("msplash");
                    }
                    Bml = 0;

                    Gml = 0;
                    Mml = 0;
                    sugarAmount = 0;
                    iceAmount = 0;
                    haveBoba = 0;
                    isMilk = 0;
                    haveMilk = 0;
                    liquidAmount = 0;
                    xwob = 0;
                    teaID = 0;
                    shakes = 0;

                    liquid.SetActive(false);
                    ice1.SetActive(false);
                    ice2.SetActive(false);
                    ice3.SetActive(false);
                    ice4.SetActive(false);
                    boba1.SetActive(false);
                    boba2.SetActive(false);
                    boba3.SetActive(false);
                    currentStain = Instantiate(splash, cupTransform.position, Quaternion.identity);
                    sList.stains.Add(currentStain);
                    cupSrc = GameObject.Find("cupSource");
                    cupSrc.GetComponent<AudioSource>().Play();

                }
            }
        }
    }
}
