using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobaTrigger : MonoBehaviour
{
    public GameObject spoonBoba;
    CupTrigger ccs;
    shakerTrigger scs;
    public AudioSource src;
    public AudioClip sfx;

    BOBAflip bf;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;

    // Start is called before the first frame update
    void Start()
    {
        spoonBoba.SetActive(false);
        ccs = FindObjectOfType<CupTrigger>();
        scs = FindObjectOfType<shakerTrigger>();
        bf = FindObjectOfType<BOBAflip>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ccs.haveBoba == 0 || scs.haveBoba == 0)
        {
            spoonBoba.SetActive(false);
        }
        if (bf.bbAmount >= 10)
        {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "spoon")
        {
            src.clip = sfx;
            src.Play();
            bf.bbAmount -= 1;
            if(bf.bbAmount >= 10)
            {
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(true);
            }
            if(bf.bbAmount > 5 && bf.bbAmount < 7)
            {
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(true);
            }
            if (bf.bbAmount > 3 && bf.bbAmount < 5)
            {
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(false);
            }
            if (bf.bbAmount > 1 && bf.bbAmount < 3)
            {
                b1.SetActive(true);
                b2.SetActive(false);
                b3.SetActive(false);

            }
            ccs.haveBoba = 1;
            scs.haveBoba = 1;
            spoonBoba.SetActive(true);
        }

    }
    public void FillBoba()
    {
        src.clip = sfx;
        src.Play();
        bf.bbAmount -= 1;
        if (bf.bbAmount >= 10)
        {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
        }
        if (bf.bbAmount > 5 && bf.bbAmount < 7)
        {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
        }
        if (bf.bbAmount > 3 && bf.bbAmount < 5)
        {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(false);
        }
        if (bf.bbAmount > 1 && bf.bbAmount < 3)
        {
            b1.SetActive(true);
            b2.SetActive(false);
            b3.SetActive(false);

        }
        ccs.haveBoba = 1;
        scs.haveBoba = 1;
        spoonBoba.SetActive(true);
    }
}
