using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigidBody;

    public float jumpHeight;

    public float strafeSpeed;
    public float MaxStrafeSpeed;
    public float slowDown;
    public float downPull;

    public float jumpBuffer;

    private FMOD.Studio.EventInstance footstepSound;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        footstepSound = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
    }

    void Update()
    {
        if(!Grounded() && !Staging.lowGravity && !Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.down * downPull);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Grounded() == true)
        {
            rigidBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
        if (Input.GetAxis("Horizontal") != 0f)
        {
            rigidBody.velocity = (new Vector3(strafeSpeed * Input.GetAxis("Horizontal"), rigidBody.velocity.y));
        }
        else 
        {
            rigidBody.velocity -= (new Vector3(rigidBody.velocity.x * slowDown, 0, 0));
        }
    }

    private bool Grounded()
    {
        var groundDistCheck = GetComponent<CapsuleCollider>().height / 2 + jumpBuffer;
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, groundDistCheck))
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Grounded", 1);
            return true;
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Grounded", 0);
            return false;
        }
    }
}
