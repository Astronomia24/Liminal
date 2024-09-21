using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class endlan : MonoBehaviour
{
    public Text tech;
    public Text again;
    public Text add;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DrinkID.language == 0)
        {
            tech.text = "總技術評分: ";
            again.text = "再玩一次";
            add.text = "加入";
        }
        if (DrinkID.language == 1)
        {
            tech.text = "Overall skill ratings: ";
            again.text = "Play Again";
            add.text = "Add to Wishlist";
        }
        if (DrinkID.language == 2)
        {
            tech.text = "技術評価: ";
            again.text = "もう一度プレイする";
            add.text = "ウィッシュリストに追加";
        }
        if (DrinkID.language == 3)
        {
            tech.text = "評分: ";
            again.text = "再玩一次";
            add.text = "加入愿望清单!";
        }
        if (DrinkID.language == 4)
        {
            tech.text = "Bewertungen: ";
            again.text = "Nochmal spielen";
            add.text = "Zur Wunschliste hinzufügen!";
        }
    }
    public void ADD()
    {
        Application.OpenURL("https://store.steampowered.com/app/2189450/_/");
    }
}
