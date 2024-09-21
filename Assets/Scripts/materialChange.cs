using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class materialChange : MonoBehaviour
{
    public Material[] materials;
    Renderer rend;
    public int mtrl;
    public int lv;

    DrinkID drinkCS;

    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        mtrl = 0;
        lv = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[mtrl];
    }

    public void ChangeDeco()
    {
        if(lv > mtrl)
        {
            mtrl += 1;
            rend.sharedMaterial = materials[mtrl];
        }
        else if (drinkCS.money >= 300)
        {
            drinkCS.money -= 50;
            mtrl += 1;
            lv += 1;
            rend.sharedMaterial = materials[mtrl];
        }
    }
    public void DownGrade()
    {
        mtrl -= 1;
        rend.sharedMaterial = materials[mtrl];
    }


}
