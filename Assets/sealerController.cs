using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sealerController : MonoBehaviour
{
 
    public GameObject sealerCup;
    public GameObject cup;
    public GameObject sealee;
    public GameObject moving;
    public GameObject plate;
    public GameObject lid;
    Animator sealAnim;
    Animator rotateAnim;
    public bool isSealing;
    nBtea nb;
    PickUpClass pick;
    public AudioSource src;
    public AudioClip sfx;
    public int i;
    public GameObject[] teas;
    public Transform trn;
    public cupStats stats;
    public GameObject seal;
    public bool isSealed;




    // Start is called before the first frame update
    void Start()
    {
        isSealed = false;
        cup = null;
        pick = FindObjectOfType<PickUpClass>();
        sealerCup.SetActive(false);
        sealee.SetActive(false);
        sealAnim = moving.GetComponent<Animator>();
        rotateAnim = plate.GetComponent<Animator>();
        nb = FindObjectOfType<nBtea>();
        isSealing = false;
    }

    // Update is called once per frame
    void Update()
    {





        if(isSealing == true)
        {
            sealAnim.SetBool("isSealing", true);
            rotateAnim.SetBool("isSealing", true);
        }
        if(isSealing == false)
        {
            sealAnim.SetBool("isSealing", false);
            rotateAnim.SetBool("isSealing", false);
        }

    }
    public void StartSealing()
    {
        stats = cup.GetComponent<cupStats>();

        sealerCup.SetActive(true);

        for (i = 1; i <= 6; i++)
        {
            teas[i].SetActive(false);
        }
        if(stats.teaID != 0)
        {

            teas[stats.teaID].SetActive(true);
        }
        cup.SetActive(false);
        StartCoroutine(sseal());


    }
    IEnumerator sseal()
    {
        src.clip = sfx;
        src.Play();
        isSealing = true;
        yield return new WaitForSeconds(1.5f);
        stats.isSealed = 1;

        yield return new WaitForSeconds(1.5f);

        isSealing = false;
        sealerCup.SetActive(false);
        cup.SetActive(true);
        cup.transform.position = trn.position;
        cup.transform.eulerAngles = new Vector3(0f, cup.transform.eulerAngles.y, 0f);
        sealee.SetActive(true);
        seal = stats.gameObject.transform.GetChild(8).gameObject;
        seal.SetActive(true);
        cup = null;
        isSealed = true;

    }
}
