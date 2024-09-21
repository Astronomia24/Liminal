using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupSpawning : MonoBehaviour
{
    public GameObject nCup;
    public Transform spawn;
    public GameObject currentCup;
    shakerTrigger scs;
    CupTrigger ct;
    // Start is called before the first frame update
    void Start()
    {
        currentCup = nCup;
        scs = FindObjectOfType<shakerTrigger>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Spawn()
    {

    }
}
