using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformGen : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject[] lowGravityPlatform;

    public float buffer;

    private GameObject platform;
    private GameObject newPlatform;
    private MeshRenderer collider;
    float distance;
    public float maxPlatforms;
    public static float currentPlatforms;
    public float distanceToSpawn;


    void Start()
    {
        currentPlatforms = 0;
        platform = Instantiate(platforms[0], transform.position, transform.rotation);
        collider = platform.GetComponent<MeshRenderer>();
        newPlatform = PlatformSelect();
    }
    private void FixedUpdate()
    {
        distance = (transform.position - platform.transform.position).magnitude;
        if (distance >= collider.bounds.size.z && currentPlatforms < maxPlatforms)
        {      
            SpawnNew();
        }
    }

    void SpawnNew()
    {              
        newPlatform = Instantiate(newPlatform, transform.position, transform.rotation);
        newPlatform.transform.position += Vector3.forward *
                                          (distance
                                          + collider.bounds.size.z
                                          - buffer);
        platform = newPlatform;
        newPlatform = PlatformSelect();
        collider = newPlatform.GetComponent<MeshRenderer>();
        currentPlatforms++;
    }

    private GameObject PlatformSelect()
    {
        if(Staging.lowGravity)
        {
            return lowGravityPlatform[UnityEngine.Random.Range(0, lowGravityPlatform.Length)];
        }
        else
        {
            return platforms[UnityEngine.Random.Range(0, platforms.Length)];
        }
    }
}
