using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] platforms;
    public Vector2 obstacleRandomness;
    public float distanceToSpawn;
    private GameObject obstacle;
    private GameObject queuedObstacle;

    //private void Awake()
   // {
        //SceneManager.sceneLoaded += StartSpawn;
   // }
    private void Start()
    {
        obstacle = Instantiate(platforms[0], transform.localPosition + new Vector3(Random.Range(obstacleRandomness.x, obstacleRandomness.y), 0, Random.Range(obstacleRandomness.x, obstacleRandomness.y)), transform.rotation);
        queuedObstacle = platforms[Random.Range(0, platforms.Length)];
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, obstacle.transform.position) > distanceToSpawn)
        {
            SpawnNew();
        }
    }

    void SpawnNew()
    {
        Vector3 spawnPoint = transform.localPosition + new Vector3(Random.Range(obstacleRandomness.x, obstacleRandomness.y), 0, Random.Range(obstacleRandomness.x, obstacleRandomness.y));
        obstacle = Instantiate(queuedObstacle.gameObject, spawnPoint, transform.rotation);
        queuedObstacle = platforms[Random.Range(0, platforms.Length)];
    }
}
