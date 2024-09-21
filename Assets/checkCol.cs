using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCol : MonoBehaviour
{
    public bool coll;
    public GameObject colli;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        coll = true;
        colli = col.gameObject;
    }

    void OnCollisionExit(Collision col)
    {
        coll = false;
    }

}
