using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VallasCreator : MonoBehaviour
{
    public GameObject[] fences;
    public float minCreationTime = 1.0f;
    public float maxCreationTime = 5.0f;
    public float minY = -5.0f;
    public float maxY = 5.0f;
    public float fencesX = 15.0f; 

    private float nextCreationTime;
    // Start is called before the first frame update
    void Start()
    {
        nextCreationTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCreationTime)
        {
            Instantiate(fences[Random.Range(0, fences.Length)], new Vector3(fencesX, Random.Range(minY, maxY), 0.0f), Quaternion.identity);
            
            nextCreationTime = Time.time + Random.Range(minCreationTime,maxCreationTime);  
        }

    }
}
