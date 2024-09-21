using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressAnim : MonoBehaviour
{
    public Animator anim;
    public bool isPress;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPress == true)
        {
            anim.SetBool("pressed", true);
        }
        if(isPress == false)
        {
            anim.SetBool("pressed", false);
        }
    }
    public void SetFalse()
    {
        isPress = false;
    }
}
