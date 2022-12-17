using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigidBody;

    public float ogFling;
    public float jumpHeight;

    public float strafeSpeed;
    public float MaxStrafeSpeed;
    public float slowDown;

    public float jumpBuffer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(new Vector3(0, ogFling, ogFling));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded() == true)
        {
            rigidBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
        if (Input.GetAxis("Horizontal") != 0f && rigidBody.velocity.x < MaxStrafeSpeed && rigidBody.velocity.x > -MaxStrafeSpeed)
        {
            rigidBody.AddForce(new Vector3(strafeSpeed * Input.GetAxis("Horizontal"), 0, 0), ForceMode.VelocityChange);
        }
        else
        {
            rigidBody.velocity -= (new Vector3(slowDown * Time.deltaTime, 0, 0));
        }
    }

    private bool Grounded()
    {
        var groundDistCheck = GetComponent<CapsuleCollider>().height / 2 + jumpBuffer;
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, groundDistCheck))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
