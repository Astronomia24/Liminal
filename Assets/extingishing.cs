using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extingishing : MonoBehaviour
{
    PickUpClass pick;
    public GameObject spray;
    public AudioSource src;
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
        spray.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(pick.colliderName == "extinqish")
            {
                src.clip = sfx;
                src.Play();
                spray.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(1))
        {
            if (pick.colliderName == "extinqish")
            {
                src.Stop();
                spray.SetActive(false);
            }
            src.Stop();
            spray.SetActive(false);
        }
    }
    
}
