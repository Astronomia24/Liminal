using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opengate2 : MonoBehaviour
{
    public int isOpen;
    public Animator anim;
    public AudioSource src;
    public AudioClip sfx;
    public int played;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = 0;
        played = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == 1)
        {


            anim.SetBool("isOp", true);


        }
        if (isOpen == 0)
        {

            anim.SetBool("isOp", false);


        }
    }
}
