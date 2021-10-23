using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyGenerate : MonoBehaviour
{
    int num = 7;
    public GameObject keyPrefab;
    private float offset = 0.0458f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateKeys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateKeys()
    {
        for (int i = 0; i < num; i ++)
        {
            Debug.Log("a");
            Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + offset * i);
            GameObject go = Instantiate(keyPrefab, pos ,Quaternion.identity);
            

            DontDestroyOnLoad(go);
        }
    }
}
