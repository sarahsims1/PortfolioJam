using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float MaxTime;
    private float time;

    public GameObject[] obstacle;
    void Update()
    {
        time += Time.deltaTime;
        if(time>=MaxTime)
        {
            Instantiate(obstacle[0], transform.localPosition - new Vector3(Random.Range(-20f, 20f), 0, 0), transform.rotation);
            time = 0;
        }
    }
}
