using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(new Vector3(1, 0 , 0), speed);
    }
}
