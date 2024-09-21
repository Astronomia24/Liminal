using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sideQuest : MonoBehaviour
{
    public GameObject convoCam;
    public GameObject convocanvas;
    public GameObject Player;
    public TextMeshProUGUI convoText;
    public GameObject Buttons;
    public GameObject package;
    public int isDelivered;
    public int convoID;
    DrinkID drinkCS;



    // Start is called before the first frame update
    void Start()
    {
        convoCam.SetActive(false);
        package.SetActive(false);
        convocanvas.SetActive(false);
        convoID = 0;
        isDelivered = 0;
        drinkCS = FindObjectOfType<DrinkID>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SideQ()
    {
        convoCam.SetActive(true);
        convocanvas.SetActive(true);
        Buttons.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (convoID == 0)
        {
            convoText.text = "Sup, I got some package to deliver, wanna make some quick money?";
        }
        if(convoID == 1)
        {
            if (isDelivered == 1)
            {
                convoText.text = "Hey, my friend got the package, thanks! Here's 20 dollars.";
                drinkCS.money += 20;
                Buttons.SetActive(false);
                StartCoroutine(End());
            }
            if(isDelivered == 0)
            {
                convoText.text = "Hi, he didn't seems to get the pacakge, please deliver it asap.";
                Buttons.SetActive(false);
                StartCoroutine(Accept());
            }
        }
        if(convoID == 2)
        {
            convoText.text = "Thanks for the package last time!";
            StartCoroutine(End());
        }

    }
    public void No()
    {
        Buttons.SetActive(false);
        if (convoID == 0)
        {
            convoText.text = "Understood, thanks anyway.";
        }
        StartCoroutine(Decline());

    }
    public void Yes()
    {
        Buttons.SetActive(false);
        convoText.text = "Sweet, my client is next to the dumpster, please give it to him.";
        StartCoroutine(Accept());

    }
    IEnumerator Decline()
    {
        Buttons.SetActive(false);
        yield return new WaitForSeconds(2f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        convoCam.SetActive(false);
        Player.SetActive(true);
        convocanvas.SetActive(false);
    }
    IEnumerator Accept()
    {
        package.SetActive(true);
        Buttons.SetActive(false);
        yield return new WaitForSeconds(3f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        convoCam.SetActive(false);
        Player.SetActive(true);
        convocanvas.SetActive(false);
        convoID = 1;
    }
    IEnumerator End()
    {
        Buttons.SetActive(false);
        yield return new WaitForSeconds(3f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        convoCam.SetActive(false);
        Player.SetActive(true);
        convocanvas.SetActive(false);
        convoID = 2;
    }
}
