using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summon : MonoBehaviour
{

    public GameObject rag;
    public GameObject cube;
    public GameObject ped;
    public Rigidbody rb;
    public int isDead;
    public GameObject newRag;
    public Transform summonPoint;
    public int rando;
    public GameObject busintext;






    // Start is called before the first frame update
    void Start()
    {
        isDead = 0;
        rag.SetActive(false);
        ped.SetActive(true);
        busintext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3 && collision.relativeVelocity.magnitude > 5 || collision.gameObject.tag == "Player" && collision.relativeVelocity.magnitude > 7f)
        {
            if (isDead == 0)
            {
                rando = Random.Range(-20, 20);
                isDead = 1;
                rag.SetActive(true);
                rag.transform.position = cube.transform.position;
                newRag = Instantiate(rag, rag.transform.position, rag.transform.rotation);
                rb = newRag.GetComponentInChildren<Rigidbody>();
                rag.SetActive(false);
                ped.SetActive(false);
                if (gameObject.name != "businessmanm")
                {
                    gameObject.transform.position = new Vector3(21f, 1.7f, rando);
                    ped.SetActive(true);
                }
                else
                {
                    busintext.SetActive(false);
                }

                rb.AddForce(newRag.transform.forward * 100f, ForceMode.Impulse);
                isDead = 0;

            }


        }
    }
    IEnumerator Revive()
    {
        yield return new WaitForSeconds(5);
        rag.SetActive(false);
        ped.SetActive(true);
        ped.transform.position = cube.transform.position;
        isDead = 0;

    }


}
