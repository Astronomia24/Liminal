using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nColory : MonoBehaviour
{
    Material wallMaterial;
    public Renderer rend;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public Color color8;
    public Color color9;
    public Color color10;
    public Color color11;
    public Color color12;
    public Color color13;
    public Color color14;
    public Color color15;
    public int colorID;
    DrinkID drinkCS;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        wallMaterial = rend.GetComponent<Renderer>().sharedMaterial;
        wallMaterial.color = color1;
        colorID = 1;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {



    }
    public void C1()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 1;
            wallMaterial.color = color1;
        }
    }
    public void C2()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 2;
            wallMaterial.color = color2;
        }
    }
    public void C3()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 3;
            wallMaterial.color = color3;
        }
    }
    public void C4()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 4;
            wallMaterial.color = color4;
        }
    }
    public void C5()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 5;
            wallMaterial.color = color5;
        }
    }
    public void C6()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 6;
            wallMaterial.color = color6;
        }
    }
    public void C7()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 7;
            wallMaterial.color = color7;
        }
    }
    public void C8()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 8;
            wallMaterial.color = color8;
        }
    }
    public void C9()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 9;
            wallMaterial.color = color9;
        }
    }
    public void C10()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 10;
            wallMaterial.color = color10;
        }
    }
    public void C11()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 11;
            wallMaterial.color = color11;
        }
    }
    public void C12()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 12;
            wallMaterial.color = color12;
        }
    }
    public void C13()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 13;
            wallMaterial.color = color13;
        }
    }
    public void C14()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 14;
            wallMaterial.color = color14;
        }
    }
    public void C15()
    {
        if (drinkCS.money >= 100)
        {
            drinkCS.money -= 100;
            colorID = 15;
            wallMaterial.color = color15;
        }

    }

    public void Upgrade()
    {
        if(level > colorID)
        {
            level += 1;
            colorID = level;


        }
        if (drinkCS.money >= 100)
        {
            if (colorID < 15)
            {
                level += 1;
                colorID += 1;
                drinkCS.money -= 100;
            }
        }
        if (colorID == 1)
        {
            wallMaterial.color = color1;
        }
        if (colorID == 2)
        {
            wallMaterial.color = color2;
        }
        if (colorID == 3)
        {
            wallMaterial.color = color3;
        }
        if (colorID == 4)
        {
            wallMaterial.color = color4;
        }
        if (colorID == 5)
        {
            wallMaterial.color = color5;
        }
        if (colorID == 6)
        {
            wallMaterial.color = color6;
        }
        if (colorID == 7)
        {
            wallMaterial.color = color7;
        }
        if (colorID == 8)
        {
            wallMaterial.color = color8;
        }
        if (colorID == 9)
        {
            wallMaterial.color = color9;
        }
        if (colorID == 10)
        {
            wallMaterial.color = color10;
        }
        if (colorID == 11)
        {
            wallMaterial.color = color11;
        }
        if (colorID == 12)
        {
            wallMaterial.color = color12;
        }
        if (colorID == 13)
        {
            wallMaterial.color = color13;
        }
        if (colorID == 14)
        {
            wallMaterial.color = color14;
        }
        if (colorID == 15)
        {
            wallMaterial.color = color15;
        }

    }
    public void DownGrade()
    {
        colorID -= 1;
                
        if (colorID == 1)
        {
            wallMaterial.color = color1;
        }
        if (colorID == 2)
        {
            wallMaterial.color = color2;
        }
        if (colorID == 3)
        {
            wallMaterial.color = color3;
        }
        if (colorID == 4)
        {
            wallMaterial.color = color4;
        }
        if (colorID == 5)
        {
            wallMaterial.color = color5;
        }
        if (colorID == 6)
        {
            wallMaterial.color = color6;
        }
        if (colorID == 7)
        {
            wallMaterial.color = color7;
        }
        if (colorID == 8)
        {
            wallMaterial.color = color8;
        }
        if (colorID == 9)
        {
            wallMaterial.color = color9;
        }
        if (colorID == 10)
        {
            wallMaterial.color = color10;
        }
        if (colorID == 11)
        {
            wallMaterial.color = color11;
        }
        if (colorID == 12)
        {
            wallMaterial.color = color12;
        }
        if (colorID == 13)
        {
            wallMaterial.color = color13;
        }
        if (colorID == 14)
        {
            wallMaterial.color = color14;
        }
        if (colorID == 15)
        {
            wallMaterial.color = color15;
        }
    }
}
