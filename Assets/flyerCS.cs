using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyerCS : MonoBehaviour
{
    PickUpClass pick;
    public GameObject fly;
    FLYTRIGE fl;
    public int isFlyer;
    public GameObject camFly;
    public Transform camFlyer;
    public AudioSource src;
    public AudioClip sfx1;
    businessController bc;

    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
        fl = FindObjectOfType<FLYTRIGE>();
        bc = FindObjectOfType<businessController>();
        isFlyer = 0;
        camFly.SetActive(false);

        bc.flyerAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pick.colliderName == "flyer(Cl")
        {
            isFlyer = 1;

        }
        else
        {
            isFlyer = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(fl.placeable == 1)
            {

                if (bc.flyerAmount > 0)
                {
                    fly.SetActive(true);


                    fly.transform.position = new Vector3(camFlyer.position.x, camFlyer.position.y, camFlyer.position.z);
                    Vector3 eulerRotation = new Vector3(camFlyer.transform.eulerAngles.x, camFlyer.transform.eulerAngles.y, camFlyer.transform.eulerAngles.z);
                    fly.transform.rotation = Quaternion.Euler(eulerRotation);
                    Instantiate(fly, fly.transform.position, fly.transform.rotation);
                    src.clip = sfx1;
                    src.Play();
                    bc.flyerAmount -= 1;
                    fly.SetActive(false);
                }
            }
        }


    }

}
