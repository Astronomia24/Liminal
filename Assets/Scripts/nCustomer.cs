using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nCustomer : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform customerTransform;
    public Transform cPoint;
    public Vector3 position;
    public GameObject comingPoint;
    public GameObject leavePoint;
    public int orderable;
    public int sec;
    Animator anim;
    public bool isid;
    public GameObject walking;
    public GameObject checkbox;
    Rigidbody rb;
    public int isgood;
    dayNightController d;


    // Start is called before the first frame update
    void Start()
    {
        customerTransform = GetComponent<Transform>();
        cPoint = comingPoint.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = walking.GetComponent<Animator>();
        d = FindObjectOfType<dayNightController>();
        leave();
        isid = false;
        isgood = 1;




    }

    // Update is called once per frame
    void Update()
    {
        position = customerTransform.position;
        
        


        if (cPoint.position.x == position.x && cPoint.position.z == position.z)
        {
            orderable = 1;
        }
        else
        {
            if (isgood == 1)
            {
                orderable = 0;
            }
        }
        if(orderable == 1)
        {
            checkbox.SetActive(true);
            isid = true;

        }
        if(orderable == 0)
        {
            checkbox.SetActive(false);
            isid = false;
        }
        if(isid == false)
        {
            anim.SetBool("isidle", false);
        }
        if (isid == true)
        {
            anim.SetBool("isidle", true);
        }




    }
    public void OnColliderEnter(Collider collider)
    {
        rb = collider.gameObject.GetComponent<Rigidbody>();



        {
            Debug.Log("Ouch");
        }
    }




    public void leave()
    {

            StartCoroutine(Leaving());

    }
    public void come()
    {

            StartCoroutine(Coming());

    }

    IEnumerator Coming()
    {
        sec = Random.Range(10, 15);
        yield return new WaitForSeconds(sec);
        agent.SetDestination(comingPoint.transform.position);

    }
    IEnumerator Leaving()
    {
        yield return new WaitForSeconds(4);
        agent.SetDestination(leavePoint.transform.position);

        yield return new WaitForSeconds(10);
        if (d.timeOfDay > 8f && d.timeOfDay < 20.5f)
        {
            come();
        }
        else
        {
            leave();
        }





    }

}
