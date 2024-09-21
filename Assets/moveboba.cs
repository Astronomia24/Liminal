using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveboba : MonoBehaviour
{
    public Animator anim;
    public bool haveW;
    bucketTrigger bt;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bt = FindObjectOfType<bucketTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(haveW == true)
        {
            anim.SetBool("haveWater", true);
        }    
        if(haveW == false)
        {
            anim.SetBool("haveWater", false);
        }
        if(bt.ml > 0)
        {
            haveW = true;
        }
        else
        {
            haveW = false;
        }
    }
}
