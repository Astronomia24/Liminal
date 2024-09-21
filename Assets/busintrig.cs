using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busintrig : MonoBehaviour
{
    businessController bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = FindObjectOfType<businessController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            bc.Not();
        }
    }
}
