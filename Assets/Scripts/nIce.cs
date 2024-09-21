using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nIce : MonoBehaviour
{
    PickUpClass pick;
    public GameObject cup;
    public GameObject cupTrigger;

    public float RotationX ;
    public float RotationY ;
    public float RotationZ;

    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pick.colliderName == "nCup")
        {


        }
        else
        {

        }

    }

    public void Ice()
    {
        if (pick.colliderName == "nCup")
        {


        }




    }
}
