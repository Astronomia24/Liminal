using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxStat : MonoBehaviour
{
    public int[] quantities;
    shelfStat sStat;
    public bool Transfering;
    public bool started;
    public GameObject spawnBox;
    public GameObject sealBox;
    public GameObject emptyBox;
    public Transform spawnPoint;
    public sealBoxStat sBStat;
    DrinkID drinkCS;


    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        Transfering = false;
        started = false;
        sStat = FindObjectOfType<shelfStat>();
        for(int i = 0; i < 7 + drinkCS.lv; i++)
        {
            quantities[i] = 0;
        }


    }
     



}
