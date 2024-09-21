using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultc : MonoBehaviour
{
    DrinkID drinkCS;
    public Text revenuebox;
    public GameObject[] rank;
    public int i;
    public int k;
    public int ID;
    public AudioSource src;
    public AudioClip sfx;
    public AudioClip sfx2;


    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        StartCoroutine(Ranking());
    }

    // Update is called once per frame
    void Update()
    {
        if(DrinkID.language == 0)
        {
            revenuebox.text = "總營收: " + DrinkID.revenue + " 元";
        }
        if (DrinkID.language == 1)
        {
            revenuebox.text = "Total Revenue: " + DrinkID.revenue + " $";
        }

    }
    public IEnumerator Ranking()
    {
        for (int k = 0; k < 40; k++)
        {
            for (int i = 0; i < 7; i++)
            {
                rank[i].SetActive(false);

            }
            ID = Random.Range(1, 8);
            rank[ID].SetActive(true);
            src.clip = sfx;
            src.Play();
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 7; i++)
        {
            rank[i].SetActive(false);

        }
        src.clip = sfx2;
        src.Play();
        if(DrinkID.revenue <= 50)
        {
            rank[1].SetActive(true);
        }
        if (DrinkID.revenue > 50 && DrinkID.revenue <= 150)
        {
            rank[2].SetActive(true);
        }
        if (DrinkID.revenue > 150 && DrinkID.revenue <= 300)
        {
            rank[3].SetActive(true);
        }
        if (DrinkID.revenue > 300 && DrinkID.revenue <= 500)
        {
            rank[4].SetActive(true);
        }
        if (DrinkID.revenue > 500 && DrinkID.revenue <= 700)
        {
            rank[5].SetActive(true);
        }
        if (DrinkID.revenue > 700 && DrinkID.revenue <= 900)
        {
            rank[6].SetActive(true);
        }
        if (DrinkID.revenue > 900)
        {
            rank[7].SetActive(true);
        }

    }

}
