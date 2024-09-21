using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;
    public GameObject textDisplay2;
    public GameObject textDisplay3;

    public void StoreName()
    {
        theName = inputField.GetComponent<TMPro.TextMeshProUGUI>().text;
        textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = theName;
        textDisplay2.GetComponent<TMPro.TextMeshProUGUI>().text = theName;
        textDisplay3.GetComponent<TMPro.TextMeshProUGUI>().text = theName;

    }
}
