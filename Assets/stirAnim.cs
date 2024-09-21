using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stirAnim : MonoBehaviour
{
    public bool isStir;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isStir == true)
        {
            anim.SetBool("isStiring", true);
        }
        else if(isStir == false)
        {
            anim.SetBool("isStiring", false);
        }
    }
}
