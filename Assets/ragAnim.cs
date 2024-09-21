using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragAnim : MonoBehaviour
{
    Animator anim;
    public bool isRubbing;
    public GameObject movingRag;
    public SkinnedMeshRenderer skin;
    public bool played;
    public AudioSource src;
    public AudioClip[] sfx;
    public int ID;


    // Start is called before the first frame update
    void Start()
    {
        played = false;
        anim = movingRag.GetComponent<Animator>();
        isRubbing = false;
        skin = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRubbing == true)
        {
            anim.SetBool("isRub", true);
            //skin.enabled = false;
            if (Input.GetKey(KeyCode.E) && played == false)
            {
                ID = Random.Range(1, 5);
                src.clip = sfx[ID];
                src.Play();
                played = true;
            }
        }
        if(isRubbing == false)
        {
            anim.SetBool("isRub", false);
            //skin.enabled = true;
            played = false;
        }
    }
}
