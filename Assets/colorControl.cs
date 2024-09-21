using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorControl : MonoBehaviour
{
    Material wallMaterial;
    public Renderer rend;
    public Button[] buttons;
    public Image[] coloring;
    public Color[] colors;
    public int colorID;


        
    // Start is called before the first frame update
    void Start()
    {
        ColorUp();

           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateColor()
    {
        
        wallMaterial.color = colors[colorID];
    }
    public void ColorUp()
    {
        wallMaterial = rend.GetComponent<Renderer>().sharedMaterial;
        wallMaterial.color = colors[0];
        for (int i = 0; i < coloring.Length; i++)
        {
            //coloring[i].color = colors[i];

        }
    }
    public void OnClicked(Button button)
    {
        for (int i = 0; i < coloring.Length; i++)
        {
            if(button == buttons[i])
            {
                colorID = i;
            }
        }
    }
}
