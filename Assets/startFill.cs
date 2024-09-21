using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startFill : MonoBehaviour
{
    public bool haveShaker;
    public GameObject milkPillar;
    public GameObject greenPillar;
    public GameObject blackPillar;
    DrinkID drinkCS;

    // Start is called before the first frame update
    void Start()
    {
        blackPillar.SetActive(false);
        greenPillar.SetActive(false);
        milkPillar.SetActive(false);
        drinkCS = FindObjectOfType<DrinkID>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            blackPillar.SetActive(false);
            greenPillar.SetActive(false);
            milkPillar.SetActive(false);
        }
    }
    public void Milk()
    {
        if (drinkCS.mTeaLeft > 0)
        {
            milkPillar.SetActive(true);
            blackPillar.SetActive(false);
            greenPillar.SetActive(false);
        }
    }
    public void Green()
    {
        if (drinkCS.gTeaLeft > 0)
        {
            blackPillar.SetActive(false);
            greenPillar.SetActive(true);
            milkPillar.SetActive(false);
        }
    }
    public void Black()
    {
        if (drinkCS.bTeaLeft > 0)
        {
            blackPillar.SetActive(true);
            greenPillar.SetActive(false);
            milkPillar.SetActive(false);
        }
    }
    public void Quit()
    {
        blackPillar.SetActive(false);
        greenPillar.SetActive(false);
        milkPillar.SetActive(false);
    }

}
