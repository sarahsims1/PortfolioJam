using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChange : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool gravityLow;
    private float time;
    public float upForce;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if(Staging.lowGravity && !gravityLow)
        {
            rigidbody.useGravity = false;
            rigidbody.AddForce(Vector3.up * upForce, ForceMode.Impulse);
            rigidbody.AddTorque(Vector3.up * upForce, ForceMode.Impulse);
            gravityLow = true;
        }
        else if(!Staging.lowGravity)
        {
            gravityLow = false;
            rigidbody.useGravity = true;
        }
    }
}
