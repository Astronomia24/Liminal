using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detach : MonoBehaviour
{
    nBtea nb;
    public GameObject splat;
    // Start is called before the first frame update
    void Start()
    {
        nb = FindObjectOfType<nBtea>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nb.isSplashed == 1)
        {
            splat.transform.DetachChildren();
        }
    }
}
