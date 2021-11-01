using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public GameObject spotlight;

    public float lightTime;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LightOn(lightTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LightOn(float lightTime)
    {
        yield return new WaitForSeconds(lightTime);
        spotlight.SetActive(true);
    }
}
