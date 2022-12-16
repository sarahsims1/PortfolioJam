using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSlow : MonoBehaviour
{
    public delegate void PlayerSlow();
    public static PlayerSlow ObstacleHit;

    public float distance;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, distance))
        {
            if (ObstacleHit != null) ObstacleHit();
        }
    }
}
