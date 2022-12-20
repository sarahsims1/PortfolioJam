using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRoar : MonoBehaviour
{
    [SerializeField] GameObject soundEmitter;
    void Start()
    {
        
    }

    void StartingRoar()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/MonsterRoar", soundEmitter);
    }
}
