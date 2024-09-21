using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackTrigger : MonoBehaviour
{
    shakerTrigger scs;
    nBtea nb;
    // Start is called before the first frame update
    void Start()
    {
        scs = FindObjectOfType<shakerTrigger>();
        nb = FindObjectOfType<nBtea>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "shaker")
        {
            scs.FillB();
        }
        if (other.gameObject.name == "nCup")
        {
            nb.FillB();
        }
    }
}
