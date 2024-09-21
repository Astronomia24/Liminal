using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icetrigg : MonoBehaviour
{
    tutot tutot;
    shakerTrigger st;
    public int ice;
    // Start is called before the first frame update
    void Start()
    {
        tutot = FindObjectOfType<tutot>();
        st = FindObjectOfType<shakerTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tutot.num == 2)
        {
            ice = st.sIceAmount;
            if(ice == 3)
            {
                tutot.Start4();


            }
        }
    }
}
