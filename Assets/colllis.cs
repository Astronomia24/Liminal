using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colllis : MonoBehaviour
{
    public AudioSource src;
    public AudioClip[] sfx;
    public int ID;
    PickUpClass pick;
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
    }
    

    void OnCollisionEnter(Collision collision)
    {
        ID = Random.Range(1, 5);

        if (collision.relativeVelocity.magnitude > 3 && pick.colliderName != gameObject.name && collision.gameObject.name != "Player")
        {
            src.clip = sfx[ID];
            src.Play();

        }
        else if(collision.relativeVelocity.magnitude > 1.7f && pick.colliderName != gameObject.name && collision.gameObject.name != "Player")
        {
            src.clip = sfx[2];
            src.Play();
        }



    }
}
