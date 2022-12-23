using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSlow : MonoBehaviour
{
    public delegate void PlayerSlow();
    public static PlayerSlow ObstacleHit;

    public float coolDown;
    private float timeSinceLast;

    public float hitDistance;
    public float destroyDistance;
    public float nearMissDistance;

    public Animator swing;

    public GameObject explosion;

    public float explosionOffset;



    private void Update()
    {
        timeSinceLast += 1f * Time.deltaTime;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, destroyDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.tag == "Destructable")
                {
                    Instantiate(explosion, hit.collider.gameObject.transform.position + Vector3.up * explosionOffset, transform.rotation);
                    Destroy(hit.collider.gameObject);
                    Score.ModifyScore(1000, "Nice! +1000");
                    FMODUnity.RuntimeManager.PlayOneShot("event:/GlassShattering");
                }
                if (hit.collider.gameObject.tag == "Drone")
                {
                    Instantiate(explosion, hit.collider.gameObject.transform.position + Vector3.up * explosionOffset, transform.rotation);
                    Destroy(hit.collider.gameObject);
                    Score.ModifyScore(1000, "Unstoppable! +2000");
                    FMODUnity.RuntimeManager.PlayOneShot("event:/ObjectDestroyed");
                }
            }
        }
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, hitDistance) && timeSinceLast > coolDown)
        {           
            if (ObstacleHit != null) ObstacleHit(); 
            timeSinceLast = 0;
            FMODUnity.RuntimeManager.PlayOneShot("event:/HitWall");
        }     
        if(Input.GetKeyDown(KeyCode.E))
        {
            swing.Play("swing");
            FMODUnity.RuntimeManager.PlayOneShot("event:/SwordSwing");
        }    
    }
}
