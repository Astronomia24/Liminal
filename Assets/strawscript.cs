using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawscript : MonoBehaviour
{
    public GameObject straww;
    public GameObject strawplace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetStraw()
    {
        Instantiate(straww, strawplace.transform.position, Quaternion.identity) ;
    }
}
