using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{
    public GameObject[] platforms;
    public float distanceToSpawn;
    private GameObject platform;
    private GameObject queuedPlatform;
    private Collider currentCollider;
    private Collider queuedCollider;
    void Start()
    {
        platform = Instantiate(platforms[0], transform.localPosition, transform.rotation);
        queuedPlatform = platforms[Random.Range(0,platforms.Length)];
        currentCollider = platform.GetComponent<Collider>();
        queuedCollider = queuedPlatform.GetComponent<Collider>();
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, platform.transform.position) > distanceToSpawn)
        {
            SpawnNew();
        }
    }

    void SpawnNew()
    {
        Vector3 spawnPoint = platform.transform.position + new Vector3(0,0,currentCollider.bounds.size.z) + new Vector3(0, 0, queuedCollider.bounds.extents.z - 1);
        platform = Instantiate(queuedPlatform.gameObject, spawnPoint, transform.rotation);
        queuedPlatform = platforms[Random.Range(0, platforms.Length)];
        currentCollider = platform.GetComponent<Collider>();
        queuedCollider = queuedPlatform.GetComponent<Collider>();
    }
}
