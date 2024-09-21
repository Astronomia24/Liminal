using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        exed = false;
    }
    public GameObject fire;
    public bool exed;

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "fire")
        {
            fire.SetActive(false);
            exed = true;
        }
    }
    public void PutOut()
    {
        fire.SetActive(false);
        exed = true;
    }
}
