using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniSpoon : MonoBehaviour
{
    public bool isSpoon;
    Animator anim;
    public MeshRenderer skin;
    public bool played;
    public GameObject spoon;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = spoon.transform.position;
        if (isSpoon == true && Input.GetKey(KeyCode.E))
        {
            if (played == false)
            {
                //skin.enabled = false;
                anim.SetBool("isSpooning", true);
                played = true;
                Invoke("Show", 0.7f);
            }

        }
        if (isSpoon == false)
        {
            anim.SetBool("isSpooning", false);
            played = false;
        }
    }
    public void Show()
    {
        //skin.enabled = true;

    }
}
