using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsControl : MonoBehaviour
{
    public padManager pad;
    // Start is called before the first frame update
    void Start()
    {
        pad = FindObjectOfType<padManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Page0()
    {
        pad.Page0();
    }
    public void Page1()
    {
        pad.Page1();
    }
    public void Page2()
    {
        pad.Page2();
    }
    public void Page3()
    {
        pad.Page3();
    }
    public void Page4()
    {
        pad.Page4();
    }
}
