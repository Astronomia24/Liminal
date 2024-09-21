using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject objTextBox;
    public GameObject progressTextBox;
    public Text texts;
    public Text objText;
    public Text progressText;
    public string[] dialogues;
    public string[] objectives;
    public GameObject[] arrows;
    public int index;
    tutorTrigger tTrigger;
    boxStat bStat;
    public int stainCount;
    bucketTrigger bucket;
    checkTrigger check;
    cook ck;
    cookManager cManager;
    fireTrigger fTrigger;
    DrinkID drinkCS;
    checkice checkIce;
    PickUpClass pick;
    orderStat oStat;
    shakerTrigger scs;
    sealerController sControl;
    public bool served;
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject diaBox;
    public int[] IDs;
    public int caiID;
    public GameObject[] cai;
    public AudioSource finishSrc;

    // Start is called before the first frame update
    void Start()
    {
        progressTextBox.SetActive(false);
        block1.SetActive(true);
        block2.SetActive(true);
        block3.SetActive(true);
        texts = textBox.GetComponent<Text>();
        objText = objTextBox.GetComponent<Text>();
        progressText = progressTextBox.GetComponent<Text>();
        bucket = FindObjectOfType<bucketTrigger>();
        check = FindObjectOfType<checkTrigger>();
        cManager = FindObjectOfType<cookManager>();
        ck = FindObjectOfType<cook>();
        fTrigger = FindObjectOfType<fireTrigger>();
        drinkCS = FindObjectOfType<DrinkID>();
        checkIce = FindObjectOfType<checkice>();
        pick = FindObjectOfType<PickUpClass>();
        scs = FindObjectOfType<shakerTrigger>();
        sControl = FindObjectOfType<sealerController>();
        stainCount = 0;
        caiID = 0;
        ChangeCai();


    }
    public void HideCai()
    {
        for (int i = 0; i < 4; i++)
        {
            cai[i].SetActive(false);
        }
    }
    public void HldeBlock()
    {
        block1.SetActive(false);
        block2.SetActive(false);
    }
    public void HideTutorial()
    {
        diaBox.SetActive(false);
        HideCai();
    }
    public void ChangeCai()
    {

        for (int i = 0; i < 4; i++)
        {
            cai[i].SetActive(false);
        }
        cai[caiID].SetActive(true);
    }
    public void ChangeID()
    {
        caiID = IDs[index + 1];
        finishSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            if (i == index)
            {
                texts.text = dialogues[i];
                objText.text = objectives[i];
                arrows[i].SetActive(true);
            }
            else
            {
                arrows[i].SetActive(false);
            }
        }
        if(index == 0)
        {
            tTrigger = arrows[index].gameObject.transform.GetChild(0).GetComponent<tutorTrigger>();
            if (tTrigger.triggered == true)
            {
                ChangeID();
                index++;
                ChangeCai();

            }
        }
        else if(index == 1)
        {
            tTrigger = arrows[index].gameObject.transform.GetChild(0).GetComponent<tutorTrigger>();
            if (tTrigger.triggered == true)
            {
                ChangeID();
                index++;
                ChangeCai();
            }
        }
        else if(index == 2)
        {
            tTrigger = arrows[index].gameObject.transform.GetChild(0).GetComponent<tutorTrigger>();
            if (tTrigger.triggered == true)
            {
                ChangeID();
                index++;
                ChangeCai();
            }
        }
        else if(index == 3)
        {
            bStat = FindObjectOfType<boxStat>();
            if(bStat.quantities[1] > 0 && bStat.quantities[3] > 0 && bStat.quantities[5] > 0)
            {
                ChangeID();
                index++;
                ChangeCai();
            }
        }
        else if(index == 4)
        {
            if (GameObject.Find("sealedBox(Clone)"))
            {
                ChangeID();
                index++;
                ChangeCai();
                block1.SetActive(false);

            }
        }
        else if(index == 5)
        {
            tTrigger = arrows[index].gameObject.transform.GetChild(0).GetComponent<tutorTrigger>();
            if (tTrigger.triggered == true)
            {
                ChangeID();
                index++;
                ChangeCai();
                progressTextBox.SetActive(true);

            }
        }
        else if(index == 6)
        {
            progressText.text = stainCount + " /  6";
            if (stainCount >= 6)
            {
                ChangeID();
                index++;
                ChangeCai();

            }
        }
        else if(index == 7)
        {
            progressText.text = bucket.ml + " /  1000";
            if (bucket.ml >= 1000)
            {
                ChangeID();
                index++;
                ChangeCai();
                progressTextBox.SetActive(false);
            }
        }
        else if(index == 8)
        {
            if (bucket.ml <= 0)
            {
                index = 7;
            }
            if (check.gTea == true)
            {
                ChangeID();
                index++;
                block3.SetActive(false);
                ChangeCai();

            }
        }
        else if(index == 9)
        {
            if (bucket.ml <= 0)
            {
                index = 7;
            }
            if (ck.isCooking == true || drinkCS.gTeaLeft > 900)
            {
                ChangeID();
                index++;
                ChangeCai();

            }
        }
        else if(index == 10)
        {
            if (bucket.ml <= 0)
            {
                index = 7;
            }
            if (bStat.quantities[4] > 0 && bStat.quantities[6] > 0)
            {
                ChangeID();
                index++;
                ChangeCai();


            }
        }
        else if(index == 11)
        {

            if (cManager.done == true || drinkCS.gTeaLeft > 900)
            {
                ChangeID();
                index++;
                ChangeCai();



            }

        }
        else if(index == 12)
        {

            if (drinkCS.gTeaLeft > 900)
            {
                ChangeID();
                index++;
                ChangeCai();
                block2.SetActive(false);

            }
            if (bucket.ml <= 0 && drinkCS.gTeaLeft <= 900)
            {
                index = 7;
            }
        }
        else if(index == 13)
        {
            if(checkIce.business == true)
            {
                block2.SetActive(true);
                ChangeID();
                index++;
                ChangeCai();

            }
        }
        else if(index == 14)
        {
            if (GameObject.Find("orderPaper(Clone)") == true || served == true)
            {
                ChangeID();
                oStat = GameObject.Find("orderPaper(Clone)").GetComponent<orderStat>();
                index++;
                ChangeCai();
            }
        }
        else if(index == 15)
        {
            if(pick.colliderName == "shaker" || served == true)
            {
                ChangeID();
                index++;
                ChangeCai();
                progressTextBox.SetActive(true);

            }
        }
        else if(index == 16)
        {
            progressText.text = scs.iceg + " / " + oStat.iceAmount * 20 + "g";
            if (scs.sIceAmount == oStat.iceAmount || served == true)
            {
                ChangeID();
                index++;
                ChangeCai();

            }
        }
        else if(index == 17)
        {
            progressText.text = scs.sSugarAmount * 5 + " / " + oStat.sugarAmount * 5 + "g";
            if (scs.sSugarAmount == oStat.sugarAmount || served == true)
            {
                ChangeID();
                index++;
                ChangeCai();

            }
        }
        else if (index == 18)
        {
            progressText.text = (scs.Bml + scs.Gml + scs.Mml) + " / 300ml";
            if (scs.Bml + scs.Gml + scs.Mml >= 300 && scs.teaID == oStat.teaID || served == true)
            {
                ChangeID();
                index++;
                ChangeCai();

            }
        }
        else if(index == 19)
        {
            progressText.text = scs.shake + " / 10";
            if (scs.shake >= 10 || served == true)
            {
                ChangeID();
                index++;
                ChangeCai();
                progressTextBox.SetActive(false);
            }
        }
        else if(index == 20)
        {
            if (GameObject.Find("cup(Clone)") == true || served == true)
            {
                ChangeID();
                index++;
                ChangeCai();
            }
        }
        else if(index == 21)
        {
            if (scs.transfered == true || served == true)
            {
                ChangeID();
                index++;
                ChangeCai();
            }
        }
        else if(index == 22)
        {
            if(sControl.isSealed == true || served == true)
            {
                ChangeID();
                index++;
                ChangeCai();
            }
        }
        else if(index == 23)
        {
            if(served == true)
            {
                ChangeID();
                index++;
                ChangeCai();
            }
        }
        else if(index == 24)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                block2.SetActive(false);
                ChangeID();
                index++;
                ChangeCai();
                Invoke("HideTutorial", 10f);

            }
        }
        else if(index == 25)
        {

        }
    }
}
