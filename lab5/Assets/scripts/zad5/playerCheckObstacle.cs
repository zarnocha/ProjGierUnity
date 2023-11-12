using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheckObstacle : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player dotkn¹³ przeszkody.");
            transform.GetComponent<CharacterController>().enabled = false;
            transform.position = new Vector3(2.15f, 1.0f, -3.35f);
            transform.GetComponent<CharacterController>().enabled = true;

        }
    }
}
