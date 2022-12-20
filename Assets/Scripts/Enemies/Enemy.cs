using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 timeBetweenEnemies;
    private float timeToSpawn;
    private float timePassed;

    public GameObject drone;
    void Start()
    {
        timeToSpawn = Random.Range(timeBetweenEnemies.x, timeBetweenEnemies.y);
    }

    void Update()
    {
        timePassed += Time.deltaTime * 1f;
        if(timePassed >= timeToSpawn)
        {
            Instantiate(drone, transform);
            timePassed = 0;
            timeToSpawn = Random.Range(timeBetweenEnemies.x, timeBetweenEnemies.y);
        }
    }
}
