using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class servingDetect : MonoBehaviour
{
    public GameObject currentPaper;
    public bool havePaper;
    public bool haveCup;
    public GameObject currentCup;
    public orderStat oStat;
    quener q;
    public orderCheck oCheck;
    public TutorialManager tut;

    // Start is called before the first frame update
    void Start()
    {
        tut = FindObjectOfType<TutorialManager>();
        tut.served = false;

        havePaper = false;
        haveCup = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(haveCup == true && havePaper == true)
        {
            tut.served = true;

            oStat = currentPaper.GetComponent<orderStat>();
            q = oStat.owner.GetComponent<quener>();
            q.isWaiting = false;
            q.number = 9;
            oCheck.CheckDrink();
            q.isTiming = false;
            q.isQuening = false;
            q.isRoaming = false;
            q.Reset();
            q.Roam();
            if (q.lastRoutine != null)
            {
                q.StopAllCoroutines();
            }

            haveCup = false;
            havePaper = false;


        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "orderPaper(Clone)" && havePaper == false)
        {
            havePaper = true;
            currentPaper = other.gameObject;
        }
        if(other.gameObject.name == "cup(Clone)" && haveCup == false)
        {
            haveCup= true;
            currentCup = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "orderPaper(Clone)" && havePaper == true)
        {
            havePaper = false;
            currentPaper = null;
        }
        if (other.gameObject.name == "cup(Clone)" && haveCup == true)
        {
            haveCup = false;
            currentCup = null;
        }
    }
}
