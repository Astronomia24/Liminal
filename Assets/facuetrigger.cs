using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facuetrigger : MonoBehaviour
{
    bucketTrigger bt;
    tutorControl tut;
    public AudioSource src;
    public AudioClip sfx;
    shakerTrigger scs;
    nBtea nb;
    public int fid;
    // Start is called before the first frame update
    void Start()
    {
        bt = FindObjectOfType<bucketTrigger>();
        tut = FindObjectOfType<tutorControl>();
        scs = FindObjectOfType<shakerTrigger>();
        nb = FindObjectOfType<nBtea>();
        scs.isFill = false;
        fid = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "teaBucket")
        {
            if(gameObject.name == "faucet1")
            {
                src.clip = sfx;
                src.Play();
                fid = 1;
            }
            if(gameObject.name == "faucet2")
            {
                src.clip = sfx;
                src.Play();
                fid = 2;
            }
        }
        if (other.gameObject.name == "shaker") 
        {

            scs.isFill = true;
            scs.src.clip = scs.sfx3;
            scs.src.Play();
            scs.FillWater();


        }
        if (other.gameObject.name == "nCup")
        {

            nb.isFill = true;
            nb.FillWater();


        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "teaBucket" && Mathf.Abs(bt.RotationX) < 60 && Mathf.Abs(bt.RotationZ) < 60)
        {

            bt.Water.SetActive(true);
            bt.isFilling = true;
            if (tut.step == 10)
            {
                tut.step = 11;
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "teaBucket")
        {
            bt.isFilling = false;
            src.Stop();
        }
        if(other.gameObject.name == "shaker")
        {
            scs.isFill = false;
        }
        if (other.gameObject.name == "nCup")
        {
            nb.isFill = false;
        }
        fid = 0;
    }
    public void Stop()
    {
        nb.isFill = false;
        scs.isFill = false;
        bt.isFilling = false;
        src.Stop();
    }
}
