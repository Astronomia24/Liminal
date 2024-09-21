using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucketAnim : MonoBehaviour
{
    Animator anim;
    PickUpClass pick;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pick = FindObjectOfType<PickUpClass>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pick.bucketPour == true)
        {
            anim.SetBool("isPouring", true);
        }
        if(pick.bucketPour == false)
        {
            anim.SetBool("isPouring", false);
        }
    }
}
