using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorContoller : MonoBehaviour
{

    public GameObject mirrorCam;
    public GameObject mirrorTrigger;


    // Start is called before the first frame update
    void Start()
    {
        mirrorCam.SetActive(false);
        mirrorTrigger.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartMirror()
    {
        mirrorCam.SetActive(true);
        mirrorTrigger.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;






    }
    public void MirrorExit()
    {
        mirrorCam.SetActive(false);
        mirrorTrigger.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }
}
