using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodatkowy_skrypt_zad4 : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(0, 0, mV);

        transform.Rotate(Vector3.up * mH, Space.Self);

        if (mV > 0)
        {
            transform.Translate(Vector3.forward * mV * speed * Time.deltaTime, Space.Self);
        }
        else if (mV < 0)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
        }
    }
}
