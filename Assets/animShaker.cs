using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animShaker : MonoBehaviour
{
    PickUpClass pick;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();

        if(pick.shakerPour == false)
        {
            anim.SetBool("pouring", false);
        }
        if(pick.shakerPour == true)
        {
            anim.SetBool("pouring", true);
        }
    }
}
