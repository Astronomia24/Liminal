using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sCupTrigger : MonoBehaviour
{
    public GameObject SpoonSugar;
    CupTrigger ccs;
    public shakerTrigger scs;
    public AudioSource src;
    public AudioClip sfx2;
    sugarScript ss;
    public GameObject sugarDrop;



    // Start is called before the first frame update
    void Start()
    {
        SpoonSugar.SetActive(false);
        ccs = FindObjectOfType<CupTrigger>();
        scs = FindObjectOfType<shakerTrigger>();
        ss = FindObjectOfType<sugarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ccs.haveSugar == 0 || scs.haveSugar == 0)
        {
            SpoonSugar.SetActive(false);
        }
        if (ccs.haveSugar != 0 || scs.haveSugar != 0)
        {
            sugarDrop.SetActive(true);
        }
        else
        {
            sugarDrop.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "spoon")
        {





        }




    }
    public void FillSugar()
    {
        ss.sugarCount -= 1;
        ccs.haveSugar = 1;
        scs.haveSugar = 1;
        SpoonSugar.SetActive(true);
        src.clip = sfx2;
        src.Play();
    }
}
