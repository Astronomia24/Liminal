using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUT1 : MonoBehaviour
{
    tutot tutot;
    // Start is called before the first frame update
    void Start()
    {
        tutot = FindObjectOfType<tutot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (tutot.num == 0)
            {
                tutot.Start2();
                Destroy(gameObject);
            }
        }
    }
}
