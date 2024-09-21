using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revival : MonoBehaviour
{
    summon s;
    public GameObject ped;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<summon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(s.isDead == 1)
        {
            StartCoroutine(Revive());
        }
    }
    IEnumerator Revive()
    {
        yield return new WaitForSeconds(5);
        ped.SetActive(true);
        gameObject.SetActive(false);
        ped.transform.position = cube.transform.position;

        s.isDead = 0;
    }
}
