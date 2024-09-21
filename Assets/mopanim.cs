using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mopanim : MonoBehaviour
{
    public bool isMopping;
    public Animator anim;
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
            if (Input.GetMouseButton(0))
            {
                if (pick.colliderName == "mop")
                    isMopping = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (pick.colliderName == "mop")
                    isMopping = false;
            }
            if (isMopping == true)
            {
                if (pick.colliderName == "mop")
                    anim.SetBool("moping", true);
            }
            if (isMopping == false)
            {
                if (pick.colliderName == "mop")
                    anim.SetBool("moping", false);
            }
    }

}
