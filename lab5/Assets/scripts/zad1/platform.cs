using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float elevatorSpeed = 1f;
    public float distance = 6.6f;

    private bool isRunning = false;
    private bool isRunningLeft = true;
    private bool isRunningRight = false;
    
    private float leftPosition;
    private float rightPosition;

    private Transform oldParent;

    void Start()
    {
        leftPosition = transform.position.x - distance;
        rightPosition = transform.position.x + distance;
    }

    void FixedUpdate()
    {
        if (isRunningLeft && transform.position.x >= rightPosition)
        {
            isRunning = false;
        }
        else if (isRunningRight && transform.position.x <= leftPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");

            oldParent = other.gameObject.transform.parent;

            other.gameObject.transform.parent = transform;
            if (transform.position.x >= rightPosition)
            {
                isRunningRight = true;
                isRunningLeft = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.x <= leftPosition)
            {
                isRunningLeft = true;
                isRunningRight = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            Debug.Log("Player zszed³ z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }

}
