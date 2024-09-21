using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmcontroller : MonoBehaviour
{
    public GameObject bgm;
    public GameObject checkBox;
    public bool isOn;
    nLaptop nl;
    // Start is called before the first frame update
    void Start()
    {
        bgm.SetActive(true);
        isOn = true;
        nl = FindObjectOfType<nLaptop>();

    }

    // Update is called once per frame
    void Update()
    {
        if(nl.isPause == true)
        {
            if(isOn == true)
            {
                checkBox.SetActive(true);
            }
            else
            {
                checkBox.SetActive(false);
            }
        }
    }
    public void click()
    {
        if(isOn == true)
        {
            isOn = false;
            bgm.SetActive(false);
        }
        else
        {
            isOn = true;
            bgm.SetActive(true);
        }
    }
}
