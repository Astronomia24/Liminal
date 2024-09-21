using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nside : MonoBehaviour
{
    public int missionNum;
    public GameObject convoCam;
    public Text convoText;
    public GameObject buttons;
    public bool isTaken;
    public GameObject findObject;
    public int x;
    public int z;
    PickUpClass pick;
    public GameObject go;



    // Start is called before the first frame update
    void Start()
    {
        convoCam.SetActive(false);
        isTaken = false;
        pick = FindObjectOfType<PickUpClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSide()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        convoCam.SetActive(true);
        buttons.SetActive(true);
        if (isTaken == false)
        {
            missionNum = Random.Range(1, 11);

            if (missionNum == 4 || missionNum == 5)
            {
                Debug.Log("find");
                convoText.text = "My package is lost, can you help me retrieve it?";
                buttons.SetActive(true);


            }
            else
            {
                Debug.Log("no");
                convoText.text = "Hi, I don't got anything for you to do now, come later.";
                buttons.SetActive(false);
                isTaken = false;
                StartCoroutine(EndConvo());
            }
        }
        else
        {

             if (missionNum == 4 || missionNum == 5)
            {
                if (pick.colliderName != "boxxx(Clone)")
                {
                    convoText.text = "Did you find the package?";
                    buttons.SetActive(false);
                    StartCoroutine(EndConvo());
                }
                else if(pick.colliderName == "boxxx(Clone)")
                {
                    go = GameObject.Find("boxxx(Clone)");
                    convoText.text = "Thanks bro.";
                    Destroy(go.gameObject);
                    buttons.SetActive(false);
                    StartCoroutine(EndConvo());
                    isTaken = false;
                    missionNum = 0;
                }
            }
        }
    }
    public void No()
    {
        convoText.text = "Alright, see you around.";
        buttons.SetActive(false);
        StartCoroutine(EndConvo());
    }
    public void Yes()
    {
        if (missionNum == 4 || missionNum == 5)
        {
            convoText.text = "Thanks a lot.";
            FindMission();
        }

        buttons.SetActive(false);
        StartCoroutine(EndConvo());
        isTaken = true;
    }
    IEnumerator EndConvo()
    {
        yield return new WaitForSeconds(3);
        convoCam.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void FindMission()
    {
        x = Random.Range(8, 17);
        z = Random.Range(-27, 27);
        Instantiate(findObject, new Vector3(x, 1.5f, z), Quaternion.identity);
    }
}
