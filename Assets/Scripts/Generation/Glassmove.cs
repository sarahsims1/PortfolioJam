using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glassmove : MonoBehaviour
{
    public float leftMost;
    public float rightMost;
    private bool goingRight;
    public float speed;

    void Update()
    {
        if(transform.position.x >=rightMost)
        {
            goingRight = false;
        }
        if(transform.position.x <= leftMost)
        {
            goingRight = true;
        }
        if(!goingRight)
        {
            transform.position += -Vector3.right * speed * Time.deltaTime;
        }
        if (goingRight)
        {
            transform.position -= -Vector3.right * speed * Time.deltaTime;
        }
    }
}
