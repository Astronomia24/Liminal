using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakerController : MonoBehaviour
{
    public int isCovered;


    PickUpClass pick;
    public AudioSource src;
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void sFillB()
    {
        if(pick.colliderName == "shaker")
        {
            src.clip = sfx;
            src.Play();
        }
    }

}
