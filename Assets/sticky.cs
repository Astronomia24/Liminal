using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticky : MonoBehaviour
{
    Controller player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && player.walkSpeed != 3)
        {

            player.walkSpeed = 1;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && player.walkSpeed != 3)
        {

            player.walkSpeed = 5;
        }
    }

}
