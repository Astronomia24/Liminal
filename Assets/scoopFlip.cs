using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoopFlip : MonoBehaviour
{
    public Transform cupTransform;
    newIce nice;
    public GameObject icePile;
    public float RotationX;
    public float RotationZ;
    public GameObject sIce;
    public Transform dropTransform;



    // Start is called before the first frame update
    void Start()
    {
        nice = FindObjectOfType<newIce>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cupTransform.eulerAngles.x <= 180f)
        {
            RotationX = cupTransform.eulerAngles.x;
        }
        else
        {
            RotationX = cupTransform.eulerAngles.x - 360f;
        }




        if (cupTransform.eulerAngles.z <= 180f)
        {
            RotationZ = cupTransform.eulerAngles.z;
        }
        else
        {
            RotationZ = cupTransform.eulerAngles.z - 360f;
        }
        if (RotationX >= 90 || RotationX <= -90 || RotationZ <= -90 || RotationZ >= 90)
        {
            if(nice.haveIce == 1)
            {
                Instantiate(icePile, dropTransform.position, Quaternion.identity);
                nice.haveIce = 0;
                sIce.SetActive(false);

            }
        }
    }
}
