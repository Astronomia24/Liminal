using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorControl : MonoBehaviour
{
    public GameObject textBox;
    public Text tutext;
    public GameObject[] sign;
    public int i;
    public string[] dialogue;
    public int step;
    public AudioSource src;
    public AudioClip sfx1;
    public GameObject OrderBox;
    public GameObject[] emote;
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;

    cook ck;
    DrinkID drinkCS;

    // Start is called before the first frame update
    void Start()
    {
        src.Play();
        step = 0;
        //textBox.SetActive(true);
        for(i = 0; i < 15; i++)
        {
            sign[i].SetActive(false);
        }
        //sign[step].SetActive(true);
        for (i = 0; i < 15; i++)
        {
            emote[i].SetActive(false);
        }
        //emote[step].SetActive(true);

        src.clip = sfx1;
        ck = FindObjectOfType<cook>();
        drinkCS = FindObjectOfType<DrinkID>();
        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(false);


    }

    // Update is called once per frame
    void Updadd()
    {
        if(step == 8)
        {
            OrderBox.SetActive(true);
        }

        if (step <= 15)
        {
            if(drinkCS.lanID == 0)
            {
                tutext.text = dialogue[step];
            }
            if(drinkCS.lanID == 1)
            {
                tutext.text = dialogue[step + 16];
            }
            if (drinkCS.lanID == 2)
            {
                tutext.text = dialogue[step + 16 + 16];
            }
            if (drinkCS.lanID == 3)
            {
                tutext.text = dialogue[step + 16 + 16 + 16];
            }
            if (drinkCS.lanID == 4)
            {
                tutext.text = dialogue[step + 16 + 16 + 16 + 16];
            }


        }
        if(step == 1)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);

        }
        if (step == 2)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);

        }
        if (step == 3)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);

        }
        if (step == 4)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);


        }
        if (step == 5)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);


        }
        if (step == 6)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);


        }
        if (step == 7)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);


        }
        if (step == 8)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);


        }
        if (step == 9)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);

        }
        if (step == 10)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(true);

        }
        if (step == 11)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);

        }
        if (step == 12)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);

        }
        if (step == 13)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);

        }
        if (step == 14)
        {
            for (i = 0; i < 15; i++)
            {
                sign[i].SetActive(false);
            }
            sign[step].SetActive(true);
            emote[step - 1].SetActive(false);
            emote[step].SetActive(true);
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);

        }
        if(step == 14)
        {
            Invoke("End", 5f);
        }
    }
    public void End()
    {
        textBox.SetActive(false);
        step = 99;
        for (i = 0; i < 15; i++)
        {
            sign[i].SetActive(false);
        }
        for (i = 0; i < 15; i++)
        {
            emote[i].SetActive(false);
        }
    }
}
