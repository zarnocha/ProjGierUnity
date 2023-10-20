using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp_i_smooth : MonoBehaviour
{
    public Transform target;
    float smoothDampTime = 0.3f;
    float yVelocity = 0.0f;

    public float smoothLerpTime = 3f;

    void Start()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothDampTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
        
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + Vector3.up + Vector3.back;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothLerpTime * Time.deltaTime);
    }

}
