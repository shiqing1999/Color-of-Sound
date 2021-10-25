using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private bool keyDown;
    [SerializeField] private bool keyUp;
    [SerializeField] private float keySpeed;
    [SerializeField] private float rotationChangeAmount;
    [SerializeField] private float positionChangeAmount;
    private Vector3 goalPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        goalPos = this.transform.position - new Vector3(0f, positionChangeAmount, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(keyDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, goalPos, keySpeed * Time.deltaTime);
            if(transform.position == goalPos)
            {
                keyDown = false;
                keyUp = true;
            }
        }
        else if(keyUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, keySpeed * Time.deltaTime);
            if (transform.position == startPos)
                keyUp = false;
        }
    }

    public void PlayKey()
    {
        keyDown = true;
    }

}
