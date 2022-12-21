using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float hieght;
    public Vector2 xOffset;
    public float zOffset;
    public float speed;
    public float rotSpeed;
    public Quaternion finalRot;

    public GameObject lazerObject;
    public GameObject lazer;
    public float lazerDuration;

    private bool done;

    private FMOD.Studio.EventInstance droneFlight;
    private FMOD.Studio.EventInstance droneRay;
    private int soundVar = 0;

    void Start()
    {
        transform.localPosition += Vector3.up * hieght;
        transform.localPosition += Vector3.right * Random.Range(xOffset.x, xOffset.y);

        droneFlight = FMODUnity.RuntimeManager.CreateInstance("event:/DroneFlight");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(droneFlight, gameObject.transform);
        droneFlight.start();
        droneFlight.release();
    }


    void Update()
    {
        if (LevelManager.speed == 0) return;
        if(transform.localPosition.z < zOffset && !done)
        {
            transform.localPosition += Vector3.forward * speed * Time.deltaTime;
        }
        else if(transform.localPosition.z >= zOffset && lazerObject.transform.localRotation != finalRot)
        {
            StartCoroutine(Shoot());
            lazerObject.transform.localRotation = Quaternion.Slerp(lazerObject.transform.localRotation, finalRot, rotSpeed * Time.deltaTime);
            PlayRaySound();
        }
        else if(done)
        {
            transform.parent = null;
            transform.position += Vector3.up * speed * Time.deltaTime;

            droneFlight.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    private IEnumerator Shoot()
    {
        lazer.SetActive(true);
        
        yield return new WaitForSeconds(lazerDuration);
        lazer.SetActive(false);
        done = true;
    }

    void PlayRaySound()
    {
        if (soundVar == 0)
        {
            droneRay = FMODUnity.RuntimeManager.CreateInstance("event:/DroneRay");
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(droneRay, gameObject.transform);
            droneRay.start();
            droneRay.release();
            soundVar = 1;
        }
    }

}
