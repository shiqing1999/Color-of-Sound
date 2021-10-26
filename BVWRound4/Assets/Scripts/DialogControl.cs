using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogControl : MonoBehaviour
{
    [SerializeField] private AudioClip[] dialogClips;
    [SerializeField] private int activeDialog = -1;
    [SerializeField] private float loadTime;
    [SerializeField] private float StartUpLoadTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartUpWait(StartUpLoadTime));
    }
    void PlayDialog()
    {
        if(dialogClips[activeDialog]!=null)
            GetComponent<AudioSource>().PlayOneShot(dialogClips[activeDialog]);
    }

    IEnumerator StartUpWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(DialogTimer(loadTime));
    }

    IEnumerator DialogTimer(float waitTime)
    {
        activeDialog++;
        PlayDialog();
        yield return new WaitForSeconds(waitTime);
        if(activeDialog < dialogClips.Length - 1)
            StartCoroutine(DialogTimer(loadTime)); 
    }
}
