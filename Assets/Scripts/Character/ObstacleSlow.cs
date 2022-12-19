using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSlow : MonoBehaviour
{
    public delegate void PlayerSlow();
    public static PlayerSlow ObstacleHit;

    public float hitDistance;
    public float destroyDistance;

    public Animator swing;

    public GameObject explosion;


    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, hitDistance))
        {
                if (ObstacleHit != null) ObstacleHit();             
        }
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, destroyDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(explosion, hit.collider.gameObject.transform.position, transform.rotation);
                Destroy(hit.collider.gameObject);  
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            swing.Play("swing");
        }
    }
}
