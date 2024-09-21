using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teatrigg : MonoBehaviour
{
    tutot tutot;
    shakerTrigger st;
    public int tea;
    public int sug;
    public int sk;
    nBtea nb;
    DrinkID drinkCS;
    // Start is called before the first frame update
    void Start()
    {
        tutot = FindObjectOfType<tutot>();
        st = FindObjectOfType<shakerTrigger>();
        drinkCS = FindObjectOfType<DrinkID>();
        nb = FindObjectOfType<nBtea>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutot.num == 3)
        {
            tea = st.Bml;

            if (tea == 300)
            {
                tutot.Start5();

            }
        }
        if(tutot.num == 4)
        {
            sug = st.sSugarAmount;
            if(sug == 2)
            {
                tutot.Start6();
            }
        }
        if (tutot.num == 5)
        {
            sk = st.shake;

            if (sk > 10)
            {
                tutot.Start7();
            }
        }
        if (tutot.num == 6)
        {


            if (nb.isSealed == 1)
            {
                tutot.Start8();
            }
            
        }
        if(tutot.num == 8)
        {
            if(drinkCS.bTeaLeft > 0 && drinkCS.gTeaLeft > 0 && drinkCS.mTeaLeft > 0)
            {
                tutot.Start9();
            }
        }
    }
}
