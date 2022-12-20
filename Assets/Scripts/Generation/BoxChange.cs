using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChange : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float delay;
    private float time;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if(Staging.lowGravity)
        {
            rigidbody.isKinematic = false;
        }
        else
        {
            rigidbody.isKinematic = true;
        }
    }
}
