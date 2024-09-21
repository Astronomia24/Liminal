using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore : MonoBehaviour
{
    PickUpClass pick;
    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (pick.colliderName == "shaker" || pick.colliderName == "scooper (1)" || pick.colliderName == "rag")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
