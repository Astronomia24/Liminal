using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    public GameObject textBubble;
    public Text msnText;



    // Start is called before the first frame update
    void Start()
    {
        msnText.text = "Welecome to your new shop, good Luck!";
        StartCoroutine(Msn());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public IEnumerator Msn()
    {
        textBubble.SetActive(true);
        src.clip = sfx1;
        src.Play();
        yield return new WaitForSeconds(5);
        textBubble.SetActive(false);
    }
}
