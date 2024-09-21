using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sealerTrigger : MonoBehaviour
{
    sealerController scon;
    nBtea nb;
    tutorControl tut;
    PickUpClass pick;
    cupStats stats;
    // Start is called before the first frame update
    void Start()
    {
        scon = FindObjectOfType<sealerController>();
        nb = FindObjectOfType<nBtea>();
        tut = FindObjectOfType<tutorControl>();
        pick = FindObjectOfType<PickUpClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        stats = other.gameObject.GetComponent<cupStats>();
        if(other.gameObject.name == "cup(Clone)" && stats.isSealed == 0 && pick.colliderName != "cup(Clone)" && scon.cup == null)
        {
            scon.cup = other.gameObject;
            scon.StartSealing();
            if(tut.step == 7)
            {
                tut.step = 8;
            }

        }
    }
    
}
