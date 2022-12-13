using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigidBody;

    private bool grounded;

    public float ogFling;
    public float jumpHeight;

    public float strafeSpeed;
    public float strafeCooldown;
    private float timeSinceLastStrafe;

    private float jumpBuffer;
    public float jumpGrace;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(new Vector3(0, ogFling, ogFling));
    }

    void Update()
    {
        timeSinceLastStrafe += 1 * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rigidBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
        if (timeSinceLastStrafe >= strafeCooldown)
        {
            rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal") * strafeSpeed, 0, 0), ForceMode.Impulse);
            timeSinceLastStrafe = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
