using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humnatirgg : MonoBehaviour
{
    objControl obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = FindObjectOfType<objControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "tbag1(Clone)" || other.gameObject.name == "tbag2" || other.gameObject.name == "tbag3")
        {
            Destroy(other.gameObject);
            if(obj.stain < 6)
            {
                obj.stain += 1;
            }

        }
    }
}
