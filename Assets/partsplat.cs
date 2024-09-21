using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partsplat : MonoBehaviour
{
    public ParticleSystem part;
    public bool spilled;
    public GameObject mSplash;
    public Transform splashpos;
    shakerTrigger scs;
    public AudioSource src;
    public AudioClip[] sfx;
    public int ID;
    public bool sound;
    stainList sList;
    public GameObject currentStain;



    // Start is called before the first frame update
    void Start()
    {
        part = gameObject.GetComponent<ParticleSystem>();
        scs = FindObjectOfType<shakerTrigger>();
        spilled = false;
        sound = false;
        sList = FindObjectOfType<stainList>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {

        if (spilled == false)
        {
            Debug.Log("soaw");

            spilled = true;
            if (sound == false)
            {
                sound = true;
                on();
            }
            Invoke("splat", 0.3f);


        }

    }
    private void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Component component = ps.trigger.GetCollider(0);
        Debug.Log("agy");
        scs.FillMilk();
        

    }

    public void splat()
    {

        splashpos = gameObject.transform.GetChild(0).gameObject.transform;
        currentStain = Instantiate(mSplash, splashpos.position, Quaternion.identity);
        sList.stains.Add(currentStain);
        spilled = false;
        
    }
    public void on()
    {
        Invoke("off", 1f);
        ID = Random.Range(1, 5);
        src.clip = sfx[ID];
        src.Play();
    }
    public void off()
    {
        sound = false;
    }
}
