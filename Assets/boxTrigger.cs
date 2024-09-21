using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTrigger : MonoBehaviour
{
    public boxStat bStat;
    public shelfStat sStat;
    BoxCollider bc;
    DrinkID drinkCS;
    void Start()
    {
        bStat = gameObject.transform.parent.GetComponent<boxStat>();
        sStat = FindObjectOfType<shelfStat>();
        bc = gameObject.GetComponent<BoxCollider>();
        drinkCS = FindObjectOfType<DrinkID>();
    }
    void Update()
    {
        if(bStat.Transfering == true)
        {
            Invoke("StopTransfer", 0.1f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 2 || other.gameObject.layer == 3)
        {
            Debug.Log("trgged");
            for(int i = 0; i < 7 + drinkCS.lv; i++)
            {
                if (other.gameObject.name == sStat.objects[i].name + "(Clone)")
                {
                    bStat.quantities[i] += 1;

                    break;
                }
            }

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 2 || other.gameObject.layer == 3)
        {
            for (int i = 0; i < 7 + drinkCS.lv; i++)
            {
                if (other.gameObject.name == sStat.objects[i].name + "(Clone)")
                {
                    bStat.quantities[i] -= 1;
                    break;
                }
            }

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 2 || other.gameObject.layer == 3)
        {
            if(bStat.Transfering == true)
            {
                if(bStat.started == false)
                {
                    bStat.sealBox = Instantiate(bStat.spawnBox, bStat.spawnPoint.position, Quaternion.identity);
                    bStat.started = true;
                    bStat.sBStat = bStat.sealBox.GetComponent<sealBoxStat>();
                    for (int i = 0; i < 7 + drinkCS.lv; i++)
                    {
                        bStat.sBStat.quantities[i] = bStat.quantities[i];
                    }
                    for (int i = 0; i < 7 + drinkCS.lv; i++)
                    {
                        bStat.quantities[i] = 0;
                    }

                }

                    Destroy(other.gameObject);


            }

        }
    }
    void StopTransfer()
    {
        bStat.Transfering = false;
        bStat.started = false;
    }








}
