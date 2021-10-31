using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedKeys : MonoBehaviour
{
    [SerializeField] private AudioClip[] allNotes;


    public void PlayNote()
    {
        GetComponent<AudioSource>().PlayOneShot(allNotes[Random.Range(0,allNotes.Length)], 0.6f);
    }
}
