using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorTrigger : MonoBehaviour
{
    public bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggered = true;
        }
    }
}
