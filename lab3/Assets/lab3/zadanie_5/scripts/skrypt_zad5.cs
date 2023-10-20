using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class skrypt_zad5 : MonoBehaviour
{
    public int plateSize = 10;
    public GameObject randomObject;

    void Start()
    {
        for (int i = 0; i < plateSize; i++)
        {
            float randomXPoint = Random.Range(0.5f, plateSize - 0.5f);
            float randomZPoint= Random.Range(0.5f, plateSize - 0.5f);

            // w pierwszym argumencie funkcji CheckBox jest 0.6f dlatego �e ca�y czas by�a kolizja z obiektem Plane
            while (
                    (
                    Physics.CheckBox(
                        new Vector3(randomXPoint, 0.6f, randomZPoint),
                        new Vector3(0.5f, 0.5f, 0.5f)
                        )
                    )
                ) {
                randomXPoint = Random.Range(0.5f, plateSize - 0.5f);
                randomZPoint = Random.Range(0.5f, plateSize - 0.5f);

                Debug.Log("Nast�pi�a kolizja");
            }

            Instantiate(randomObject, new Vector3(randomXPoint, 0.5f, randomZPoint), Quaternion.identity);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
