using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintCS : MonoBehaviour
{
    PickUpClass pick;
    public GameObject camPaint;
    public GameObject painting;
    public Transform camPaintPosition;
    public float paintRotationX;
    public float paintRotationZ;
    public float camRotationY;
    public Transform cam;
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        pick = FindObjectOfType<PickUpClass>();
        camPaint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(pick.colliderName == "carpet(Clone)")
        {
            camPaint.SetActive(true);
        }
        else
        {
            camPaint.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(pick.colliderName == "carpet(Clone)")
            {
                if (camPaintPosition.eulerAngles.x <= 180f)
                {
                    paintRotationX = camPaintPosition.eulerAngles.x;
                }
                else
                {
                    paintRotationX = camPaintPosition.eulerAngles.x - 360f;
                }
                if (camPaintPosition.eulerAngles.z <= 180f)
                {
                    paintRotationZ = camPaintPosition.eulerAngles.z;
                }
                else
                {
                    paintRotationZ = camPaintPosition.eulerAngles.z - 360f;
                }
                if (camPaintPosition.eulerAngles.y <= 180f)
                {
                    camRotationY = camPaintPosition.eulerAngles.y;
                }
                else
                {
                    camRotationY = camPaintPosition.eulerAngles.y - 360f;
                }

                Instantiate(painting, new Vector3(camPaintPosition.position.x, camPaintPosition.position.y, camPaintPosition.position.z), Quaternion.Euler(paintRotationX, camRotationY, paintRotationZ));
                pick.colliderName = "null";
                go = GameObject.Find("carpet(Clone)");
                Destroy(go);
                camPaint.SetActive(false);
                

            }
        }
    }
}
