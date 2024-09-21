using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{

    public LayerMask interactableLayerMask;

    void Start()
    {
 
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 4 , interactableLayerMask))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {

                }
            }

        }
    }
}
