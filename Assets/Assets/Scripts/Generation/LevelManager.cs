using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float speed;
    public float targetSpeed;
    public float acceleration;

    private void Start()
    {
        ObstacleSlow.ObstacleHit += Slow;
    }
    private void Update()
    {
        if(speed < targetSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }
    }

    void Slow()
    {
        speed = 0;
    }

}