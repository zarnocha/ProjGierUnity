using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Transform playerTransform;

    private bool isOnPlate = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isOnPlate)
        {
            // wywo³anie metody zmiany velocity gracza z jego skryptu poruszania siê
            playerTransform.GetComponent<playerMoveWithLaunch>().LaunchPlayer();
            isOnPlate = false;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na p³ytkê.");
            isOnPlate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z p³ytki.");
            isOnPlate = false;
        }
    }
}
