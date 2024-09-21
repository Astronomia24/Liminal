using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staticControl : MonoBehaviour
{
    DrinkID drinkCS;
    public Text instuctext;
    public Text mission1;
    public Text mission2;
    public Text mission3;
    public Text shakeText;
    public Text open;
    public Text close;
    public Text restart;
    public Text resume;
    public Text quit;
    public Text qualitytite;
    public Text low;
    public Text mid;
    public Text high;
    public Text unlock;
    public Text drink1;
    public Text drink2;
    public Text drink3;
    public Text laptopTitle;
    public Text desc;
    public Text name;
    public Text rando;
    public Text ret;
    public Text colorT;
    public Text closeTitle;
    public Text rev;
    public Text note;
    public Text buttonclose;
    public GameObject chip;
    public GameObject engp;
    public GameObject jpp;
    public GameObject gerp;
    public Text warn;

    public Text packtxt;
    public Text vtext;
    public Text ttxt1;
    public Text ttxt2;
    public Text ttxt3;
    public Text ttxt4;
    public Text scText;
    public Text creamText;
    PickUpClass pick;
    public Text wishText;
    public Text milkText;
    public Text refillText;
    public Text resText;
    public Text soundText;
    public Text skipText;



    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        if (DrinkID.language == 0)
        {
            chip.SetActive(true);
            engp.SetActive(false);
            jpp.SetActive(false);
            gerp.SetActive(false);
        }
        if (DrinkID.language == 1)
        {
            chip.SetActive(false);
            engp.SetActive(true);
            jpp.SetActive(false);
            gerp.SetActive(false);
        }
        if (DrinkID.language == 2)
        {
            chip.SetActive(false);
            engp.SetActive(false);
            jpp.SetActive(true);
            gerp.SetActive(false);
        }
        if (DrinkID.language == 3)
        {
            chip.SetActive(true);
            engp.SetActive(false);
            jpp.SetActive(false);
            gerp.SetActive(false);
        }
        if (DrinkID.language == 4)
        {
            chip.SetActive(false);
            engp.SetActive(false);
            jpp.SetActive(false);
            gerp.SetActive(true);
        }
        pick = FindObjectOfType<PickUpClass>();


    }

    // Update is called once per frame
    void Update()
    {
        if (drinkCS.lanID == 0)
        {
            instuctext.text = "撿起/互動        丟擲";
            mission1.text = "製作一杯 3 星以上飲料";
            mission2.text = "在家具網訂購一個裝潢";
            mission3.text = "完成一次煮茶";
            shakeText.text = "      開始搖杯 / 倒入塑膠杯";
            open.text = "營業中";
            close.text = "閉店中";
            restart.text = "重新開始";
            resume.text = "返回遊戲";
            quit.text = "退出遊戲";
            low.text = "低";
            mid.text = "中";
            high.text = "高";
            qualitytite.text = "畫質設定";
            skipText.text = "跳過教學";
            unlock.text = "解鎖了:";
            drink1.text = "奶綠";
            drink2.text = "紅茶鮮奶";
            drink3.text = "重乳奶茶";
            laptopTitle.text = "飲品價格";
            desc.text = " 綠茶 50$ 紅茶 75$ 奶茶 100$ 奶綠 120$ 紅茶鮮奶 150$ 重乳奶茶 180$ 珍珠 + 10 $";
            name.text = "改名";
            rando.text = "隨機顏色";
            ret.text = "上個顏色";
            colorT.text = "店鋪顏色";
            closeTitle.text = "結算";
            note.text = "閉店";

            warn.text = "試營運即將結束";

            packtxt.text = "      撕開包裝";
            vtext.text = "     開 / 關 水龍頭";
            ttxt1.text = "撿起 / 放下";
            ttxt2.text = "丟擲";
            ttxt3.text = "左旋轉";
            ttxt4.text = "右旋轉";
            if(pick.colliderName == "scooper (1)")
            {
                scText.text = "       長按加入冰塊";
            }
            if (pick.colliderName == "spoon")
            {
                scText.text = "       長按撈取配料";
            }
            if(pick.colliderName == "rag")
            {
                scText.text = "       長按擦除污漬";
            }
            resText.text = "解析度設定";
            soundText.text = "音效設定";


            creamText.text = "與紅茶一同泡煮以製得奶茶";
            wishText.text = "加入願望清單!";
            milkText.text = "牛奶和茶的比例約為1:1";
            refillText.text = "         補充";

        }
        if (drinkCS.lanID == 1)
        {
            instuctext.text = "Pick/Interact RMB       Throw";
            mission1.text = "Make a 3 star rating drink";
            mission2.text = "Order a decoration on decoration website";
            mission3.text = "Successfully boil a bucket of tea ";
            shakeText.text = "      start shaking  /  pour into cup";
            open.text = "open";
            close.text = "closed";
            restart.text = "Restart";
            resume.text = "Resume";
            quit.text = "Quit";
            low.text = "Low";
            mid.text = "Mid";
            high.text = "High";
            skipText.text = "Skip Tutorial";
            qualitytite.text = "Quality Settings";
            unlock.text = "You've unlocked:";
            drink1.text = "Green Tea With Milk";
            drink2.text = "Black Tea With Milk";
            drink3.text = "Milk Tea With Extra Milk";
            laptopTitle.text = "Price Of Drinks";
            desc.text = " Green Tea 50$ Black Tea 75$ Milk Tea 100$ Green Milk Tea 120$ Black Milk Tea 150$ Extra Milk Tea 180$ Boba + 10 $";
            name.text = "Change Name";
            rando.text = "Random Color";
            ret.text = "Previous Color";
            colorT.text = "Shop Color";
            closeTitle.text = "Result";
            note.text = "Close Shop";
            warn.text = "Last few hours before the closing!";

            packtxt.text = "      Open package";
            vtext.text = "   ON / OFF FAUCET";
            ttxt1.text = "Pick Up  /  Drop";
            ttxt2.text = "Throw";
            ttxt3.text = "Rotate Left";
            ttxt4.text = "Rotate Right";
            if (pick.colliderName == "scooper (1)")
            {
                scText.text = "       Hold to add ice";
            }
            if (pick.colliderName == "spoon")
            {
                scText.text = "       Hold to add toppings";
            }
            if (pick.colliderName == "rag")
            {
                scText.text = "       Hold to clean the stain";
            }
            creamText.text = "Boil with black tea leaf to make milk tea";
            wishText.text = "Add To Wishlist!";
            milkText.text = "The ratio of milk to tea is approximately 1:1";
            refillText.text = "         Restock";
            resText.text = "Resolution Settings";
            soundText.text = "Sound Settings";

        }
        if (drinkCS.lanID == 2)
        {
            instuctext.text = "拾う／インタラクション　投げる";
            mission1.text = "3つ星以上の飲み物を作る";
            mission2.text = "家具を購入する";
            mission3.text = "お茶を一回煮る";
            shakeText.text = "                                                   シェイクを始める / プラスチックカップに注ぐ";
            open.text = "営業中";
            close.text = "閉店中";
            restart.text = "再開";
            resume.text = "ゲームに戻る";
            quit.text = "ゲームを終了";
            low.text = "低";
            mid.text = "中";
            high.text = "高";
            skipText.text = "チュートリアルをスキップする";
            qualitytite.text = "グラフィック設定";
            unlock.text = "解除された:";
            drink1.text = "緑茶に牛乳を加える";
            drink2.text = "ミルクティー";
            drink3.text = "ダブルミルクティー";
            laptopTitle.text = "価格";
            desc.text = " 緑茶 50円 紅茶 75円 ミルクティー 100円 ミルクグリーンティー 120円 ミルクティー 150円 牛乳量二倍をください 180円 タピオカ + 10円";
            name.text = "名前を変更";
            rando.text = "ランダムカラー";
            ret.text = "前のカラー";
            colorT.text = "店舗のカラー";
            closeTitle.text = "決算";
            note.text = "閉店";

            warn.text = "試験運営がもうすぐ終了";

            packtxt.text = "               包装を開ける";
            vtext.text = "                              蛇口を開ける/閉める";
            ttxt1.text = "拾う/置く";
            ttxt2.text = "投げる";
            ttxt3.text = "左に回す";
            ttxt4.text = "右に回す";
            if (pick.colliderName == "scooper (1)")
            {
                scText.text = "                                 長押しで氷を入れる";
            }
            if (pick.colliderName == "spoon")
            {
                scText.text = "                                       長押しで具材を取り出す";
            }
            if (pick.colliderName == "rag")
            {
                scText.text = "                                              長押しで汚れを拭き取る";
            }


            creamText.text = "紅茶と一緒に煮出してミルクティーを作る";
            wishText.text = "ウィッシュリストに追加!";
            milkText.text = "ミルクと紅茶の比率は約1:1です";
            refillText.text = "         補充";
            resText.text = "解像度設定";
            soundText.text = "音声設定";


        }
        if (drinkCS.lanID == 3)
        {
            instuctext.text = "捡起/互动        丢掷";
            mission1.text = "制作一杯 3 星以上饮料";
            mission2.text = "在家具网订购一个装潢";
            mission3.text = "完成一次煮茶";
            shakeText.text = "      开始摇杯 / 倒入塑料杯";
            open.text = "营业中";
            close.text = "闭店中";
            restart.text = "重新开始";
            resume.text = "返回游戏";
            quit.text = "退出游戏";
            low.text = "低";
            mid.text = "中";
            high.text = "高";
            skipText.text = "跳过教程";
            qualitytite.text = "画质设定";
            unlock.text = "解锁了:";
            drink1.text = "奶绿";
            drink2.text = "红茶鲜奶";
            drink3.text = "重乳奶茶";
            laptopTitle.text = "饮品价格";
            desc.text = " 绿茶 50$ 紅茶 75$ 奶茶 100$ 奶绿 120$ 紅茶鮮奶 150$ 重乳奶茶 180$ 珍珠 + 10 $";
            name.text = "改名";
            rando.text = "随机颜色";
            ret.text = "上个颜色";
            colorT.text = "店铺颜色";
            closeTitle.text = "結算";
            note.text = "闭店";

            warn.text = "试营业即将结束";

            packtxt.text = "      撕开包装";
            vtext.text = "     开 / 关 水龙头";
            ttxt1.text = "捡起 / 放下";
            ttxt2.text = "丢掷";
            ttxt3.text = "左旋转";
            ttxt4.text = "右旋转";
            if (pick.colliderName == "scooper (1)")
            {
                scText.text = "       长按加入冰块";
            }
            if (pick.colliderName == "spoon")
            {
                scText.text = "       长按捞取配料";
            }
            if (pick.colliderName == "rag")
            {
                scText.text = "       长按擦除污渍";
            }


            creamText.text = "与红茶一同泡煮以制得奶茶";
            wishText.text = "加入愿望清单!";
            milkText.text = "牛奶和茶的比例约为1:1";
            refillText.text = "         补充";
            resText.text = "分辨率设置";
            soundText.text = " 音效设置";


        }
        if (drinkCS.lanID == 4)
        {
            instuctext.text = "Aufheben/Interagieren Werfen";
            mission1.text = "Bereite ein Getränk mit 3 oder mehr Sternen zu";
            mission2.text = "Bestelle eine Dekoration im Möbelnetz";
            mission3.text = "Beende einmal Teekochen";
            shakeText.text = "      Schütteln beginnen / In Plastikbecher gießen";
            open.text = "Geöffnet";
            close.text = "Geschlossen";
            restart.text = "Neustart";
            resume.text = "Zum Spiel zurückkehren";
            quit.text = "Spiel beenden";
            low.text = "Niedrig";
            mid.text = "Mittel";
            high.text = "Hoch";
            skipText.text = "Tutorial überspringen";
            qualitytite.text = "Grafikeinstellungen";
            unlock.text = "Freigeschaltet:";
            drink1.text = "Milchgrüner Tee";
            drink2.text = "Schwarzer Tee mit Milch";
            drink3.text = "Doppel-Milchtee";
            laptopTitle.text = "Getränkepreise";
            desc.text = "Grüner Tee 50$ Schwarzer Tee 75$ Milchtee 100$ Milchgrüner Tee 120$ Schwarzer Tee mit Milch 150$ Doppel-Milchtee 180$ Perlen + 10 $";
            name.text = "Umbenennen";
            rando.text = "Zufällige Farbe";
            ret.text = "Vorherige Farbe";
            colorT.text = "Ladenfarbe";
            closeTitle.text = "Abrechnung";
            note.text = "Geschlossen";

            warn.text = "Die Probezeit endet bald";

            packtxt.text = "        Verpackung aufreißen";
            vtext.text = "           Wasserhahn auf / zu";
            ttxt1.text = "Aufheben / Ablegen";
            ttxt2.text = "Werfen";
            ttxt3.text = "Nach links drehen";
            ttxt4.text = "Nach rechts drehen";
            if (pick.colliderName == "scooper (1)")
            {
                scText.text = "           Langes Drücken, um Eis hinzuzufügen";
            }
            if (pick.colliderName == "spoon")
            {
                scText.text = "           Langes Drücken, um Zutaten zu schöpfen";
            }
            if (pick.colliderName == "rag")
            {
                scText.text = "           Langes Drücken, um Flecken zu wischen";
            }

            creamText.text = "Mit schwarzem Tee aufbrühen, um Milchtee herzustellen";
            wishText.text = "Zur Wunschliste hinzufügen!";
            milkText.text = "Das Verhältnis von Milch zu Tee beträgt ungefähr 1:1";
            refillText.text = "         Nachfüllen";
            resText.text = "Auflösungseinstellungen";
            soundText.text = " Klangeinstellungen";



        }


    }
}

