using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenTrigger : MonoBehaviour
{
    shakerTrigger scs;
    nBtea nb;
    bucketTrigger bt;


    // Start is called before the first frame update
    void Start()
    {
        scs = FindObjectOfType<shakerTrigger>();
        nb = FindObjectOfType<nBtea>();
        bt = FindObjectOfType<bucketTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "shaker")
        {
            scs.FillG();
        }
        if (other.gameObject.name == "nCup")
        {
            nb.FillG();
        }


    }

}
