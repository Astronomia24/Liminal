using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoopAnim : MonoBehaviour
{
    public bool isScoop;
    Animator anim;
    public MeshRenderer skin;
    public bool played;
    public bool ani;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isScoop == true && Input.GetKey(KeyCode.E))
        {
            if (played == false)
            {
                //skin.enabled = false;
                anim.SetBool("isScooping", true);
                played = true;
                Invoke("Show", 0.7f);
            }

        }
        if(isScoop == false)
        {
            anim.SetBool("isScooping", false);
            played = false;
        }
    }
    public void Show()
    {
        //skin.enabled = true;

    }

}
