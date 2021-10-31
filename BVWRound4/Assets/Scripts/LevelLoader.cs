using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public GameObject canvas;
    public float transitionTime = 1f;

    public float waitTime;

    private bool _loading = false;
    private void Start()
    {
        StartCoroutine(FadeOut(waitTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (_loading)
        {
            LoadNextLevel();
        }
    }
    IEnumerator FadeOut(float waitTime)
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        
        _loading = true;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetBool("Switch", true);
        Debug.Log("1");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("2");
        SceneManager.LoadScene(levelIndex);
    }

}
