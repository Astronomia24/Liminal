using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSummon : MonoBehaviour
{
    public GameObject rag;
    public GameObject cube;
    public int rando;
    public int rando2;
    public GameObject newRag;
    public Rigidbody rb;
    public GameObject pos;
    customerManager cm;
    public AudioSource src;
    public AudioClip sfx;
    comeScript com;
    quener q;
    public GameObject cloneObj;


    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<customerManager>();
        com = FindObjectOfType<comeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3 && collision.relativeVelocity.magnitude > 5)
        {
            q = gameObject.GetComponent<quener>();
            rando = Random.Range(-20, 20);
            rando2 = Random.Range(12, 22);

            newRag = Instantiate(rag, pos.transform.position, Quaternion.identity);
            src.clip = sfx;
            src.Play();
            if(q.isQuening == true)
            {
                q.qStat.status[q.number] = false;
            }



            cube.transform.position = new Vector3(rando2, cube.transform.position.y, rando);
            q.drinkCS.credit -= 10;
            q.isTiming = false;
            q.isQuening = false;
            q.isRoaming = false;
            q.isWaiting = false;
            q.e1.SetActive(false);
            q.e2.SetActive(false);
            q.e3.SetActive(false);
            q.number = 9;
            q.Reset();
            q.Roam();
            q.StopAllCoroutines();
            cloneObj = Instantiate(gameObject, cube.transform.position, Quaternion.identity);
            cloneObj.name = "customer";
            Destroy(gameObject);













        }
    }
}
