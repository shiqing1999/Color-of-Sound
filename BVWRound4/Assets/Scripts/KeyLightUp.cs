using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLightUp : MonoBehaviour
{
    [SerializeField] private GameObject[] keys;
    [SerializeField] private Material previousMat;
    [SerializeField] private Material litMat;
    [SerializeField] private float loadTime;
    [SerializeField] private float StartUpLoadTime;
    [SerializeField] private int activeKey = -1;
    [SerializeField] private GameObject[] songSequenceOfKeys;
    [SerializeField] private bool currentNotePlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(RandomChangeKeyTexture(loadTime));
        StartCoroutine(StartUpWait(StartUpLoadTime));
    }

    public void CheckNotePlayable(GameObject keyHit)
    {
        if (keyHit == songSequenceOfKeys[activeKey])
            currentNotePlayed = true;
    }

    IEnumerator StartUpWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(SongChangeKeyTexture(loadTime));
    }

    IEnumerator RandomChangeKeyTexture(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if(activeKey != -1)
        {
            if(keys[activeKey] != null)
                keys[activeKey].GetComponent<MeshRenderer>().material = previousMat;
        }
        activeKey = Random.Range(0, keys.Length);
        previousMat = keys[activeKey].GetComponent<MeshRenderer>().material;
        keys[activeKey].GetComponent<MeshRenderer>().material = litMat;
        StartCoroutine(RandomChangeKeyTexture(loadTime));
    }
    IEnumerator SongChangeKeyTexture(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (activeKey != -1)
        {
            if (songSequenceOfKeys[activeKey] != null)
            {
                songSequenceOfKeys[activeKey].GetComponent<MeshRenderer>().material = previousMat;
                songSequenceOfKeys[activeKey].GetComponent<BoxCollider>().enabled = false;

                if (currentNotePlayed)
                    songSequenceOfKeys[activeKey].GetComponent<AudioSource>().Play();
            }
        }   
        //yield return new WaitForSeconds(0.2f);
        activeKey++;
        if(activeKey < songSequenceOfKeys.Length)
        {
            currentNotePlayed = false;
            if (songSequenceOfKeys[activeKey] != null)
            {
                previousMat = songSequenceOfKeys[activeKey].GetComponent<MeshRenderer>().material;
                songSequenceOfKeys[activeKey].GetComponent<MeshRenderer>().material = litMat;
                songSequenceOfKeys[activeKey].GetComponent<BoxCollider>().enabled = true;
            }
            StartCoroutine(SongChangeKeyTexture(loadTime));
        }
        
    }
}
