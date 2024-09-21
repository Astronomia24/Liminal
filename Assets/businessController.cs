using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class businessController : MonoBehaviour
{
    public GameObject btext;
    public Text busintext;
    public GameObject Camera;
    public float RotationX;
    public float RotationY;
    public int yesTime;
    public int yesAmount;
    public int started;
    public int noTime;
    public int noAmount;
    public GameObject flyer;
    public Transform flyerTransform;
    public int flyerAmount;
    public int isUsed;
    DrinkID drinkCS;
    public int isLeave;
    public GameObject notice;






    // Start is called before the first frame update
    void Start()
    {
        notice.SetActive(false);
        isLeave = 1;
        drinkCS = FindObjectOfType<DrinkID>();
        isUsed = 0;
        started = 0;
        yesAmount = 0;
        noAmount = 0;
        flyerAmount = 0;
        btext.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if (started == 1)
        {
            if (Camera.transform.eulerAngles.x <= 180f)
            {
                RotationX = Camera.transform.eulerAngles.x;
            }
            else
            {
                RotationX = Camera.transform.eulerAngles.x - 360f;
            }
            if (Camera.transform.eulerAngles.y <= 180f)
            {
                RotationY = Camera.transform.eulerAngles.y;
            }
            else
            {
                RotationY = Camera.transform.eulerAngles.y - 360f;
            }


            if (RotationX >= 25f)
            {
                yesTime = 1;
            }
            if(RotationX <= -25f)
            {
                if(yesTime == 1)
                {
                    yesAmount += 1;
                    yesTime = 0;
                }
            }
            if (RotationY >= 60f && RotationY < 180f)
            {
                noTime = 1;
            }
            if (RotationY <= -60f && RotationY > -180f)
            {
                if (noTime == 1)
                {
                    noAmount += 1;
                    noTime = 0;
                }
            }
        }



    }
    public void StartBusiness()
    {
        isLeave = 0;
        started = 1;
        yesTime = 0;
        noTime = 0;

        btext.SetActive(true);
        if (isUsed == 0)
        {
            StartCoroutine(StartConvo());
        }
        else if (isUsed == 1)
        {
            StartCoroutine(NewConvo());
        }
            
    }
    IEnumerator StartConvo()
    {
        if (isLeave == 0)
        {
            busintext.text = "您好，我們是淑芬印刷公司，提供最高品質的印刷服務。";
        }
        yield return new WaitForSeconds(3);
        if (isLeave == 0)
        {
            busintext.text = "看到您新開的店，想說您可能會需要印製傳單。";
        }
        yield return new WaitForSeconds(3);
        if (isLeave == 0)
        {
            StartCoroutine(Decision());
        }



    }
    IEnumerator Decision()
    {
        notice.SetActive(true);
        yesAmount = 0;
        noAmount = 0;
        if (isLeave == 0)
        {
            busintext.text = "我們可以提供5個免費樣品，讓您試試效果，您覺得呢?";
        }
        yield return new WaitForSeconds(4);
        if(yesAmount > 2)
        {
            StartCoroutine(Yes());
        }
        else if(noAmount > 5)
        {
            StartCoroutine(No());
        }
        else
        {
            StartCoroutine(Decision());
        }
    }
    IEnumerator No()
    {
        notice.SetActive(false);
        isLeave = 1;
        busintext.text = "好的，如您改變心意，我們隨時歡迎。";
        yield return new WaitForSeconds(3);
        btext.SetActive(false);
        notice.SetActive(false);
        started = 0;
    }
    IEnumerator Yes()
    {
        notice.SetActive(false);
        busintext.text = "太好了，很高興跟您合作。";
        yield return new WaitForSeconds(3);
        busintext.text = "這是您的傳單，您如有需要，請再回來找我。";
        yield return new WaitForSeconds(3);
        isUsed = 1;
        Instantiate(flyer, flyerTransform.position, Quaternion.identity);
        flyerAmount += 5;
        btext.SetActive(false);
        started = 0;

    }
    IEnumerator NewConvo()
    {
        busintext.text = "您好，傳單的成效怎麼樣?";
        yield return new WaitForSeconds(3);
        busintext.text = "如您想再使用我們的服務，5張傳單將會收您200元。";
        yield return new WaitForSeconds(3);

        StartCoroutine(Decision2());
    }
    IEnumerator Decision2()
    {
        notice.SetActive(true);
        yesAmount = 0;
        noAmount = 0;
        busintext.text = "您覺得如何?";
        yield return new WaitForSeconds(4);
        if (yesAmount > 5)
        {
            if (drinkCS.money >= 200)
            {
                StartCoroutine(Yes());
                drinkCS.money -= 200;
            }
            else
            {
                StartCoroutine(Reject());
            }
        }
        else if (noAmount > 5)
        {
            StartCoroutine(No());
        }
        else
        {
            StartCoroutine(Decision2());
        }
    }
    IEnumerator Reject()
    {
        notice.SetActive(false);
        busintext.text = "看來您的資金還不夠。";
        yield return new WaitForSeconds(4);
        busintext.text = "等您有足夠的錢，隨時歡迎您使用我們的服務。";
        yield return new WaitForSeconds(4);
        btext.SetActive(false);
        started = 0;
    }
    public void Not()
    {
        StartCoroutine(No());
    }
}
