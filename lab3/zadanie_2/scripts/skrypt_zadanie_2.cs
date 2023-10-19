using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_2 : MonoBehaviour
{

    public float speed = 1.0f;
    private float distance = 10.0f;
    private int direction = 1;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0.0f, 0.0f);

        if (transform.position.x <= 0) direction = 1;
        else if (transform.position.x >= distance) direction = -1;

    }
}
