using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger3 : MonoBehaviour
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
                tut.msnText.text = "I recommend shaking the drink with the shaker cup, THEN you pour it into the plastic one. ";
                StartCoroutine(tut.Msn());
                trigged = 1;
            }

        }
    }
}
