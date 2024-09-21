using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godtone : MonoBehaviour
{
    public AudioSource ad;
    Animator anim;
    public int isD;
    // Start is called before the first frame update
    void Start()
    {
        isD = 0;
        ad = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isD == 1)
        {


            anim.SetBool("isDancing", true);

        }
        if (isD == 0)
        {

            anim.SetBool("isDancing", false);
        }
    }
    
}
