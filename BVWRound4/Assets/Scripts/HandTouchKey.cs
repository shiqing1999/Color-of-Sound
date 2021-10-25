using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTouchKey : MonoBehaviour
{
    [SerializeField] private GameObject pianoObject;
    [SerializeField] public bool touchingKey;


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "White Key")
        {
            touchingKey = true;
            pianoObject.GetComponent<KeyLightUp>().CheckNotePlayable(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "White Key")
        {
            touchingKey = false;
            pianoObject.GetComponent<KeyLightUp>().CheckNotePlayable(other.gameObject);
        }
    }
}
