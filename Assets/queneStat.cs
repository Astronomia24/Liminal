using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queneStat : MonoBehaviour
{
    public int quene;
    public GameObject[] slots;
    public bool[] status;
    public int killNumber;
    // Start is called before the first frame update
    void Start()
    {
        killNumber = 0;
        quene = 0;
        for(int i= 0; i < 9; i++)
        {
            status[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
