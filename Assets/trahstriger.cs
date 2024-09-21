using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trahstriger : MonoBehaviour
{
    public int amount;
    public GameObject trash;
    nBtea nb;
    public GameObject Cup;
    public Transform spawning;
    public Transform spawn2;
    // Start is called before the first frame update
    void Start()
    {

        amount = 0;
        nb = FindObjectOfType<nBtea>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "nCup")
        {
            nb.teaa.SetActive(false);
            nb.cupTrigger.SetActive(true);
            Cup.transform.position = new Vector3(spawning.position.x, spawning.position.y, spawning.position.z);
            


            nb.Bml = 0;
            nb.Gml = 0;
            nb.Mml = 0;
            nb.shake = 0;
            nb.iceAmount = 0;
            nb.sugarAmount = 0;
            nb.teaID = 0;
            nb.isSealed = 0;
            nb.haveBB = 0;
            nb.newM = 0;

            amount += 1;
            if (amount >= 2)
            {
                amount = 0;
                Instantiate(trash, spawn2.position, Quaternion.identity);
            }
        }
        if(other.gameObject.name == "greenLeaf(Clone)" || other.gameObject.name == "blackLeaf(Clone)" || other.gameObject.name == "bobabag(Clone)" || other.gameObject.name == "milk(Clone)" || other.gameObject.name == "creamer(Clone)")
        {
            amount += 1;
            Destroy(other.gameObject);
            if (amount >= 2)
            {
                amount = 0;
                Instantiate(trash, spawn2.position, Quaternion.identity);
            }
        }
        if (other.gameObject.name == "cup(Clone)")
        {
            Destroy(other.gameObject);
            amount += 1;
            if (amount >= 2)
            {
                amount = 0;
                Instantiate(trash, spawn2.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
    }
}

