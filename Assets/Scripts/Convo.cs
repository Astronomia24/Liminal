using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Convo : MonoBehaviour
{
    public GameObject convoCam;
    public GameObject Player;
    public TextMeshProUGUI convoText;
    public GameObject Buttons;
    public GameObject flyers;
    public int convoID;
    DrinkID drinkCS;



    // Start is called before the first frame update
    void Start()
    {
        convoCam.SetActive(false);
        Buttons.SetActive(false);
        flyers.SetActive(false);
        convoID = 0;
        drinkCS = FindObjectOfType<DrinkID>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Conversation()
    {
        convoCam.SetActive(true);
        Buttons.SetActive(true);
        Player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (convoID == 0)
        {
            convoText.text = "Flyer.co helps entrepreneurs create the best adevertisments! Would you like to try our services?";
        }
        if(convoID == 1)
        {
            convoText.text = "So, are you satisfied with the flyers?";
        }


    }
    IEnumerator EndConvo()
    {
        Buttons.SetActive(false);
        convoText.text = "Understandable, have a great day.";
        yield return new WaitForSeconds(2f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        convoCam.SetActive(false);
        Player.SetActive(true);

    }
    public void NoButton()
    {
        if (convoID == 0)
        {
            StartCoroutine(EndConvo());
        }
        if (convoID == 1)
        {
            StartCoroutine(EndConvo());
        }
        if (convoID == 2)
        {
            convoID = 1;
            StartCoroutine(EndConvo());
        }
    }
    public void YesButton()
    {
        if (convoID == 0)
        {
            StartCoroutine(Agree());
        }
        if(convoID == 1)
        {
            StartCoroutine(Agree1());
        }
        if(convoID == 2)
        {
            StartCoroutine(Agree2());
        }
    }
    IEnumerator Agree()
    {
        
        Buttons.SetActive(false);
        if (convoID == 0)
        {
            convoText.text = "Give the flyers to people can increase the popularity of your shop.";
            flyers.SetActive(true);
            yield return new WaitForSeconds(4);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            convoCam.SetActive(false);
            Player.SetActive(true);
            convoID = 1;
        }
    }
    IEnumerator Agree1()
    {
        {

            convoText.text = "10 pieces of flyers for 1000$, is that acceptable?";
            yield return new WaitForSeconds(0.01f);
            Buttons.SetActive(true);
            convoID = 2;


        }
    }
    IEnumerator Agree2()
    {
        if (drinkCS.money >= 1000)
        {


            convoText.text = "Glad to work with you, here are your flyers.";
            yield return new WaitForSeconds(2);
            Buttons.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            convoCam.SetActive(false);
            Player.SetActive(true);
        }
        else
        {
            convoText.text = "Seems like you didn't meet the requirement of our services, feel free to contact us if you meet them.";
            yield return new WaitForSeconds(2);
            Buttons.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            convoCam.SetActive(false);
            Player.SetActive(true);
            convoID = 1;
            
        }


    }

   

}
