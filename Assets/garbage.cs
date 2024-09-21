using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbage : MonoBehaviour
{
    shakerTrigger st;
    nBtea nb;
    nCheckServe nc;

    // Start is called before the first frame update
    void Start()
    {
        st = FindObjectOfType<shakerTrigger>();
        nb = FindObjectOfType<nBtea>();
        nc = FindObjectOfType<nCheckServe>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "shaker")
        {
            other.gameObject.transform.position = new Vector3(3f, 0.96f, 1.35f);
            st.Restart();
        }
        if (other.gameObject.name == "nCup")
        {
            other.gameObject.transform.position = new Vector3(-0.04f, 1.2f, -0.13f);
            nc.Cup.SetActive(false);
            nc.Cup.transform.position = new Vector3(2.09f, 1.2f, 1.2f);
            nc.Cup.transform.localRotation = Quaternion.Euler(0, 0, 0);
            nc.Cup.SetActive(true);
            nb.teaa.SetActive(false);
            nb.cupTrigger.SetActive(true);
            nb.Bml = 0;
            nb.Gml = 0;
            nb.Mml = 0;
            nb.shake = 0;
            nb.iceAmount = 0;
            nb.sugarAmount = 0;
            nb.teaID = 0;
            nb.isSealed = 0;
            nb.haveBB = 0;


        }
    }
}
