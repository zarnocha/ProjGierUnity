using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class larp_skrypt_zad6 : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 5f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;

    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
    }
}
