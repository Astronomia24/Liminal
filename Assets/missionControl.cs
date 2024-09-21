using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missionControl : MonoBehaviour
{
    public GameObject[] checks;
    public GameObject[] missions;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        for(i = 0; i < 3; i ++)
        {
            checks[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mission3()
    {
        //checks[2].SetActive(true);
    }
    public void Mission2()
    {
        //checks[1].SetActive(true);
    }
    public void Mission1()
    {
       // checks[0].SetActive(true);
    }
}
