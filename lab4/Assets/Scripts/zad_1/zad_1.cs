using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zad_1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int objectAmount = 10;
    public GameObject block;

    public Material[] materialArray;

    void Start()
    {
        Renderer planeRenderer = GetComponent<Renderer>();

        Vector3 pozycja = transform.position;
        Vector3 planeSize = planeRenderer.bounds.size;
        Vector3 objectSize = block.GetComponent<Renderer>().bounds.size;

        float possibleXDown = (pozycja.x - (planeSize.x / 2)) + (objectSize.x / 2); 
        float possibleXUp =  (pozycja.x + (planeSize.x / 2)) - (objectSize.x / 2);

        float possibleZDown = (pozycja.z - (planeSize.z / 2)) + (objectSize.z / 2); 
        float possibleZUp = (pozycja.z + (planeSize.z / 2)) - (objectSize.z / 2);
        
        for (int i = 0; i < objectAmount; i++)
        {
            this.positions.Add(new Vector3(Random.Range(possibleXDown, possibleXUp), 0.5f, Random.Range(possibleZDown, possibleZUp)));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            Material randomMaterial = materialArray[Random.Range(0, materialArray.Length)];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity).GetComponent<Renderer>().material = randomMaterial;

            yield return new WaitForSeconds(this.delay);
        }
        
        StopCoroutine(GenerujObiekt());
    }
}
