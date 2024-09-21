using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newIce : MonoBehaviour
{
    public GameObject icee;
    public GameObject cupTrigger;
    public int haveIce;
    public AudioSource src;
    public AudioSource src2;
    public AudioClip[] sfx;
    public int ID;
    public GameObject icer;

    public int stir;
    public GameObject fallce;
    public DrinkID drinkCS;
    public GameObject iceObj;
    public coverControl cc;
    PickUpClass pick;
    scoopFlip sf;
    tutorControl tut;
    public bool isIce;

    // Start is called before the first frame update
    void Start()
    {
        icee.SetActive(false);
        iceObj.SetActive(true);
        haveIce = 0;

        drinkCS = FindObjectOfType<DrinkID>();
        cc = FindObjectOfType<coverControl>();
        pick = FindObjectOfType<PickUpClass>();
        sf = FindObjectOfType<scoopFlip>();
        tut = FindObjectOfType<tutorControl>();

        stir = 0;
        fallce.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(stir == 1)
        {

        }
        if(stir == 0)
        {

        }
        if(drinkCS.newIceAmount <= 0)
        {
            iceObj.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scoop" && drinkCS.newIceAmount > 0 && cc.open == true)
        {
            ID = Random.Range(1, 5);
            src2.clip = sfx[ID];
            src2.Play();


        }
    }
    void OnTrigrExit(Collider other)
    {
        if(other.gameObject.tag =="Scoop" && drinkCS.newIceAmount > 0 && cc.open == true )
        {
            if (sf.RotationX < 90 && sf.RotationX > -90 && sf.RotationZ > -90 && sf.RotationZ < 90)
            {
                cupTrigger.SetActive(true);
                icee.SetActive(true);
                haveIce = 1;
                ID = Random.Range(1, 5);
                src.clip = sfx[ID];
                src.Play();
                StartCoroutine(Stiring());
                if(tut.step < 9)
                {
                    drinkCS.newIceAmount = 200;
                }

            }
        }
    }
    public void Scoop()
    {
        if (sf.RotationX < 90 && sf.RotationX > -90 && sf.RotationZ > -90 && sf.RotationZ < 90)
        {
            cupTrigger.SetActive(true);
            icee.SetActive(true);
            haveIce = 1;
            ID = Random.Range(1, 5);
            src.clip = sfx[ID];
            src.Play();
            StartCoroutine(Stiring());
            if (tut.step < 9)
            {
                drinkCS.newIceAmount = 200;
            }


        }
    }
    IEnumerator Stiring()
    {
        stir = 1;
        fallce.SetActive(true);
        yield return new WaitForSeconds(0.83f);
        fallce.SetActive(false);
        yield return new WaitForSeconds(1.17f);
        stir = 0;

    }
}
