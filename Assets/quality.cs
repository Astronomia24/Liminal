using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Low()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
    public void Mid()
    {
        QualitySettings.SetQualityLevel(3, true);
    }
    public void High()
    {
        QualitySettings.SetQualityLevel(5, true);
    }

}
