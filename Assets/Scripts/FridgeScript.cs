using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    Animator animator;
    public int isOpening;



    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        isOpening = 0;

    }


    void Update()
    {

        if(isOpening == 0)
        {
            animator.SetBool("isOpening", false);






        }

        if(isOpening == 1)
        {
            animator.SetBool("isOpening", true);


        }

    }


}
