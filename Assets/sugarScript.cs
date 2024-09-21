using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sugarScript : MonoBehaviour
{
    public GameObject sugarCup;
    public GameObject sugarTrigger;
    public GameObject splash;
    public Transform cupTransform;
    public float RotationX;
    public float RotationZ;
    public AudioSource src;
    public AudioClip sfx;
    public int splashed;
    public int sugarCount;
    public Transform stransform;
    Vector3 stpos;
    public GameObject sugar1;
    public GameObject sugar2;
    public GameObject sugar3;
    stainList sList;
    public GameObject currentStain;


    // Start is called before the first frame update
    void Start()
    {
        sugarTrigger.SetActive(true);
        splashed = 0;
        sugarCount = 10;
        sList = FindObjectOfType<stainList>();

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
        if (sugarCount == 0)
        {
            sugarTrigger.SetActive(false);
        }
        else if(sugarCount > 2 && sugarCount < 5)
        {
            sugar1.SetActive(false);
            sugar2.SetActive(false);
            sugar3.SetActive(true);
        }
        else if (sugarCount > 5 && sugarCount < 8)
        {
            sugar1.SetActive(false);
            sugar2.SetActive(true);
            sugar3.SetActive(false);
        }
        else if (sugarCount > 8 && sugarCount < 11)
        {
            sugar1.SetActive(true);
            sugar2.SetActive(false);
            sugar3.SetActive(false);
        }




        if (cupTransform.eulerAngles.z <= 180f)
        {
            RotationZ = cupTransform.eulerAngles.z;
        }
        else
        {
            RotationZ = cupTransform.eulerAngles.z - 360f;
        }
        if (RotationZ >= 89f || RotationZ <= -89f)
        {


            if (sugarCount > 0)
            {
                sugarCount = 0;
                stpos = new Vector3(sugarTrigger.transform.position.x, sugarTrigger.transform.position.y, sugarTrigger.transform.position.z);
                sugarTrigger.SetActive(false);
                src.clip = sfx;
                src.Play();
                currentStain = Instantiate(splash, stpos, Quaternion.identity);
                sList.stains.Add(currentStain);
            }


        }
    }

}
