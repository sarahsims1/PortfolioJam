using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformGen : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject[] platforms;
    public GameObject[] lowGravityPlatform;
    public float distanceToSpawn;
    public float buffer;
    private GameObject platform;
    private GameObject newPlatform;
    private MeshRenderer currentRend;
    private MeshRenderer newRend;

    void Start()
    {
        
        platform = Instantiate(platforms[0], transform.position, transform.rotation);
        currentRend = platform.GetComponent<MeshRenderer>();
        newPlatform = PlatformSelect();
        newRend = newPlatform.GetComponent<MeshRenderer>();
    }
    private void Update()
    {

        if((transform.position - platform.transform.position).magnitude >= currentRend.bounds.size.z)
        {
            Debug.Log(transform.position.z - platform.transform.position.z);
            Debug.Log(transform.position.z - 70);
            SpawnNew();
        }
    }

    void SpawnNew()
    {              
        newPlatform = Instantiate(newPlatform, transform.localPosition, transform.rotation);
        CloseGap();
        platform = newPlatform;
        currentRend = platform.GetComponent<MeshRenderer>();       
        newPlatform = PlatformSelect();
        newRend = newPlatform.GetComponent<MeshRenderer>();
    }

    void CloseGap()
    {
        if((newPlatform.transform.position - platform.transform.position).magnitude > 0)
        {
            newPlatform.transform.position = platform.transform.position + Vector3.forward * (currentRend.bounds.size.z - buffer);
        }
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
