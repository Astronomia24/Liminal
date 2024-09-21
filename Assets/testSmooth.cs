using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSmooth : MonoBehaviour
{
    public Vector3 originalPos;
    public Vector3 targetPos;
    public GameObject originalObj;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = GameObject.Find("Player").transform.position;
        originalObj = gameObject;
        originalPos = originalObj.transform.position;
        originalObj.transform.position = Vector3.SmoothDamp(originalPos, targetPos, ref velocity, 2f);
    }
}
