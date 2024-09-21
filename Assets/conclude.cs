using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class conclude : MonoBehaviour
{
    public Text endText;
    DrinkID drinkCS;
    public GameObject endCanvas;
    public int end;
    public GameObject opentxt;
    public GameObject closetxt;
    // Start is called before the first frame update
    void Start()
    {
        drinkCS = FindObjectOfType<DrinkID>();
        end = 1;
        closetxt.SetActive(true);
        opentxt.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OK()
    {
        StartCoroutine(OKing());
       
    }
    public IEnumerator OKing()
    {
        yield return new WaitForSeconds(3);
        endCanvas.SetActive(false);
    }
}
