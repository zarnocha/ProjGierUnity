using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skrypt_zad6 : MonoBehaviour
{

    public Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;
    // https://gamedev.stackexchange.com/questions/116272/whats-the-difference-between-mathf-lerp-and-mathf-smoothdamp

    void Start()
    {
        
    }


    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}
