using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sealBoxStat : MonoBehaviour
{
    public int[] quantities;
    boxStat bStat;
    shelfStat sStat;
    boxTrigger bTrigger;
    Transform sealPos;
    DrinkID drinkCS;
    // Start is called before the first frame update
    void Start()
    {
        bStat = FindObjectOfType<boxStat>();
        bTrigger = FindObjectOfType<boxTrigger>();
        sStat = FindObjectOfType<shelfStat>();
        drinkCS = FindObjectOfType<DrinkID>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CastRay();
        }
    }
    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.gameObject == gameObject)
            {
                
                Unpack();
            }
        }
    }
    public void Transfer()
    {

        for (int i = 0; i < 7 + drinkCS.lv; i++)
        {
            quantities[i] = bStat.quantities[i];
        }
        for (int i = 0; i < 7 + drinkCS.lv; i++)
        {
            bStat.quantities[i] = 0;
        }
    }
    public void Unpack()
    {
        for(int i = 0; i < 7 + drinkCS.lv; i++)
        {
            for(int k = 0; k < quantities[i]; k++)
            {
                sealPos = gameObject.transform.GetChild(0);
                Instantiate(sStat.objects[i], sealPos.position, Quaternion.identity);

            }

        }
        Instantiate(bStat.emptyBox, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
