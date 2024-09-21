using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comeTrigger : MonoBehaviour
{
    public Animator anim;
    public bool walking;
    customerManager cm;

    // Start is called before the first frame update
    void Start()
    {
        walking = true;
        cm = FindObjectOfType<customerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(walking == true)
        {
            cm.customers[0].name = "ped";
            anim.SetBool("isWalk", true);
        }
        if (walking == false)
        {
            cm.customers[0].name = "Customer";
            anim.SetBool("isWalk", false);
        }
    }



}
