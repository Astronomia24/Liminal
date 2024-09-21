using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nCheckServe : MonoBehaviour
{
    nOrder n;
    public GameObject Cup;

    // Start is called before the first frame update
    void Start()
    {
        n = FindObjectOfType<nOrder>();
        Cup.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag  == "cup")
        {
            n.Check();

            
        }
        if(other.name == "straw(Clone)")
        {
            Destroy(other.gameObject);
        }
    }
}
