using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handRotation : MonoBehaviour
{
    PickUpClass pick;
    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && pick.colliderName == "shaker")
        {

            gameObject.transform.Rotate(Vector3.forward * 50f * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Q) && pick.colliderName == "shaker")
        {

            gameObject.transform.Rotate(Vector3.forward * -50f * Time.deltaTime);

        }
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -17f, 0);
        }
    }
}
