using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightController : MonoBehaviour
{
    public Light sun;
    public float speed = 0.05f;
    [Range(0, 24)]
    public float timeOfDay;
    // Start is called before the first frame update
    void Start()
    {
        timeOfDay = 6f;
    }
    private void OnValidate()
    {
        UpdateTime();
    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay += speed * Time.deltaTime;
        if(timeOfDay > 23.9f)
        {
            timeOfDay = 1f;
        }

        UpdateTime();
        
    }
    private void UpdateTime()
    {
        float alpha = timeOfDay / 24.0f;
        float sunRotation = Mathf.Lerp(-90, 270, alpha);

        sun.transform.rotation = Quaternion.Euler(sunRotation, 390f, 0);
    }
}
