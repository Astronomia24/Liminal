using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public GameObject footStep;
    public int isWalking;
    Rigidbody rb;
    public int walk;




    // Start is called before the first frame update
    void Start()
    {
        walk = 0;
        footStep.SetActive(false);
        isWalking = 0;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(rb.velocity.x) > 3 || Mathf.Abs(rb.velocity.z) > 3)
        {
            isWalking = 1;
            StartFootStep();
        }
        else
        {

            isWalking = 0;
            StopFootStep();
        }



    }

    public void StartFootStep()
    {
        if (walk == 0)
        {
            footStep.SetActive(true);
            walk = 1;
        }

    }
    public void StopFootStep()
    {
        if (walk == 1)
        {
            footStep.SetActive(false);
            walk = 0;
        }
    }
}
