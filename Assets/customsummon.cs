using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customsummon : MonoBehaviour
{
    nOrder no;
    nCustomer nc;
    public int isDead;
    public GameObject rag;
    public GameObject cube;
    public GameObject newRag;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        nc = FindObjectOfType<nCustomer>();
        no = FindObjectOfType<nOrder>();
        isDead = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3 && collision.relativeVelocity.magnitude > 5 || collision.gameObject.tag == "Player" && collision.relativeVelocity.magnitude > 7f)
        {
            if(isDead == 0)
            {
                if(nc.orderable == 0)
                {
                    rag.SetActive(true);
                    rag.transform.position = cube.transform.position;
                    newRag = Instantiate(rag, rag.transform.position, rag.transform.rotation);
                    rb = newRag.GetComponentInChildren<Rigidbody>();
                    rag.SetActive(false);
                    gameObject.transform.position = nc.leavePoint.transform.position;
                    nc.leave();

                }
                if(nc.orderable == 1)
                {
                    if (no.isTiming == 0)
                    {
                        no.StartOrder();
                        no.timer = 151;
                        rag.SetActive(true);
                        rag.transform.position = cube.transform.position;
                        newRag = Instantiate(rag, rag.transform.position, rag.transform.rotation);
                        rb = newRag.GetComponentInChildren<Rigidbody>();
                        rag.SetActive(false);
                        gameObject.transform.position = nc.leavePoint.transform.position;
                        nc.leave();
                    }
                    if(no.isTiming == 1)
                    {
                        no.timer = 151;
                        rag.SetActive(true);
                        rag.transform.position = cube.transform.position;
                        newRag = Instantiate(rag, rag.transform.position, rag.transform.rotation);
                        rb = newRag.GetComponentInChildren<Rigidbody>();
                        rag.SetActive(false);
                        gameObject.transform.position = nc.leavePoint.transform.position;
                        nc.leave();
                    }

                }
            }
        }
    }
}
