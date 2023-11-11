using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;

public class doorRotation : MonoBehaviour
{
    private Transform pivotPointTransform;
    public Transform doorDetector;
    
    private bool isDoorOpened = false;
    public float doorOpeningSpeed = 200f;
    
    void Start()
    {
        pivotPointTransform = transform.parent.GetComponent<Transform>();
    }

    void Update()
    {
        Debug.Log(pivotPointTransform.eulerAngles.y);
        if (isDoorOpened && (pivotPointTransform.eulerAngles.y > 270f || pivotPointTransform.eulerAngles.y == 0))
        {
            Vector3 doorRotation = Vector3.down * (Time.deltaTime * doorOpeningSpeed);
            pivotPointTransform.Rotate(doorRotation);

            // Zabezpieczenie, aby detektor siê nie obraca³ razem z drzwiami.
            Quaternion doorRotationAsQuaternion = new Quaternion(doorRotation.x, doorRotation.y, doorRotation.z, 0);
            doorDetector.rotation = (Quaternion.Inverse(doorRotationAsQuaternion));
        }
        else if (!isDoorOpened && pivotPointTransform.eulerAngles.y < 355f && pivotPointTransform.eulerAngles.y != 0)
        {
            Vector3 doorRotation = Vector3.up * (Time.deltaTime * doorOpeningSpeed);
            pivotPointTransform.Rotate(doorRotation);

            // Zabezpieczenie, aby detektor siê nie obraca³ razem z drzwiami.
            Quaternion doorRotationAsQuaternion = new Quaternion(doorRotation.x, doorRotation.y, doorRotation.z, 0);
            doorDetector.rotation = (Quaternion.Inverse(doorRotationAsQuaternion));
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player podszed³ do drzwi.");

            isDoorOpened = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player odszed³ od drzwi.");
            isDoorOpened = false;
        }
    }

}
