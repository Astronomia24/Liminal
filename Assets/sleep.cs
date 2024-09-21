using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sleep : MonoBehaviour
{
    public GameObject sleepCam;
    public Camera Came;
    public Image image;
    public bool isSleep;
    public float alph;
    conclude con;
    DrinkID drinkCS;
    // Start is called before the first frame update
    void Start()
    {
        alph = 0;
        isSleep = false;
        sleepCam.SetActive(false);
        Color c = image.color;
        c.a = alph;
        image.color = c;
        drinkCS = FindObjectOfType<DrinkID>();
        con = FindObjectOfType<conclude>();


    }

    // Update is called once per frame
    void Update()
    {
        if(isSleep == true)
        {
  
                alph += 0.01f;
                Color c = image.color;
                c.a = alph;
                image.color = c;



        }
        if(isSleep == false && alph != 0)
        {
            alph -= 0.01f;
            Color c = image.color;
            c.a = alph;
            image.color = c;
        }
        
    }
    public void StartSleep()
    {
        StartCoroutine(Sleeping());
    }
    IEnumerator Sleeping()
    {
        sleepCam.SetActive(true);
        Came.enabled = false;
        yield return new WaitForSeconds(0.5f);
        isSleep = true;
        yield return new WaitForSeconds(2.75f);
        isSleep = false;
        yield return new WaitForSeconds(1.75f);
        sleepCam.SetActive(false);
        Came.enabled = true;
        alph = 0;
        Color c = image.color;
        c.a = alph;
        image.color = c;
        con.end = drinkCS.day;
    }

}
