using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrigger : MonoBehaviour
{


    public AudioSource src;
    public AudioClip[] sfx;
    public int ID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        ID = Random.Range(1, 5);
        if (other.gameObject.layer == 3)
        {
            Debug.Log("Water");
            src.clip = sfx[ID];
            src.Play();
        }
    }
}
