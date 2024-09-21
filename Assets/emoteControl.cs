using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emoteControl : MonoBehaviour
{
    public GameObject emote;
    public GameObject emote2;
    public GameObject emote3;
    customerManager custom;
    // Start is called before the first frame update
    void Start()
    {
        custom = FindObjectOfType<customerManager>();
        emote.SetActive(false);
        emote2.SetActive(false);
        emote3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(custom.timer == 150)
        {
            emote.SetActive(true);
            emote2.SetActive(false);
            emote3.SetActive(false);
        }
        else if(custom.timer <= 0)
        {
            emote.SetActive(false);
            emote2.SetActive(false);
            emote3.SetActive(false);
        }
        else if(custom.timer > 45 && custom.timer < 100)
        {
            emote.SetActive(false);
            emote2.SetActive(true);
            emote3.SetActive(false);
        }
        else if(custom.timer > 0 && custom.timer < 45)
        {
            emote.SetActive(false);
            emote2.SetActive(false);
            emote3.SetActive(true);
        }

    }
}
