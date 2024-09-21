using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderControl : MonoBehaviour
{

    float someValue;
    public float xwob;
    public float xwob2;
    public float xwob3;


    public Renderer rend;
    public Renderer rend2;
    public Renderer milkRend;
    public Renderer cupRend;
    shakerTrigger scs;
    nBtea nb;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public Color color8;
    public Color color9;

    public Color scolor1;
    public Color scolor2;
    public Color scolor3;
    public Color scolor4;
    public Color scolor5;
    public Color scolor6;
    public Color scolor7;
    public Color scolor8;
    public Color scolor9;


    // Start is called before the first frame update
    void Start()
    {
        scs = FindObjectOfType<shakerTrigger>();
        nb = FindObjectOfType<nBtea>();
    }

    // Update is called once per frame
    void Update()
    {
        xwob3 = scs.mnml;
        xwob = scs.newML + scs.mnml;
        xwob2 = nb.newM;
        rend.material.SetFloat("_fill", xwob);
        rend2.material.SetFloat("_fill", xwob2);
        milkRend.material.SetFloat("_fill", xwob3);
    }
}
