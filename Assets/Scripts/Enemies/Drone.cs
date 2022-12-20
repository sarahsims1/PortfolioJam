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

    private GameObject lazer;
    public float lazerDuration;

    private bool done;

    private FMOD.Studio.EventInstance droneFlight;
    private FMOD.Studio.EventInstance droneRay;
    private int soundVar = 0;

    void Start()
    {
        lazer = transform.GetChild(0).gameObject;
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
        else if(transform.localPosition.z >= zOffset && transform.localRotation != finalRot)
        {
            StartCoroutine(Shoot());
            transform.rotation = Quaternion.Slerp(transform.rotation, finalRot, speed * Time.deltaTime);
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
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/DroneRay", gameObject);
            soundVar = 1;
        }
        
    }
}
