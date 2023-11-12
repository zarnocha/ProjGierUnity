using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;

public class platformMove : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 2.0f;
    public Vector3 startPoint; 
    public Vector3 endPoint;

    private bool moving = false;

    private void Start()
    {
        transform.position = startPoint;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, endPoint) < 0.01f)
        {
            moving = false;
            playerTransform.GetComponent<CharacterController>().enabled = true;
        }
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint, speed);

            // blokujê poruszanie siê gracza, aby móc zmieniaæ jego pozycjê na sztywno, inaczej spada³by z platformy a tego chcia³em unikn¹æ
            playerTransform.GetComponent<CharacterController>().enabled = false;
            playerTransform.position = transform.position;
            playerTransform.GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");

            if (Vector3.Distance(transform.position, endPoint) < 0.01f)
            {
                // powrót platformy na miejsce startowe
                (endPoint, startPoint) = (startPoint, endPoint);

                // jeœli doje¿d¿amy na miejsce to platforma siê zatrzymuje
                moving = false;
                playerTransform.GetComponent<CharacterController>().enabled = true;
            }
            else
            {
                moving = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
        }
    }

}
