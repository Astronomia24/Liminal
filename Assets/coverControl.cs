using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coverControl : MonoBehaviour
{
    public bool open;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(open == true)
        {
            anim.SetBool("isOpen", true);

        }
        if (open == false)
        {
            anim.SetBool("isOpen", false);
 
        }
    }
}
