using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class comeScript : MonoBehaviour
{
    public GameObject comePoint;
    public bool isComing;
    public int comeTime;
    NavMeshAgent agent;
    comeTrigger ct;
    public float distance;
    public bool leave;
    DrinkID drinkCS;
    checkice ci;





    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ct = FindObjectOfType<comeTrigger>();
        drinkCS = FindObjectOfType<DrinkID>();
        ci = FindObjectOfType<checkice>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isComing == false)
        {
            GetComponent<R>().enabled = true;
            comeTime = Random.Range(20, 30);
            //Invoke("StartCome", comeTime);
            isComing = true;
            ct.walking = true;
                
        }
        distance = Vector3.Distance(gameObject.transform.position, comePoint.transform.position);
        if(distance <= 0.5f)
        {
            ct.walking = false;
        }

    }
    public void StartCome()
    {
        if (ci.business == true)
        {
            leave = false;
            GetComponent<R>().enabled = false;
            agent.SetDestination(comePoint.transform.position);
            if (distance > 0.1f)
            {
                ct.walking = true;

            }
        }
        else
        {
            isComing = false;
        }


    }
    public void Leave()
    {
        leave = true;
        GetComponent<R>().enabled = true;
        isComing = false;
        Invoke("Leaving", 2.0f);
        ct.walking = true;

    }
    public void Leaving()
    {
        ct.walking = true;
    }
}
