using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLightUp : MonoBehaviour
{
    [SerializeField] private GameObject[] keys;
    [SerializeField] private Material unLitMat;
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
            keys[activeKey].GetComponent<MeshRenderer>().material = unLitMat;
        }
        activeKey = Random.Range(0, keys.Length);
        keys[activeKey].GetComponent<MeshRenderer>().material = litMat;
        StartCoroutine(RandomChangeKeyTexture(loadTime));
    }
    IEnumerator SongChangeKeyTexture(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (activeKey != -1)
            songSequenceOfKeys[activeKey].GetComponent<MeshRenderer>().material = unLitMat;
        yield return new WaitForSeconds(0.2f);
        activeKey++;
        if(activeKey<songSequenceOfKeys.Length)
        {
            songSequenceOfKeys[activeKey].GetComponent<MeshRenderer>().material = litMat;
            StartCoroutine(SongChangeKeyTexture(loadTime));
        }
        
    }
}
