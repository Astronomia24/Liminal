using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inHandCupShake : MonoBehaviour
{
    Animator animator;
    DrinkID drinkCS;
    public bool isShaking;
    public GameObject sugar;
    


    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isShaking = true;

        }
        else
        {
            isShaking = false;
        }

        if(isShaking == true)
        {
            animator.SetBool("isShaking", true);
            drinkCS.shake += 1;

        }
        if(isShaking == false)
        {
            animator.SetBool("isShaking", false);
        }
        if(drinkCS.shake >= 5)
        {
            sugar.SetActive(false);

        }
        else
        {

        }
    }
}
