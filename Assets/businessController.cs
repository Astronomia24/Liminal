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
            busintext.text = "�z�n�A�ڭ̬O�Q��L�ꤽ�q�A���ѳ̰��~�誺�L��A�ȡC";
        }
        yield return new WaitForSeconds(3);
        if (isLeave == 0)
        {
            busintext.text = "�ݨ�z�s�}�����A�Q���z�i��|�ݭn�L�s�ǳ�C";
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
            busintext.text = "�ڭ̥i�H����5�ӧK�O�˫~�A���z�ոծĪG�A�zı�o�O?";
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
        busintext.text = "�n���A�p�z���ܤ߷N�A�ڭ��H���w��C";
        yield return new WaitForSeconds(3);
        btext.SetActive(false);
        notice.SetActive(false);
        started = 0;
    }
    IEnumerator Yes()
    {
        notice.SetActive(false);
        busintext.text = "�Ӧn�F�A�ܰ�����z�X�@�C";
        yield return new WaitForSeconds(3);
        busintext.text = "�o�O�z���ǳ�A�z�p���ݭn�A�ЦA�^�ӧ�ڡC";
        yield return new WaitForSeconds(3);
        isUsed = 1;
        Instantiate(flyer, flyerTransform.position, Quaternion.identity);
        flyerAmount += 5;
        btext.SetActive(false);
        started = 0;

    }
    IEnumerator NewConvo()
    {
        busintext.text = "�z�n�A�ǳ檺���ī���?";
        yield return new WaitForSeconds(3);
        busintext.text = "�p�z�Q�A�ϥΧڭ̪��A�ȡA5�i�ǳ�N�|���z200���C";
        yield return new WaitForSeconds(3);

        StartCoroutine(Decision2());
    }
    IEnumerator Decision2()
    {
        notice.SetActive(true);
        yesAmount = 0;
        noAmount = 0;
        busintext.text = "�zı�o�p��?";
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
        busintext.text = "�ݨӱz������٤����C";
        yield return new WaitForSeconds(4);
        busintext.text = "���z�����������A�H���w��z�ϥΧڭ̪��A�ȡC";
        yield return new WaitForSeconds(4);
        btext.SetActive(false);
        started = 0;
    }
    public void Not()
    {
        StartCoroutine(No());
    }
}
