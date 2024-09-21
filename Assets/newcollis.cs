using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class newcollis : MonoBehaviour
{
    public GameObject ped;
    public NavMeshAgent agent;
    public Rigidbody rb;
    nCustomer nc;
    public int isre;
    nOrder no;
    public float rando;
    public GameObject cus;
    // Start is called before the first frame update
    void Start()
    {
        nc = FindObjectOfType<nCustomer>();
        rb = gameObject.GetComponent<Rigidbody>();
        no = FindObjectOfType<nOrder>();
        isre = 0;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 3 && isre == 0)
        {
            rando = Random.Range(-20f, 20f);
            nc.isgood = 0;
            Debug.Log("fuck");
            agent = gameObject.GetComponent<NavMeshAgent>();
            rb.isKinematic = false;
            agent.enabled = false;
            rb.AddForce(collision.gameObject.transform.forward * 10f, ForceMode.Impulse);
            cus.transform.position = new Vector3(9, 0, 26);
            nc.orderable = 1;
            gameObject.layer = 3;
            isre = 1;
            if(no.timer > 0)
            {
                no.timer = 150;
            }
            StartCoroutine(ReCustom());



        }
    }
    IEnumerator ReCustom()
    {

        yield return new WaitForSeconds(5);
        rb.isKinematic = true;
        agent.enabled = true;
        nc.isgood = 1;
        gameObject.layer = 8;
        isre = 0;

    }
}
