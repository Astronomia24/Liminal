using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkOpen : MonoBehaviour
{
    public bool isOpen;
    private GameObject closeBag;
    private GameObject openBag;
    public bool opened;
    public float RotationX;
    public float RotationZ;
    public Transform cupTransform;
    public Transform dropTransform;
    public bool haveTea;
    public GameObject leaf;
    private GameObject bbs;

    // Start is called before the first frame update
    void Start()
    {
        opened = false;
        isOpen = false;
        closeBag = gameObject.transform.GetChild(0).gameObject;
        openBag = gameObject.transform.GetChild(1).gameObject;
        dropTransform = gameObject.transform.GetChild(2).gameObject.transform;
        if (gameObject.name == "bobabag(Clone)")
        {
            bbs = gameObject.transform.GetChild(3).gameObject;
        }
        cupTransform = gameObject.transform;
        closeBag.SetActive(true);
        openBag.SetActive(false);
        haveTea = true;
        if(gameObject.name == "bobabag(Clone)" && bbs != null)
        {
            bbs.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen == true && opened == false)
        {
            closeBag.SetActive(false);
            openBag.SetActive(true);
            opened = true;
        }
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
            if (opened == true && haveTea == true)
            {
                Instantiate(leaf, dropTransform.position, Quaternion.identity);
                haveTea = false;
                if (gameObject.name == "bobabag(Clone)" && bbs != null)
                {
                    bbs.SetActive(false);
                }




            }
        }
    }
    public void Open()
    {
        isOpen = true;
    }
}
