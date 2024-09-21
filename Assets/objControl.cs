using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objControl : MonoBehaviour
{
    tutorControl tut;
    public string[] task;
    public GameObject taskBox;
    public Text taskText;
    DrinkID drinkCS;
    shakerTrigger scs;
    customerManager ccs;
    public int stain;
    public bool played;
    public AudioSource src;
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
        tut = FindObjectOfType<tutorControl>();
        drinkCS = FindObjectOfType<DrinkID>();
        scs = FindObjectOfType<shakerTrigger>();
        ccs = FindObjectOfType<customerManager>();
        //taskBox.SetActive(true);
        stain = 0;

        
    }

    // Update is called once per frame
    void Updaddd()
    {
        if (tut.step <= 15)
        {
            if (drinkCS.lanID == 0)
            {
                if(tut.step == 1)
                {
                    //taskText.text = task[tut.step] + ": " + stain + " / 6";
                    if (played == false && stain >= 6)
                    {
                        //src.clip = sfx;

                        //src.Play();
                        //played = true;
                    }
                }
                else if(tut.step == 3)
                {
                    //taskText.text = task[tut.step] ;
                }
                else if (tut.step == 4)
                {
                    //taskText.text = task[tut.step] ;
                }
                else if(tut.step == 5)
                {
                    //taskText.text = task[tut.step];
                }
                else
                {
                    //taskText.text = task[tut.step];
                }
            }
            if (drinkCS.lanID == 1)
            {
                if (tut.step == 1)
                {
                    //taskText.text = task[tut.step + 16] + ": " + stain + " / 6";
                }
                else if (tut.step == 3)
                {
                    //taskText.text = task[tut.step + 16];
                }
                else if (tut.step == 4)
                {
                    //taskText.text = task[tut.step + 16] ;
                }
                else if (tut.step == 5)
                {
                   // taskText.text = task[tut.step +16] ;
                }
                else
                {
                    //taskText.text = task[tut.step + 16];
                }
            }
            if (drinkCS.lanID == 2)
            {
                if (tut.step == 1)
                {
                    //taskText.text = task[tut.step + 16 + 16] + ": " + stain + " / 6";
                }
                else if (tut.step == 3)
                {
                    //taskText.text = task[tut.step + 16 + 16];
                }
                else if (tut.step == 4)
                {
                    //taskText.text = task[tut.step + 16 + 16];
                }
                else if (tut.step == 5)
                {
                    //taskText.text = task[tut.step + 16 + 16] ;
                }
                else
                {
                    //taskText.text = task[tut.step + 16 + 16];
                }
            }
            if (drinkCS.lanID == 3)
            {
                if (tut.step == 1)
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16] + ": " + stain + " / 6";
                }
                else if (tut.step == 3)
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16] ;
                }
                else if (tut.step == 4)
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16] ;
                }
                else if (tut.step == 5)
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16] ;
                }
                else
                {
                   // taskText.text = task[tut.step + 16 + 16 + 16];
                }
            }
            if (drinkCS.lanID == 4)
            {
                if (tut.step == 1)
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16 + 16] + ": " + stain + " / 6";
                }
                else if (tut.step == 3)
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16 + 16] ;
                }
                else if (tut.step == 4)
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16 + 16];
                }
                else if (tut.step == 5)
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16 + 16] ;
                }
                else
                {
                    //taskText.text = task[tut.step + 16 + 16 + 16 + 16];
                }
            }

        }
        if(drinkCS.day > 1 && drinkCS.hour >= 6)
        {
            taskBox.SetActive(false);
        }

    }
}
