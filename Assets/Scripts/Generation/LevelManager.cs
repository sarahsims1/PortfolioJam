using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static float speed;
    public static float targetSpeed;
    public float acceleration;

    private FMOD.Studio.EventInstance footsteps;

    private void Start()
    {
        ObstacleSlow.ObstacleHit += Slow;

        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        footsteps.start();
        footsteps.release();
    }
    private void Update()
    {
        if(speed < targetSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }

        footsteps.setParameterByName("speed", speed);
    }

    void Slow()
    {
        speed = 0;
    }

}
