using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cook : MonoBehaviour
{
    public GameObject smoke;

    bucketTrigger bTrigger;
    checkTrigger cTrigger;
    public float cookTimer;
    public bool isCooking;
    public int cooking;
    cookManager cm;
    cookTrigger cookTrig;
    public AudioSource src;
    public AudioClip sfx1;
    public bool isBurn;

    // Start is called before the first frame update
    void Start()
    {
        smoke.SetActive(false);
        bTrigger = FindObjectOfType<bucketTrigger>();
        cTrigger = FindObjectOfType<checkTrigger>();
        cm = FindObjectOfType<cookManager>();
        cookTrig = FindObjectOfType<cookTrigger>();
        isCooking = false;
        cookTimer = 0;

        isBurn = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isCooking == true && cookTimer < 100 && cookTrig.cookable == true)
        {
            cookTime();
        }
        if(isCooking == false)
        {
            src.Stop();
        }

        cookTimer = Mathf.Clamp(cookTimer, 0, 100);
        if(isCooking == false)
        {
            smoke.SetActive(false);

        }

    }
    public void StartCook()
    {

        if (bTrigger.ml > 0 && cookTrig.cookable == true)
        {
            src.clip = sfx1;
            src.Play();
            isCooking = true;
            smoke.SetActive(true);
        }
    }
    public void cookTime()
    {
        cookTimer += 0.025f;
        cm.healthAmount = cookTimer;


    }
}
