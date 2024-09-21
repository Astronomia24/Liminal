using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sugarFlip : MonoBehaviour
{
    public Transform cupTransform;
    public GameObject sugarPile;
    public GameObject bobaPile;
    public float RotationX;
    public float RotationZ;
    public GameObject spoonSugar;
    public GameObject spoonBoba;
    public Transform dropTransform;
    sCupTrigger nice;
    CupTrigger ccs;
    shakerTrigger scs;
    spoonStat spStat;
    stainList sList;
    public GameObject currentStain;
    public GameObject[] stains;


    // Start is called before the first frame update
    void Start()
    {
        ccs = FindObjectOfType<CupTrigger>();
        scs = FindObjectOfType<shakerTrigger>();
        spStat = FindObjectOfType<spoonStat>();
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
            for (int i = 0; i < spStat.amounts.Length; i++)
            {
                if(spStat.stats[i] == true)
                {
                    currentStain = Instantiate(stains[i], dropTransform.transform.position, stains[i].transform.rotation);
                    sList.stains.Add(currentStain);
                }
            }



            if (ccs.haveSugar != 0 && scs.haveSugar != 0)
            {
                currentStain = Instantiate(sugarPile, dropTransform.transform.position, Quaternion.identity);
                sList.stains.Add(currentStain);
                ccs.haveSugar = 0;
                scs.haveSugar = 0;
                spoonSugar.SetActive(false);


            }
            if (ccs.haveBoba != 0 && scs.haveBoba != 0)
            {
                currentStain = Instantiate(bobaPile, dropTransform.transform.position, bobaPile.transform.rotation);
                sList.stains.Add(currentStain);
                ccs.haveBoba= 0;
                scs.haveBoba = 0;
                spoonBoba.SetActive(false);


            }
            for (int i = 0; i < spStat.stats.Length; i++)
            {
                spStat.stats[i] = false;
                spStat.objs[i].SetActive(false);
            }
        }
    }
}
