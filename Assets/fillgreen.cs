using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillgreen : MonoBehaviour
{
    checkice ci;
    // Start is called before the first frame update
    void Start()
    {
        ci = FindObjectOfType<checkice>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "teaBucket")
        {
            ci.Green();
        }
    }
}
