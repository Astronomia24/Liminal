using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posControl : MonoBehaviour
{
    public int teaID;
    public int iceAmount;
    public int sugarAmount;
    public int haveBoba;
    public GameObject orderPap;
    public GameObject currentPap;
    public Transform pospos;
    public orderStat oStat;
    public AudioSource orderDing;
    PickUpClass pick;
    shakerTrigger scs;
    TutorialManager tut;


    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
        scs = FindObjectOfType<shakerTrigger>();
        tut = FindObjectOfType<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GiveOrder()
    {
        if(tut.index <= 15)
        {
            teaID = Random.Range(1, 4);
            iceAmount = Random.Range(1, 5);
            sugarAmount = Random.Range(1, 5);
            haveBoba = Random.Range(0, 2);
        }
        else
        {
            teaID = Random.Range(1, 7);
            iceAmount = Random.Range(0, 5);
            sugarAmount = Random.Range(0, 5);
            haveBoba = Random.Range(0, 2);
        }

        currentPap = Instantiate(orderPap, pospos.position, orderPap.transform.rotation);
        oStat = currentPap.GetComponent<orderStat>();
        scs.oStat = oStat;
        oStat.owner = pick.q.gameObject;
        oStat.teaID = teaID;
        oStat.iceAmount = iceAmount;
        oStat.sugarAmount = sugarAmount;
        oStat.haveBoba = haveBoba;
        orderDing.Play();
    }
}
