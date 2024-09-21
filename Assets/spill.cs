using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spill : MonoBehaviour
{
    public float RotationX;
    public float RotationZ;
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.eulerAngles.x <= 180f)
        {
            RotationX = gameObject.transform.eulerAngles.x;
        }
        else
        {
            RotationX = gameObject.transform.eulerAngles.x - 360f;
        }




        if (gameObject.transform.eulerAngles.z <= 180f)
        {
            RotationZ = gameObject.transform.eulerAngles.z;
        }
        else
        {
            RotationZ = gameObject.transform.eulerAngles.z - 360f;
        }
        if(RotationX > 0)
        {

            particle.SetActive(true);
        }
        else
        {
            particle.SetActive(false);

        }
    }
}
