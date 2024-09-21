using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeLan : MonoBehaviour
{
    public Text playText;
    public Text quitText;
    public Text addText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DrinkID.language == 0)
        {
            playText.text = "開始遊戲";
            quitText.text = "退出遊戲";
            addText.text = "加入願望清單!";
        }
        if (DrinkID.language == 1)
        {
            playText.text = "Start Game";
            quitText.text = "Quit Game";
            addText.text = "Add To Wishlist!";
        }
        if (DrinkID.language == 2)
        {
            playText.text = "ゲームを開始する";
            quitText.text = "ゲームを終了する";
            addText.text = "ウィッシュリストに追加!";
        }
        if (DrinkID.language == 3)
        {
            playText.text = "开始游戏";
            quitText.text = "退出游戏";
            addText.text = "加入愿望清单!";
        }
        if (DrinkID.language == 4)
        {
            playText.text = "Spiel starten";
            quitText.text = "Spiel beenden";
            addText.text = "Auf die Wunschliste!";
        }

    }
    public void Lan1()
    {
        DrinkID.language = 0;
    }
    public void Lan2()
    {
        DrinkID.language = 1;
    }
    public void Lan3()
    {
        DrinkID.language = 2;
    }
    public void Lan4()
    {
        DrinkID.language = 3;
    }
    public void Lan5()
    {
        DrinkID.language = 4;
    }
}
