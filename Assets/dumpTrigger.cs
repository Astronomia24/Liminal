using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumpTrigger : MonoBehaviour
{
    objControl obj;
    TutorialManager tManager;
    // Start is called before the first frame update
    void Start()
    {
        obj = FindObjectOfType<objControl>();
        tManager = FindObjectOfType<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "tbag(Clone)")
        {
            Destroy(other.gameObject);
            tManager.stainCount += 1;


        }
    }
}
