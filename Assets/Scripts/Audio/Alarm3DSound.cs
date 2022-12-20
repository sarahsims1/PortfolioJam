using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm3DSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance alarm;
    void Start()
    {
        alarm = FMODUnity.RuntimeManager.CreateInstance("event:/Alarm3D");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(alarm, transform);
        alarm.start();
        alarm.release();
    }
}
