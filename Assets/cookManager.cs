using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cookManager : MonoBehaviour
{
    public Image CookBar;
    public float healthAmount = 100f;
    public AudioSource src;
    public AudioClip sfx;
    cook ck;
    public GameObject fire;
    missionControl mc;
    TutorialManager tut;
    checkTrigger cTrigger;
    public bool done;
    public bool burnt;






    // Start is called before the first frame update
    void Start()
    {
        done = false;
        burnt = false;
        healthAmount = 0;
        ck = FindObjectOfType<cook>();
        mc = FindObjectOfType<missionControl>();
        tut = FindObjectOfType<TutorialManager>();
        cTrigger = FindObjectOfType<checkTrigger>();
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CookBar.fillAmount = healthAmount / 100f;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        if(healthAmount >= 99.8f && healthAmount < 100)
        {

            src.clip = sfx;
            src.Play();
            if(cTrigger.haveBB == true)
            {

                cTrigger.bobas2.SetActive(true);
                cTrigger.bobas2.transform.position = cTrigger.bobas.transform.position;
                cTrigger.bobas.SetActive(false);
                cTrigger.cookBB = true;

            }
            Invoke("BurnCheck", 6f);
            mc.Mission3();
        }
    }
    public void BurnCheck()
    {
        done = true;
        if (ck.isCooking == true && tut.index > 12)
        {
            fire.SetActive(true);
            ck.isBurn = true;
            burnt = true;

        }
        else
        {
            burnt = false;
        }

    }
}
