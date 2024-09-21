using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject cubePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
        }
    }
}
