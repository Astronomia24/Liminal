using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shelfTrigger : MonoBehaviour
{
    shelfStat sStat;
    public GameObject shelfObj;
    public int shelfNumber;
    DrinkID drinkCS;
    public GameObject moneyAnim;
    public AudioSource moneysrc;
    public Text montxt;

    // Start is called before the first frame update
    void Start()
    {
        moneyAnim.SetActive(false);
        sStat = FindObjectOfType<shelfStat>();
        drinkCS = FindObjectOfType<DrinkID>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == shelfObj)
        {
            sStat.stock[shelfNumber] = false;
            if(drinkCS.money >= sStat.price[shelfNumber])
            {
                drinkCS.money -= sStat.price[shelfNumber];
                sStat.CheckStock();
                MoneyAnim();
            }
            else
            {
                Destroy(shelfObj);
                sStat.CheckStock();

            }

        }
    }
    void MoneyAnim()
    {
        moneysrc = GameObject.Find("moneySrc").GetComponent<AudioSource>();
        moneysrc.Play();
        montxt = moneyAnim.GetComponent<Text>();
        montxt.text = "- " + sStat.price[shelfNumber] + " $";
        moneyAnim.SetActive(true);
        Invoke("HideMoney", 1f);
    }
    public void HideMoney()
    {
        moneyAnim.SetActive(false);

    }

}
