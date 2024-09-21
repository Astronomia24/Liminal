using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mopTrigger : MonoBehaviour
{
    public AudioSource src;
    public AudioClip[] sfx;
    public Animator anim;
    public GameObject mop;
    Controller c;
    public int ID;

    // Start is called before the first frame update
    void Start()
    {

        c = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "stain")
        {
            ID = Random.Range(1, 5);
                c.walkSpeed = 5;
                Destroy(other.gameObject);
                src.clip = sfx[ID];
                src.Play();
                

        }
        if (other.gameObject.name == "bob(Clone)")
        {
            ID = Random.Range(1, 5);
            c.walkSpeed = 5;
                Destroy(other.gameObject);
            src.clip = sfx[ID];
            src.Play();

        }
    }

}
