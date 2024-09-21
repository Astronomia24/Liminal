using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bucketTrigger : MonoBehaviour
{
    public GameObject Water;
    public GameObject Water2;
    public GameObject Water3;
    public GameObject Water4;
    public GameObject floorBoba;
    public GameObject mlTextBox;
    public bool isFilling;
    public int ml;
    public Text mlText;
    public GameObject bucket;
    public float RotationX;
    public float RotationZ;
    public GameObject waterStain;
    public GameObject bStain;
    public GameObject gStain;
    public GameObject mStain;
    public AudioSource src;
    public AudioClip sfx1;
    public AudioClip sfx2;
    tutorControl tut;
    public Transform w1;
    public Transform w2;
    public Transform w3;
    public Transform w4;


    Controller player;
    PickUpClass pick;
    checkTrigger cTrigger;
    cook ck;
    public Transform endPos;
    public Transform startPos;
    public Transform updatePos;
    public bool splashed;
    checkice ci;
    facuetrigger ft;
    public GameObject progress;
    stainList sList;
    public GameObject currentStain;
    // Start is called before the first frame update
    void Start()
    {
        Water.SetActive(false);
        isFilling = false;
        player = FindObjectOfType<Controller>();
        pick = FindObjectOfType<PickUpClass>();
        cTrigger = FindObjectOfType<checkTrigger>();
        ck = FindObjectOfType<cook>();
        tut = FindObjectOfType<tutorControl>();
        w1 = Water.transform;
        w2 = Water2.transform;
        w3 = Water3.transform;
        w4 = Water4.transform;
        Water.SetActive(false);
        updatePos = startPos;
        splashed = false;
        ci = FindObjectOfType<checkice>();
        ft = FindObjectOfType<facuetrigger>();
        sList = FindObjectOfType<stainList>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isFilling == true && ml != 0 && RotationX < 60 && RotationX > -60 && RotationZ < 60 && RotationZ > -60)
        {
            splashed = false;
            updatePos = Water.transform;
            Water.transform.position = Vector3.Lerp(updatePos.position, endPos.position, Time.deltaTime * 0.1f);
        }
        else if (isFilling == true)
        {
            Water.transform.position = Vector3.Lerp(updatePos.position, endPos.position, Time.deltaTime * 0.1f);
        }
        if (ml > 0)
        {
            progress.SetActive(true);

        }
        else
        {
            progress.SetActive(false);
        }




        if (ml == 0)
        {
            mlTextBox.SetActive(false);
        }
        else
        {
            mlTextBox.SetActive(true);
        }
        if (bucket.transform.eulerAngles.x <= 180f)
        {
            RotationX = bucket.transform.eulerAngles.x;
        }
        else
        {
            RotationX = bucket.transform.eulerAngles.x - 360f;
        }
        if (player.walkSpeed != 1)
        {
            if(ml > 650 && pick.colliderName == "teaBucket")
            {
                player.walkSpeed = 3;
            }
            if(pick.colliderName != "teaBucket" && player.walkSpeed != 1)
            {
                player.walkSpeed = 5;
            }
        }
        if(ml > 0 && ml <= 1)
        {
            src.clip = sfx1;
            src.Play();
        }






        if (bucket.transform.eulerAngles.z <= 180f)
        {
            RotationZ = bucket.transform.eulerAngles.z;
        }
        else
        {
            RotationZ = bucket.transform.eulerAngles.z - 360f;
        }
        if(ml > 650)
        {
            if (RotationX > 60 || RotationX < -60 || RotationZ > 60 || RotationZ < -60)
            {
                if (ml > 0 && splashed == false)
                {
                    if (cTrigger.mTea == true)
                    {
                        Instantiate(mStain, Water.transform.position, Quaternion.identity);
                    }
                    else if (cTrigger.bTea == true)
                    {
                        Instantiate(bStain, Water.transform.position, Quaternion.identity);
                    }
                    else if (cTrigger.gTea == true)
                    {
                        Instantiate(gStain, Water.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(waterStain, Water.transform.position, Quaternion.identity);
                        splashed = true;
                    }
                    src.clip = sfx2;
                    src.Play();
                    ml = 0;
                    updatePos = startPos;
                    Water.SetActive(false);
                    mlText.text = ml + " ml";
                    ck.isCooking = false;
                    ck.cookTimer = 0;

                }
            }


        }
        if(RotationX > 89 || RotationX < -89 || RotationZ > 89 || RotationZ < -89)
        {
            if (ml > 0 && splashed == false)
            {
                if (cTrigger.mTea == true)
                {
                    currentStain = Instantiate(mStain, Water.transform.position, Quaternion.identity);
                    sList.stains.Add(currentStain);
                }
                else if (cTrigger.gTea == true)
                {
                    currentStain = Instantiate(gStain, Water.transform.position, Quaternion.identity);
                    sList.stains.Add(currentStain);
                }
                else if(cTrigger.bTea == true)
                {
                    currentStain = Instantiate(bStain, Water.transform.position, Quaternion.identity);
                    sList.stains.Add(currentStain);
                }
                else
                {
                    currentStain = Instantiate(waterStain, Water.transform.position, Quaternion.identity);
                    sList.stains.Add(currentStain);
                    splashed = true;
                }
                src.clip = sfx2;
                src.Play();
                ml = 0;
                Water.SetActive(false);
                mlText.text = ml + " ml";
                ck.isCooking = false;
                ck.cookTimer = 0;
                updatePos = startPos;
            }
            if(cTrigger.haveBB == true)
            {
                Instantiate(floorBoba, Water.transform.position, floorBoba.transform.rotation);
                cTrigger.haveBB = false;
                cTrigger.bobas.SetActive(false);
                cTrigger.bobas2.SetActive(false);
                cTrigger.cookBB = false;
            }



        }

        if (isFilling == true)
        {
                Invoke("FillWater", 0.5f);
                mlText.text = ml + " ml";
        }
        
        if(ml == 0)
        {
            //Water.SetActive(false);
            //Water2.SetActive(false);
            //Water3.SetActive(false);
            //Water4.SetActive(false);
        }
        if(ml > 0 && ml < 250)
        {
            Water.SetActive(true);
            //Water2.SetActive(false);
            //Water3.SetActive(false);
            //Water4.SetActive(false);

        }
        if(ml > 250 && ml < 500)
        {
            //Water.SetActive(false);
            //Water2.SetActive(true);
            //Water3.SetActive(false);
            //Water4.SetActive(false);
        }
        if(ml > 500 && ml < 750)
        {
            //Water.SetActive(false);
            //Water2.SetActive(false);
            //Water3.SetActive(true);
            //Water4.SetActive(false);
        }
        if(ml > 750 && ml < 1000)
        {
            //Water.SetActive(false);
            //Water2.SetActive(false);
            //Water3.SetActive(false);
            //Water4.SetActive(true);
        }

        if(cTrigger.haveBB == true)
        {
            cTrigger.bobas.transform.position = Water.transform.position;
        }
    }





    public void FillWater()
    {
        if (ml < 1000)
        {
            ml += 1;
        }
    }
    public void Reset()
    {
        ml = 0;
        mlText.text = ml + " ml";
        ck.cookTimer = 0;
        ck.isBurn = false;
    }
}
