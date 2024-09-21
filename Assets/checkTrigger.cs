using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTrigger : MonoBehaviour
{
    public bool boba;
    public bool bTea;
    public bool gTea;
    public bool mTea;
    bucketTrigger bTrigger;
    public GameObject blackTea;
    public GameObject blackTea2;
    public GameObject blackTea3;
    public GameObject blackTea4;
    public GameObject greenTea;
    public GameObject greenTea2;
    public GameObject greenTea3;
    public GameObject greenTea4;
    public GameObject milkTea;
    public GameObject milkTea2;
    public GameObject milkTea3;
    public GameObject milkTea4;
    public GameObject bobas;
    public GameObject bobas2;
    public bool haveBB;
    public bool cookBB;





    // Start is called before the first frame update
    void Start()
    {
        cookBB = false;
        boba = false;
        bTea = false;
        gTea = false;
        mTea = false;
        blackTea.SetActive(false);
        blackTea2.SetActive(false);
        blackTea3.SetActive(false);
        blackTea4.SetActive(false);
        greenTea.SetActive(false);
        greenTea2.SetActive(false);
        greenTea3.SetActive(false);
        greenTea4.SetActive(false);
        milkTea.SetActive(false);
        milkTea2.SetActive(false);
        milkTea3.SetActive(false);
        milkTea4.SetActive(false);
        bobas.SetActive(false);
        bobas2.SetActive(false);
        haveBB = false;


        bTrigger = FindObjectOfType<bucketTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gTea == false)
        {
            greenTea.SetActive(false);

        }
        if(bTea == false)
        {
            blackTea.SetActive(false);

        }
        if(mTea == false)
        {
            milkTea.SetActive(false);

        }
        if(bTrigger.ml == 0)
        {
            boba = false;
            bTea = false;
            gTea = false;
            mTea = false;
            blackTea.SetActive(false);
            greenTea.SetActive(false);
            milkTea.SetActive(false);

        }
        if(bTea == true)
        {
            if(bTrigger.ml > 0)
            {
                blackTea.SetActive(true);
                blackTea.transform.position = bTrigger.Water.transform.position;
            }
        }
        if(gTea == true)
        {
            if(bTrigger.ml > 0)
            {
                greenTea.SetActive(true);
                greenTea.transform.position = bTrigger.Water.transform.position;
            }

        }
        if(mTea == true)
        {
            if (bTrigger.ml > 0)
            {
                milkTea.SetActive(true);
                milkTea.transform.position = bTrigger.Water.transform.position;
            }

  

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bobs(Clone)")
        {
            Destroy(other.gameObject);
            bobas.SetActive(true);
            haveBB = true;






        }
        if (bTrigger.ml > 0)
        {
            if (other.gameObject.name == "bLeaf(Clone)")
            {

                Destroy(other.gameObject);
                bTea = true;
                gTea = false;


            }
            if (other.gameObject.name == "gLeaf(Clone)")
            {

                Destroy(other.gameObject);
                gTea = true;
                bTea = false;



            }
            if (other.gameObject.name == "creamer(Clone)")
            {

                Destroy(other.gameObject);
                mTea = true;




            }


        }
    }
}
