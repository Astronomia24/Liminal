using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchaFlip : MonoBehaviour
{
    public Transform cupTransform;
    public float RotationX;
    public float RotationZ;
    public int matchaAmount;
    public GameObject[] matchas;
    spoonStat spStat;
    public GameObject powder;
    stainList sList;
    public GameObject currentStain;
    public GameObject part;
    public bool splatted;
    public Transform dropTransform;
    public AudioSource powderSrc;
    // Start is called before the first frame update
    void Start()
    {
        spStat = FindObjectOfType<spoonStat>();
        sList = FindObjectOfType<stainList>();
        spStat.amounts[2] = 10;
        for (int i = 0; i < matchas.Length; i++)
        {
            matchas[i].SetActive(true);
        }
        cupTransform = gameObject.transform;
        part.SetActive(false);
        splatted = false;
    }
    public void hidePart()
    {
        part.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {




        if(spStat.amounts[2] > 0)
        {
            splatted = false;
        }

        if(spStat.amounts[2] >= 6)
        {
            for (int i = 0; i < matchas.Length; i++)
            {
                matchas[i].SetActive(true);
            }
        }
        else if(spStat.amounts[2] < 6 && spStat.amounts[2] >= 3)
        {
            for (int i = 0; i < matchas.Length; i++)
            {
                matchas[i].SetActive(true);
            }
            matchas[2].SetActive(false);
        }
        else if(spStat.amounts[2] < 3 && spStat.amounts[2] > 0)
        {
            for (int i = 0; i < matchas.Length; i++)
            {
                matchas[i].SetActive(true);
            }
            matchas[2].SetActive(false);
            matchas[1].SetActive(false);

        }
        else
        {
            for (int i = 0; i < matchas.Length; i++)
            {
                matchas[i].SetActive(false);
            }
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
            if(spStat.amounts[2] > 0)
            {
                powderSrc.Play();
                currentStain = Instantiate(powder, dropTransform.position, powder.transform.rotation);
                sList.stains.Add(currentStain);
                spStat.amounts[2] = 0;
                if (splatted == false)
                {
                    part.SetActive(true);
                    Invoke("hidePart", 2f);
                    splatted = true;
                }
                for (int i = 0; i < matchas.Length; i++)
                {
                    matchas[i].SetActive(false);
                }


            }
        }
    }
}
