using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splatter : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject splat;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("check", 1f);


    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y > 0 && gameObject.name != "fallSugar")
        {
            Debug.Log("Splat");
            Instantiate(splat, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
    public void check()
    {
        if(gameObject.name != "fallSugar")
        {
            Destroy(gameObject);
        }
    }
}
