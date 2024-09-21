using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mTrigger : MonoBehaviour
{
    mirrorContoller mc;



    // Start is called before the first frame update
    void Start()
    {
        mc = FindObjectOfType<mirrorContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            mc.MirrorExit();

        }


    }
}
