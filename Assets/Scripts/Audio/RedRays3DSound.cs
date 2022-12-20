using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRays3DSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance redRaysSound;
    void Start()
    {
        redRaysSound = FMODUnity.RuntimeManager.CreateInstance("event:/RedRays");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(redRaysSound, transform);
        redRaysSound.start();
        redRaysSound.release();
    }
}
