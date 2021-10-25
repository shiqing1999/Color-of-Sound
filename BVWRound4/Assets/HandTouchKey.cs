using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTouchKey : MonoBehaviour
{
    [SerializeField] private GameObject pianoObject;

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "White Key")
        {
            pianoObject.GetComponent<KeyLightUp>().CheckNotePlayable(other.gameObject);
        }
    }
}
