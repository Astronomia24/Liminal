using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreSpoon : MonoBehaviour
{
    public AudioSource src;
    public AudioClip[] sfx;
    PickUpClass pick;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("cuppy");
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        pick = FindObjectOfType<PickUpClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2 && pick.colliderName != gameObject.name && collision.gameObject.tag != "PickUp")
        {
            ID = Random.Range(1, 5);
            src.clip = sfx[ID];
            src.Play();

        }





    }
}
