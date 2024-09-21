using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class quener : MonoBehaviour
{
    NavMeshAgent agent;
    public queneStat qStat;
    private int timer;
    public int number;
    public bool isQuening;
    public bool isRoaming;
    public bool isWaiting;
    private bool checking;
    private int randomX;
    private int randomZ;
    private Transform waitPos;
    public GameObject e1;
    public GameObject e2;
    public GameObject e3;
    public bool isTiming;
    public float timeLeft;
    public DrinkID drinkCS;
    Animator anim;
    public bool isWalking;
    public bool arrived;
    public Vector3 destination;
    public float distance;
    public Coroutine lastRoutine;
    checkice ci;






    // Start is called before the first frame update
    void Start()
    {
        arrived = true;
        number = Random.Range(5, 9);
        isRoaming = false;
        isQuening = false;
        isWaiting = false;
        timer = Random.Range(40, 150);
        drinkCS = FindObjectOfType<DrinkID>();
        agent = GetComponent<NavMeshAgent>();
        qStat = GameObject.Find("line").GetComponent<queneStat>();
        anim = gameObject.transform.GetChild(3).gameObject.GetComponent<Animator>();
        ci = FindObjectOfType<checkice>();

        waitPos = GameObject.Find("waitPos").transform;
        number = 9;

        e1 = gameObject.transform.GetChild(0).gameObject;
        e2 = gameObject.transform.GetChild(1).gameObject;
        e3 = gameObject.transform.GetChild(2).gameObject;
        e1.SetActive(false);
        e2.SetActive(false);
        e3.SetActive(false);
        isTiming = false;
        timeLeft = 999f;
        lastRoutine = null;





    }
    public void Reset()
    {
        isWalking = true;
        isRoaming = false;
        e1.SetActive(false);
        e2.SetActive(false);
        e3.SetActive(false);
        if (lastRoutine != null)
        {
            StopAllCoroutines();
        }
        timeLeft = 150f;

    }

    public void Roam()
    {
        if (isQuening == false && isRoaming == false && isWaiting == false && isTiming == false)
        {
            timer = Random.Range(40, 150);

            timeLeft = 150f;
            e1.SetActive(false);
            e2.SetActive(false);
            e3.SetActive(false);
            randomX = Random.Range(9, 25);
            randomZ = Random.Range(-23, 23);
            agent.SetDestination(new Vector3(randomX, gameObject.transform.position.y, randomZ));
            isWalking = true;



            Invoke("Reset", 5f);
            if(qStat.status[1] == false && ci.business == true)
            {
                Invoke("LineUp", timer);
            }

        }
    }
    void LineUp()
    {
        Debug.Log("qqqq");
        if (qStat.status[9] == false && ci.business == true)
        {

            isRoaming = false;
            isQuening = true;
            Check();
            StartTiming();

        }
    }
    void StopWalk()
    {
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isQuening == false && isRoaming == false && isWaiting == false)
        {
            Roam();
            isRoaming = true;
        }
        if (checking == false && isQuening == true && isRoaming == false && isWaiting == false)
        {
            Invoke("Check", 1f);
            checking = true;
        }
        if(isWalking == true)
        {
            anim.SetBool("isWalk", true);
        }
        if(isWalking == false)
        {
            anim.SetBool("isWalk", false);
        }
        if(ci.business == false && isQuening == true)
        {
            drinkCS.credit -= 10;
            qStat.status[number] = false;
            isTiming = false;
            isQuening = false;
            isRoaming = false;
            isWaiting = false;
            e1.SetActive(false);
            e2.SetActive(false);
            e3.SetActive(false);
            number = 9;
            Reset();
            Roam();
            StopAllCoroutines();
        }







    }
    public void StartTiming()
    {
        if (isTiming == false)
        {
            timeLeft = 300f;
            StopAllCoroutines();
            StartCoroutine(Timing());
            isTiming = true;
        }

    }
    public IEnumerator Timing()
    {
        while (timeLeft > 0 && ci.business == true)
        {
            timeLeft -= 1;
            yield return new WaitForSeconds(1);
            if(timeLeft > 100 && isRoaming == false)
            {
                e1.SetActive(true);
                e2.SetActive(false);
                e3.SetActive(false);
            }
            if (timeLeft < 100 && timeLeft > 40 && isRoaming == false)
            {
                e1.SetActive(false);
                e2.SetActive(true);
                e3.SetActive(false);
            }
            if (timeLeft < 40 && timeLeft > 0 && isRoaming == false)
            {
                e1.SetActive(false);
                e2.SetActive(false);
                e3.SetActive(true);
            }

            if (timeLeft <= 0)
            {
                drinkCS.credit -= 10;
                qStat.status[number] = false;
                isTiming = false;
                isQuening = false;
                isRoaming = false;
                isWaiting = false;
                e1.SetActive(false);
                e2.SetActive(false);
                e3.SetActive(false);
                number = 9;
                Reset();
                StopAllCoroutines();

            }
        }
    }

    void Check()
    {

        {
            for (int i = 9; i >= 0; i--)
            {

                if (qStat.status[i] == false && i <= number && i == number-1 && isQuening == true)
                {

                    qStat.status[number] = false;
                    number = i;
                    qStat.status[number] = true;
                    agent.SetDestination(qStat.slots[i].transform.position);
                    isWalking = true;
                    Invoke("StopWalk", 1f);

                    break;
                }

            }
            checking = false;
        }
    }

    public void kill()
    {
        if (number == 0)
        {
            timeLeft = 300f;
            qStat.status[number] = false;
            isQuening = false;
            isWaiting = true;
            agent.SetDestination(waitPos.position);
            isWalking = true;
            Invoke("StopWalk", 2f);

        }
        
    }


}
