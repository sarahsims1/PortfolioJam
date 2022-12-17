using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigidBody;

    public float ogFling;
    public float jumpHeight;

    public float strafeSpeed;

    public float jumpBuffer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(new Vector3(0, ogFling, ogFling));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Grounded() == true)
        {
            rigidBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
        rigidBody.AddForce(new Vector3(strafeSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0), ForceMode.Impulse);    
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
