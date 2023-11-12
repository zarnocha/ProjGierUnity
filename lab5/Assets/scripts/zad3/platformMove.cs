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

            // blokuj� poruszanie si� gracza, aby m�c zmienia� jego pozycj� na sztywno, inaczej spada�by z platformy a tego chcia�em unikn��
            playerTransform.GetComponent<CharacterController>().enabled = false;
            playerTransform.position = transform.position;
            playerTransform.GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed� na wind�.");

            if (Vector3.Distance(transform.position, endPoint) < 0.01f)
            {
                // powr�t platformy na miejsce startowe
                (endPoint, startPoint) = (startPoint, endPoint);

                // je�li doje�d�amy na miejsce to platforma si� zatrzymuje
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
            Debug.Log("Player zszed� z windy.");
        }
    }

}
