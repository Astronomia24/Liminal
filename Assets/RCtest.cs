using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCtest : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name + " hit by the ray!");
        }
    }
}
