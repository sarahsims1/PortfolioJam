using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float hieght;
    public Vector2 xOffset;
    public float zOffset;
    public float speed;
    void Start()
    {
        transform.localPosition += Vector3.up * hieght;
        transform.localPosition += Vector3.right * Random.Range(xOffset.x, xOffset.y);
    }


    void Update()
    {
        if(transform.localPosition.z < zOffset)
        {
            transform.localPosition += Vector3.forward * speed * Time.deltaTime;
        }
    }
}
