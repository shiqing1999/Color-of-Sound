using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTouchRandom : MonoBehaviour
{
    [SerializeField] private GameObject pianoObject;
  
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "White Key")
        {
            pianoObject.GetComponent<RandomizedKeys>().PlayNote();
            other.GetComponent<KeyMovement>().PlayKey();
        }
    }
}
