using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookTrigger : MonoBehaviour
{
    public bool cookable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
  
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "teaBucket")
        {
            cookable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "teaBucket")
        {
            cookable = false;
        }
    }
}
