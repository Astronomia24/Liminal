using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakerAnim : MonoBehaviour
{
    public Animator anim;
    public bool pouring;
    public bool played;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pouring == true && played == false)
        {
            anim.SetBool("isPouring", true);
            played = true;
        }
        if(pouring == false)
        {
            anim.SetBool("isPouring", false);
            played = false;
        }
        
    }
}
