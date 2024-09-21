using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creamerFlip : MonoBehaviour
{
    public float RotationX;
    public float RotationZ;
    public Transform cupTransform;
    public GameObject dropLid;
    public GameObject lid;
    public bool isOpen;
    public bool haveCream;
    public int ml;
    public GameObject creamStick;
    public Transform dropTransform;

    // Start is called before the first frame update
    void Start()
    {
        cupTransform = gameObject.transform;
        creamStick = gameObject.transform.GetChild(4).gameObject;
        haveCream = true;
        isOpen = false;
        ml = 100;
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
            if(haveCream == true && isOpen == true)
            {
                Invoke("pouring", 0.1f);
                if (ml > 0)
                {
                    creamStick.SetActive(true);
                }
                else
                {
                    creamStick.SetActive(false);
                }
            }


        }
        else
        {
            creamStick.SetActive(false);
        }
    }
    public void Open()
    {
        isOpen = true;
        lid = gameObject.transform.GetChild(0).gameObject;
        dropTransform = gameObject.transform.GetChild(2).gameObject.transform;
        lid.SetActive(false);

    }

    public void pouring()
    {
        ml -= 1;
    }
}
