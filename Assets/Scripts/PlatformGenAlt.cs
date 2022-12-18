using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenAlt : MonoBehaviour
{
    public Vector3 start;
    public float distanceToSpawn;
    public GameObject[] platformPool;
    bool Done;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, start) > distanceToSpawn && !Done)
        {
            Instantiate(platformPool[Random.Range(0, platformPool.Length)], transform.position + new Vector3(0, 0, GetComponent<Collider>().bounds.size.z), transform.rotation);
            Done = true;
        }
    }
}
