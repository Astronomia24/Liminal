using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger1 : MonoBehaviour
{
    public int trigged;
    tutorial tut;
    public GameObject trigger2;
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
        if(other.tag == "Player")
        {
            if (trigged == 0)
            {
                trigger2.SetActive(false);
                tut.msnText.text = "Time to take orders and fill those cups. The button E can do basically anything for you.";
                StartCoroutine(tut.Msn());
                trigged = 1;
            }

        }
    }
}
