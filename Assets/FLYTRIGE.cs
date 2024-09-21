using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLYTRIGE : MonoBehaviour
{
    public int placeable;

    public GameObject flyer;

    // Start is called before the first frame update
    void Start()
    {
        placeable = 0;


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        placeable = 1;


    }
    void OnTriggerExit(Collider other)
    {
        placeable = 0;


    }
}
