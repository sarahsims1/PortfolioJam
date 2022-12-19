using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 timeBetweenEnemies;
    private float timeToSpawn;
    private float timePassed;

    public GameObject drone;
    public GameObject meteor;
    void Start()
    {
        timeToSpawn = Random.Range(timeBetweenEnemies.x, timeBetweenEnemies.y);
    }

    void Update()
    {
        timePassed += Time.deltaTime * 1f;
        if(timePassed >= timeToSpawn && !Staging.lowGravity)
        {
            Instantiate(drone, transform);
            timePassed = 0;
            timeToSpawn = Random.Range(timeBetweenEnemies.x, timeBetweenEnemies.y);
        }
        else if(timePassed >= timeToSpawn && Staging.lowGravity)
        {
            Instantiate(meteor, transform);
            timePassed = 0;
            timeToSpawn = Random.Range(timeBetweenEnemies.x, timeBetweenEnemies.y);
        }
    }
}
