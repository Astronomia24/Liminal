using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutot : MonoBehaviour
{
    public GameObject textBox;
    public Text tutext;
    public Text objText;
    public int num;
    DrinkID drinkCS;
    public AudioSource src;
    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioClip sfx3;
    public AudioClip sfx4;
    public AudioClip sfx5;
    public AudioClip sfx6;
    public AudioClip sfx7;
    public AudioClip sfx8;
    public AudioClip sfx9;
    public AudioClip sfx10;

    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        textBox.SetActive(true);
        tutext.text = "歡迎來到你的店...剛倒閉不久的店";
        objText.text = "進入您的小破店";
        StartCoroutine(Mission1());
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start2()
    {
        StartCoroutine(Mission2());
        num = 1;
    }
    public void Start3()
    {
        StartCoroutine(Mission3());
        num = 2;
    }
    public void Start4()
    {
        StartCoroutine(Mission4());
        num = 3;
    }
    public void Start5()
    {
        StartCoroutine(Mission5());
        num = 4;
    }
    public void Start6()
    {
        StartCoroutine(Mission6());
        num = 5;
    }
    public void Start7()
    {
        StartCoroutine(Mission7());
        num = 6;
    }
    public void Start8()
    {
        StartCoroutine(Mission8());
        num = 7;
    }
    public void Start9()
    {
        StartCoroutine(Mission9());
        num = 9;
    }
    IEnumerator Mission1()
    {
        src.clip = sfx1;
        src.Play();
        tutext.text = "歡迎來到你的店...這家剛倒閉不久的店";
        objText.text = "進入您的小破店";
        yield return new WaitForSeconds(3);
        tutext.text = "來進去看看這鳥地方變成甚麼樣子";

    }

    IEnumerator Mission2()
    {
        src.clip = sfx2;
        src.Play();
        tutext.text = "靠，這裡臭得要命";
        objText.text = "把那垃圾拿去丟，用拖把拖掉污漬";
        yield return new WaitForSeconds(4);
        tutext.text = "先把垃圾丟一丟吧, 地板的污漬也清一清";

    }
    IEnumerator Mission3()
    {
        src.clip = sfx3;
        src.Play();
        tutext.text = "水喔, 差不多可以來做飲料了";
        objText.text = "在雪克杯中加入適量的冰塊";
        yield return new WaitForSeconds(4);
        tutext.text = "先做個少冰吧，你可能需要看一下桌上的冰量表";

    }
    IEnumerator Mission4()
    {
        src.clip = sfx4;
        src.Play();
        tutext.text = "來做杯紅茶怎麼樣?";
        objText.text = "在雪克杯中加入300ml的紅茶";
        yield return new WaitForSeconds(3);
        tutext.text = "一定要裝滿，不然別人會說我們偷工減料";

    }
    IEnumerator Mission5()
    {
        src.clip = sfx5;
        src.Play();
        tutext.text = "其實應該先加糖比較好，做一個半糖試試";
        objText.text = "用湯匙從量杯撈出果糖";
        yield return new WaitForSeconds(3);
        tutext.text = "畢竟我們窮到靠北，將就用一下果糖吧";
        yield return new WaitForSeconds(7);
        src.clip = sfx6;
        src.Play();
        tutext.text = "未看先猜，你是不是弄倒了";
        yield return new WaitForSeconds(4);
        tutext.text = "你可以用旁邊的筆電再訂一份";

    }
    IEnumerator Mission6()
    {
        src.clip = sfx7;
        src.Play();
        tutext.text = "給他搖個幾下，飲料才會好喝";
        objText.text = "上下搖晃飲料";
        yield return new WaitForSeconds(4);
        tutext.text = "不要問搖杯機在哪，沒有那種東西";

    }
    IEnumerator Mission7()
    {
        src.clip = sfx8;
        src.Play();
        tutext.text = "裝進塑膠杯就可以封膜了";
        objText.text = "裝進塑膠杯並封膜";
        yield return new WaitForSeconds(4);
        tutext.text = "這台機器應該是整間店最貴的東西了";

    }
    IEnumerator Mission8()
    {
        src.clip = sfx9;
        src.Play();
        tutext.text = "很好，真是太完美了";
        objText.text = "將飲料丟進垃圾桶";
        yield return new WaitForSeconds(4);
        tutext.text = "現在丟到筆電旁邊的小垃圾桶裡面";
        yield return new WaitForSeconds(4);
        tutext.text = "因為根本沒有人點這杯飲料";
        yield return new WaitForSeconds(4);
        tutext.text = "照著單做事非常重要，如果做錯，就整杯丟進去吧";
        yield return new WaitForSeconds(4);
        tutext.text = "好了，浪費了那些原料，該來補貨了";
        yield return new WaitForSeconds(4);
        tutext.text = "記得隨時保持存貨充裕";
        objText.text = "補充缺失的貨";
        num = 8;
        drinkCS.bTeaLeft = 0;
        drinkCS.gTeaLeft = 0;
        drinkCS.mTeaLeft = 0;


    }
    IEnumerator Mission9()
    {
        src.clip = sfx10;
        src.Play();
        tutext.text = "好了，應該沒了吧";
        objText.text = "明天再來";
        yield return new WaitForSeconds(4);
        tutext.text = "你可以滾了";
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("SampleScene");

    }
}
