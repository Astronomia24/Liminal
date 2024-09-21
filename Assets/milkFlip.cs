using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milkFlip : MonoBehaviour
{
    public float RotationX;
    public float RotationZ;
    public Transform cupTransform;
    public Transform dropTransform;
    public Transform lidtrans;
    public bool haveMilk;
    public bool isOpen;
    public GameObject lid;
    public GameObject dropLid;
    public GameObject fallMilk;
    public int ml;
    public GameObject milkstick;
    public ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        haveMilk = true;
        isOpen = false;
        cupTransform = gameObject.transform;
        dropLid = GameObject.Find("droplid");
        ml = 300;
        milkstick = gameObject.transform.GetChild(4).gameObject;
        part = milkstick.GetComponent<ParticleSystem>();
        milkstick.SetActive(false);
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
            if(isOpen == true && haveMilk == true)
            {
                Invoke("pouring", 0.1f);
                if(ml > 0)
                {
                    milkstick.SetActive(true);
                }
                else
                {
                    milkstick.SetActive(false);
                }
            }

        }
        else
        {
            milkstick.SetActive(false);
        }
    }
    public void Open()
    {
        isOpen = true;
        lid = gameObject.transform.GetChild(0).gameObject;
        dropTransform = gameObject.transform.GetChild(2).gameObject.transform;
        Instantiate(dropLid, lidtrans.position, Quaternion.identity);

        lid.SetActive(false);

    }
    public void pouring()
    {
        ml -= 1;
    }
}
