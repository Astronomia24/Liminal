using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTrigger : MonoBehaviour
{

    public nBtea nb;
    newIce ics;
    public int iceA;
    public AudioSource src;
    public AudioClip sfx;
    public AudioClip sfx2;
    public AudioClip sfx8;
    public GameObject go;
    public int haveSugar;
    public GameObject fallce;
    public GameObject scoopice;
    public Animator anim;
    public int ispour;
    public GameObject ic1;
    public GameObject ic2;
    public GameObject ic3;
    public GameObject ic4;
    public int haveBoba;
    public AudioClip sfx3;
    DrinkID drinkCS;
    public GameObject spoonSugar;
    public GameObject spoonBoba;
    public GameObject ice;
    public GameObject bba;
    shakerTrigger scs;
    cupSpawning cs;

    // Start is called before the first frame update
    void Start()
    {
        nb = FindObjectOfType<nBtea>();
        ics = FindObjectOfType<newIce>();
        cs = FindObjectOfType<cupSpawning>();

        anim = scoopice.GetComponent<Animator>();
        drinkCS = FindObjectOfType<DrinkID>();
        scs = FindObjectOfType<shakerTrigger>();
        cs = FindObjectOfType<cupSpawning>();

        nb.iceAmount = 0;
        ispour = 0;

        nb.sugarAmount = 0;
        haveSugar = 0;
        haveBoba = 0;
        fallce.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


        if (ispour == 1)
        {
            anim.SetBool("isPouring", true);
        }
        if(ispour == 0)
        {
            anim.SetBool("isPouring", false);
        }
        if(nb.iceAmount == 0)
        {
            ic1.SetActive(false);
            ic2.SetActive(false);
            ic3.SetActive(false);
            ic4.SetActive(false);
        }
        if(nb.iceAmount == 1)
        {
            ic1.SetActive(true);
            ic2.SetActive(false);
            ic3.SetActive(false);
            ic4.SetActive(false);
        }
        if (nb.iceAmount == 2)
        {
            ic1.SetActive(true);
            ic2.SetActive(true);
            ic3.SetActive(false);
            ic4.SetActive(false);
        }
        if (nb.iceAmount == 3)
        {
            ic1.SetActive(true);
            ic2.SetActive(true);
            ic3.SetActive(true);
            ic4.SetActive(false);
        }
        if (nb.iceAmount == 4)
        {
            ic1.SetActive(true);
            ic2.SetActive(true);
            ic3.SetActive(true);
            ic4.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Scoop" && nb.isSealed == 0)
        {

            if(ics.haveIce == 1)
            {
                ispour = 0;
                StartCoroutine(falling());
                ics.haveIce = 0;
                if(nb.iceAmount < 4)
                {
                    nb.iceAmount += 1;
                }
                if (nb.iceAmount == 4)
                {
                    nb.iceAmount = 4;
                    Instantiate(ice, gameObject.transform.position, Quaternion.identity);

                    src.clip = sfx8;
                    src.Play();
                }

                src.clip = sfx;
                src.Play();
                drinkCS.newIceAmount -= 10;
                

                StartCoroutine(pouring());

            }
        }
        if (other.tag == "spoon" && nb.isSealed == 0)
        {
            if (haveSugar == 1)
            {
                spoonSugar.SetActive(false);
                nb.sugarAmount += 1;
                haveSugar = 0;
                scs.haveSugar = 0;
                src.clip = sfx3;
                src.Play();
            }
            if(haveBoba == 1)
            {
                haveBoba = 0;
                scs.haveBoba = 0;

                spoonBoba.SetActive(false);
                if (nb.bobacount > 3)
                {
                    nb.bobacount = 3;
                    Instantiate(bba, gameObject.transform.position, Quaternion.identity);
                }
                nb.haveBB = 1;
                nb.bobacount += 1;
            }
            


        }
        if (other.tag == "milk")
        {
            GameObject go = GameObject.Find("milk(Clone)");
            Destroy(go.gameObject);



        }
    }
    IEnumerator falling()
    {
        fallce.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        fallce.SetActive(false);
    }
    public IEnumerator pouring()
    {
        ispour = 1;
        yield return new WaitForSeconds(0.01f);
        ispour = 0;
        scoopice.SetActive(false);
        

    }
    public void AddSugar()
    {
        if (haveSugar == 1 && nb.isSealed == 0)
        {
            spoonSugar.SetActive(false);
            nb.sugarAmount += 1;
            haveSugar = 0;
            scs.haveSugar = 0;
            src.clip = sfx3;
            src.Play();
        }
    }
    public void AddBoba()
    {
        if (haveBoba == 1 && nb.isSealed == 0)
        {
            haveBoba = 0;
            scs.haveBoba = 0;

            spoonBoba.SetActive(false);
            if (nb.bobacount > 3)
            {
                nb.bobacount = 3;
                Instantiate(bba, gameObject.transform.position, Quaternion.identity);
            }
            nb.haveBB = 1;
            nb.bobacount += 1;
        }
    }
}
