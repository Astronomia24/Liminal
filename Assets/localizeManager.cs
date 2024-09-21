using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localizeManager : MonoBehaviour
{
    public DrinkID drinkCS;
    public GameObject[] tutorials;
    public GameObject[] pads;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        for (int i = 0; i < tutorials.Length; i++)
        {
            tutorials[i].SetActive(false);
            pads[i].SetActive(false);
            tutorials[DrinkID.language].SetActive(true);
            pads[DrinkID.language].SetActive(true);
        }
    }
}
