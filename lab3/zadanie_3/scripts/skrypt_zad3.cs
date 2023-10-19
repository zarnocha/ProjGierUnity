using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skrypt_zad3 : MonoBehaviour
{
    public int speed = 10;
    private int distance = 10;
    private int direction_x = 0;
    private int direction_z = 0;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float xPosition = transform.position.x;
        float zPosition = transform.position.z;
        
        float width = transform.GetChild(0).GetComponent<Renderer>().transform.lossyScale.x;

        if (zPosition +width < distance && xPosition - width <= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (zPosition + width >= distance && xPosition + width < distance)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (zPosition - width > 0 && xPosition + width >= distance)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (zPosition - width <= 0 && xPosition - width > 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
