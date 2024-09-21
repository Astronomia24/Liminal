using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBAflip : MonoBehaviour
{
    public Transform cupTransform;
    public float RotationX;
    public float RotationZ;
    public GameObject fBoba;
    public GameObject bobaTrigger;
    public int trig;
    public int bbAmount;
    public AudioSource src;
    public AudioClip sfx1;

    // Start is called before the first frame update
    void Start()
    {
        trig = 1;
        bbAmount = 10;
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
        if(bbAmount < 1)
        {
            trig = 0;
            bobaTrigger.SetActive(false);
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
            if (trig == 1)
            {
                src.clip = sfx1;
                src.Play();
                bbAmount = 0;
                Instantiate(fBoba, cupTransform.position, fBoba.transform.rotation);
                trig = 0;
                bobaTrigger.SetActive(false);
            }
        }
    }
}
