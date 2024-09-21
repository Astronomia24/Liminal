using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newWaterTrigger : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx;
    public AudioClip sfx1;
    DrinkID drinkCS;
    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "PickUp")
            {
                Debug.Log("Water");
                if(drinkCS.newIceAmount <= 0)
                {
                    src.clip = sfx;
                    src.Play();
                }
                else
                {
                    src.clip = sfx1;
                    src.Play();
                }

            }
        }
    }
}
