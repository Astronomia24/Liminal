using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreshaker : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PickUp");
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());

    }

    // Update is called once per frame
    void Update()
    {

    }

}
