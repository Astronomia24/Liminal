using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creamSplat : MonoBehaviour
{
    public ParticleSystem part;
    public bool spilled;
    public GameObject mSplash;
    public Transform splashpos;

    public AudioSource src;
    public AudioClip[] sfx;
    public int ID;
    public bool sound;
    checkTrigger cTrigger;
    stainList sList;
    public GameObject currentStain;
    // Start is called before the first frame update
    void Start()
    {
        part = gameObject.GetComponent<ParticleSystem>();
        cTrigger = FindObjectOfType<checkTrigger>();
        sList = FindObjectOfType<stainList>();

        spilled = false;
        sound = false;
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
        cTrigger.mTea = true;



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
