using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stainList : MonoBehaviour
{
    public List<GameObject> stains = new List<GameObject>();
    PickUpClass pick;
    public bool isRag;




    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
        isRag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stains.Count > 0)
        {
            if (pick.colliderName != "rag")
            {
                if (stains[0].layer != LayerMask.NameToLayer("Ignore Raycast"))
                {
                    for (int i = 0; i < stains.Count; i++)
                    {
                        if (stains[i] != null)
                        {
                            stains[i].layer = LayerMask.NameToLayer("Ignore Raycast");
                        }
                    }
                }

            }
            else
            {
                if (stains[0].layer != LayerMask.NameToLayer("Default"))
                {

                    for (int i = 0; i < stains.Count; i++)
                    {
                        if (stains[i] != null)
                        {
                            stains[i].layer = LayerMask.NameToLayer("Default");
                        }
                    }
                }
            }
        }


    }
}
