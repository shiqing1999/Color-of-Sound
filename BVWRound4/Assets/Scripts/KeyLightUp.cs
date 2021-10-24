using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLightUp : MonoBehaviour
{
    [SerializeField] private GameObject[] keys;
    [SerializeField] private Material previousMat;
    [SerializeField] private Material litMat;
    [SerializeField] private float loadTime;
    [SerializeField] private int activeKey = -1;
    [SerializeField] private GameObject[] songSequenceOfKeys;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(RandomChangeKeyTexture(loadTime));
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
                songSequenceOfKeys[activeKey].GetComponent<MeshRenderer>().material = previousMat;
        }   
        yield return new WaitForSeconds(0.2f);
        activeKey++;
        if(activeKey < songSequenceOfKeys.Length)
        {
            if (songSequenceOfKeys[activeKey] != null)
            {
                previousMat = songSequenceOfKeys[activeKey].GetComponent<MeshRenderer>().material;
                songSequenceOfKeys[activeKey].GetComponent<MeshRenderer>().material = litMat;
            }
            StartCoroutine(SongChangeKeyTexture(loadTime));
        }
        
    }
}
