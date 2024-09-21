using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger2 : MonoBehaviour
{
    public int trigged;
    tutorial tut;

    // Start is called before the first frame update
    void Start()
    {
        trigged = 0;
        tut = FindObjectOfType<tutorial>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (trigged == 0)
            {
                tut.msnText.text = "Well, I Believe there's a better way to get into your new shop. Use the button E to interact btw.";
                StartCoroutine(tut.Msn());
                trigged = 1;
            }

        }
    }
}
