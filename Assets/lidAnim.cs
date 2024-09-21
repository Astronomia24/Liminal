using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lidAnim : MonoBehaviour
{
    shakerTrigger scs;
    Animator anim;
    public bool isCovered;
    







    // Start is called before the first frame update
    void Start()
    {
        scs = FindObjectOfType<shakerTrigger>();
        anim = GetComponent<Animator>();
        isCovered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(scs.lidBool == true)
        {
            if(isCovered == false)
            {
                anim.SetBool("isClosed", true);
                anim.SetBool("covered", true);
                isCovered = true;
            }
        }
        if (scs.lidBool == false)
        {
            if(isCovered == true)
            {
                anim.SetBool("isClosed", false);
                anim.SetBool("covered", false);
                isCovered = false;
            }

        }


        if(scs.finished == true)
        {
            anim.SetBool("finish", true);
            scs.finished = false;
        }
    }
}
